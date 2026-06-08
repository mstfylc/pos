import { useState, type ReactNode } from "react";
import { useMutation, useQuery } from "@tanstack/react-query";
import { Drawer, Input, Select, Textarea, Button, Alert } from "@/design-system";
import { MultiSelect } from "../MultiSelect";
import { createDiscount, updateDiscount, listPos, listUsers } from "@/lib/api";
import { getCompanyId, getUserId } from "@/lib/session";
import { ApiError } from "@/lib/http";
import { parseDec, decStr, toIso, toLocalInput } from "@/lib/format";
import { DiscountTypeEnum, DiscountCategoryEnum, DISCOUNT_TYPE_LABEL, DISCOUNT_CATEGORY_LABEL } from "@/lib/api/types";
import type { DiscountDto, DiscountWriteDto } from "@/lib/api/types";
import "../forms.css";

interface Props {
  open: boolean;
  onClose: () => void;
  discount: DiscountDto | null;
  onSaved: () => void;
}

function useSet(initial: string[]): [Set<string>, (id: string) => void] {
  const [s, setS] = useState<Set<string>>(new Set(initial));
  return [s, (id) => setS((p) => { const n = new Set(p); n.has(id) ? n.delete(id) : n.add(id); return n; })];
}

export function DiscountForm({ open, onClose, discount, onSaved }: Props): ReactNode {
  const isEdit = discount !== null;
  const pos = useQuery({ queryKey: ["pos"], queryFn: listPos });
  const users = useQuery({ queryKey: ["users", "all"], queryFn: () => listUsers({ page: 1, pageSize: 200 }) });

  const [description, setDescription] = useState(discount?.description ?? "");
  const [discountType, setDiscountType] = useState<number>(discount?.discountType ?? DiscountTypeEnum.Percentage);
  const [category, setCategory] = useState<number>(discount?.discountCategory ?? DiscountCategoryEnum.All);
  const [amount, setAmount] = useState(decStr(discount?.amount));
  const [maxDiscount, setMaxDiscount] = useState(decStr(discount?.maxDiscountAmount));
  const [monthlyLimit, setMonthlyLimit] = useState(decStr(discount?.monthlyLimit));
  const [expireDate, setExpireDate] = useState(toLocalInput(discount?.expireDate));
  const [sortOrder, setSortOrder] = useState(String(discount?.sortOrder ?? 0));
  const [posIds, togglePos] = useSet(discount?.posIds ?? []);
  const [userIds, toggleUser] = useSet(discount?.userIds ?? []);
  const [err, setErr] = useState<{ amount?: string; maxDiscount?: string }>({});

  const save = useMutation({
    mutationFn: () => {
      const body: DiscountWriteDto = {
        companyId: getCompanyId(),
        userId: getUserId(),
        description: description.trim() || null,
        amount: parseDec(amount) ?? 0,
        maxDiscountAmount: parseDec(maxDiscount) ?? 0,
        monthlyLimit: parseDec(monthlyLimit),
        expireDate: toIso(expireDate),
        discountType,
        discountCategory: category,
        sortOrder: Number.parseInt(sortOrder, 10) || 0,
        branchIds: discount?.branchIds ?? [],
        posIds: category === DiscountCategoryEnum.Pos ? [...posIds] : [],
        userIds: category === DiscountCategoryEnum.Personnel ? [...userIds] : [],
      };
      return isEdit ? updateDiscount(discount.id, body) : createDiscount(body);
    },
    onSuccess: () => onSaved(),
  });

  function submit(): void {
    const e: typeof err = {};
    if (parseDec(amount) == null) e.amount = "Tutar zorunludur.";
    if (parseDec(maxDiscount) == null) e.maxDiscount = "Maks. indirim zorunludur.";
    setErr(e);
    if (Object.keys(e).length) return;
    save.mutate();
  }

  const errMsg = save.error instanceof ApiError ? save.error.message : save.isError ? "Kaydetme başarısız." : null;

  return (
    <Drawer
      open={open} onClose={onClose} size="lg"
      title={isEdit ? "İndirimi düzenle" : "Yeni indirim"}
      subtitle={isEdit ? (discount.description ?? "İndirim") : "İndirim kuralı tanımla"}
      footer={
        <>
          <Button variant="light" color="dark" onClick={onClose} disabled={save.isPending}>İptal</Button>
          <Button color="accent" iconStart="check-circle" onClick={submit} disabled={save.isPending}>{save.isPending ? "Kaydediliyor…" : isEdit ? "Kaydet" : "Oluştur"}</Button>
        </>
      }
    >
      {errMsg && <Alert color="danger" title="Hata" style={{ marginBottom: 16 }}>{errMsg}</Alert>}
      <div className="fm-grid">
        <div className="fm-col2"><Textarea label="Açıklama" rows={2} value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Örn. Personel %10" /></div>
        <Select label="Tip" value={discountType} onChange={(e) => setDiscountType(Number(e.target.value))}>
          {Object.entries(DISCOUNT_TYPE_LABEL).map(([v, l]) => <option key={v} value={v}>{l}</option>)}
        </Select>
        <Select label="Kapsam (scope)" value={category} onChange={(e) => setCategory(Number(e.target.value))}>
          {Object.entries(DISCOUNT_CATEGORY_LABEL).map(([v, l]) => <option key={v} value={v}>{l}</option>)}
        </Select>
        <Input label="Tutar / Oran" required inputMode="decimal" value={amount} error={err.amount} onChange={(e) => setAmount(e.target.value)} placeholder={discountType === DiscountTypeEnum.Percentage ? "% 10" : "₺ 10"} />
        <Input label="Maks. indirim (₺)" required inputMode="decimal" value={maxDiscount} error={err.maxDiscount} onChange={(e) => setMaxDiscount(e.target.value)} />
        <Input label="Aylık limit (₺)" inputMode="decimal" value={monthlyLimit} onChange={(e) => setMonthlyLimit(e.target.value)} placeholder="Boş = limitsiz" />
        <Input label="Son geçerlilik" type="datetime-local" value={expireDate} onChange={(e) => setExpireDate(e.target.value)} />
        <Input label="Sıra" type="number" value={sortOrder} onChange={(e) => setSortOrder(e.target.value)} />
      </div>

      {category === DiscountCategoryEnum.Pos && (
        <><div className="fm-section">POS kapsamı</div>
        <MultiSelect options={(pos.data ?? []).map((p) => ({ id: p.id, label: p.name }))} selected={posIds} onToggle={togglePos} emptyText="POS yok." /></>
      )}
      {category === DiscountCategoryEnum.Personnel && (
        <><div className="fm-section">Personel kapsamı</div>
        <MultiSelect options={(users.data?.items ?? []).map((u) => ({ id: u.id, label: `${u.firstName} ${u.lastName}` }))} selected={userIds} onToggle={toggleUser} emptyText="Kullanıcı yok." /></>
      )}
      {category === DiscountCategoryEnum.Branch && (
        <div className="fm-section"><span className="fm-section__note">Şube kapsamı: şube listesi ucu kontratta yok — kapsam boş gönderilir.</span></div>
      )}
    </Drawer>
  );
}
