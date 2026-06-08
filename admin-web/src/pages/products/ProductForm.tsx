import { useMemo, useState, type ReactNode } from "react";
import { useMutation, useQuery } from "@tanstack/react-query";
import { Drawer, Input, Select, Textarea, Switch, Button, Alert } from "@/design-system";
import { createProduct, updateProduct, createPosProduct, updatePosProduct, listPosProductsForProduct } from "@/lib/api";
import { getCompanyId, getUserId } from "@/lib/session";
import { ApiError } from "@/lib/http";
import { ProductUnit, Tax } from "@/lib/api/types";
import type { CategoryDto, PosDto, ProductDto, ProductWriteDto } from "@/lib/api/types";
import "./ProductForm.css";

const UNIT_OPTS = [
  { value: ProductUnit.Adet, label: "Adet" },
  { value: ProductUnit.MiliLitre, label: "Mililitre (ml)" },
  { value: ProductUnit.Gram, label: "Gram (gr)" },
];
const TAX_OPTS = [
  { value: Tax.Sifir, label: "%0" },
  { value: Tax.Bir, label: "%1" },
  { value: Tax.Sekiz, label: "%8" },
  { value: Tax.OnSekiz, label: "%18" },
];

function parseDec(s: string): number | null {
  const t = s.trim().replace(",", ".");
  if (t === "") return null;
  const n = Number(t);
  return Number.isNaN(n) ? null : n;
}
function decStr(n: number | null | undefined): string {
  return n == null ? "" : String(n);
}

interface PosRow {
  posId: string;
  name: string;
  overrideId: string | null;
  purchase: string;
  sale: string;
}

interface ProductFormProps {
  open: boolean;
  onClose: () => void;
  product: ProductDto | null;
  categories: CategoryDto[];
  posList: PosDto[];
  onSaved: () => void;
}

interface FieldErrors {
  name?: string;
  categoryId?: string;
}

export function ProductForm({ open, onClose, product, categories, posList, onSaved }: ProductFormProps): ReactNode {
  const isEdit = product !== null;

  const [name, setName] = useState(product?.name ?? "");
  const [categoryId, setCategoryId] = useState(product?.categoryId ?? "");
  const [unit, setUnit] = useState<number>(product?.productUnitType ?? ProductUnit.Adet);
  const [tax, setTax] = useState<number>(product?.taxType ?? Tax.OnSekiz);
  const [description, setDescription] = useState(product?.description ?? "");
  const [purchasePrice, setPurchasePrice] = useState(decStr(product?.purchasePrice));
  const [salePrice, setSalePrice] = useState(decStr(product?.salePrice));
  const [barcode, setBarcode] = useState(product?.barcode ?? "");
  const [stockCode, setStockCode] = useState(product?.stockCode ?? "");
  const [image, setImage] = useState(product?.image ?? "");
  const [sortOrder, setSortOrder] = useState(String(product?.sortOrder ?? 0));

  const [stocktaking, setStocktaking] = useState(product?.stocktaking ?? true);
  const [storeProduct, setStoreProduct] = useState(product?.storeProduct ?? true);
  const [posProduct, setPosProduct] = useState(product?.posProduct ?? true);
  const [favoriteProduct, setFavoriteProduct] = useState(product?.favoriteProduct ?? false);
  const [main, setMain] = useState(product?.main ?? true);
  const [entryProduct, setEntryProduct] = useState(product?.entryProduct ?? false);

  const [posRows, setPosRows] = useState<PosRow[]>(
    () => posList.map((p) => ({ posId: p.id, name: p.name, overrideId: null, purchase: "", sale: "" })),
  );
  const [err, setErr] = useState<FieldErrors>({});

  // Düzenlemede mevcut POS override'larını oku ve satırlara doldur (artık GET ucu var).
  useQuery({
    queryKey: ["pos-products", product?.id],
    queryFn: async () => {
      const overrides = await listPosProductsForProduct(product!.id);
      setPosRows((rows) =>
        rows.map((r) => {
          const o = overrides.find((x) => x.posId === r.posId);
          return o ? { ...r, overrideId: o.id, purchase: decStr(o.purchasePrice), sale: decStr(o.salePrice) } : r;
        }),
      );
      return overrides;
    },
    enabled: isEdit && posList.length > 0,
  });

  const categoryOptions = useMemo(
    () => categories.filter((c) => c.active).map((c) => ({ value: c.id, label: c.name })),
    [categories],
  );

  const save = useMutation({
    mutationFn: async (): Promise<ProductDto> => {
      const companyId = getCompanyId();
      const userId = getUserId();
      const body: ProductWriteDto = {
        companyId,
        userId,
        name: name.trim(),
        categoryId,
        purchasePrice: parseDec(purchasePrice),
        salePrice: parseDec(salePrice),
        barcode: barcode.trim() || null,
        stockCode: stockCode.trim() || null,
        productUnitType: unit,
        taxType: tax,
        stocktaking,
        image: image.trim() || null,
        storeProduct,
        posProduct,
        entryProduct,
        favoriteProduct,
        sortOrder: Number.parseInt(sortOrder, 10) || 0,
        description: description.trim() || null,
        main,
        parentId: product?.parentId ?? null,
      };
      const saved = isEdit ? await updateProduct(product.id, body) : await createProduct(body);

      for (const r of posRows) {
        const hasValue = r.purchase.trim() !== "" || r.sale.trim() !== "";
        const posBody = { companyId, userId, posId: r.posId, productId: saved.id, purchasePrice: parseDec(r.purchase), salePrice: parseDec(r.sale) };
        if (r.overrideId) {
          if (hasValue) await updatePosProduct(r.overrideId, posBody);
        } else if (hasValue) {
          await createPosProduct(posBody);
        }
      }
      return saved;
    },
    onSuccess: () => onSaved(),
  });

  function submit(): void {
    const er: FieldErrors = {};
    if (!name.trim()) er.name = "Ürün adı zorunludur.";
    if (!categoryId) er.categoryId = "Kategori seçiniz.";
    setErr(er);
    if (Object.keys(er).length) return;
    save.mutate();
  }

  function setRow(posId: string, patch: Partial<PosRow>): void {
    setPosRows((rows) => rows.map((r) => (r.posId === posId ? { ...r, ...patch } : r)));
  }

  const errMsg = save.error instanceof ApiError ? save.error.message : save.isError ? "Kaydetme başarısız." : null;

  return (
    <Drawer
      open={open}
      onClose={onClose}
      size="lg"
      title={isEdit ? "Ürünü düzenle" : "Yeni ürün"}
      subtitle={isEdit ? product.name : "Kataloğa yeni ürün ekle"}
      footer={
        <>
          <Button variant="light" color="dark" onClick={onClose} disabled={save.isPending}>İptal</Button>
          <Button color="accent" iconStart="check-circle" onClick={submit} disabled={save.isPending}>
            {save.isPending ? "Kaydediliyor…" : isEdit ? "Değişiklikleri kaydet" : "Ürünü oluştur"}
          </Button>
        </>
      }
    >
      {errMsg && <Alert color="danger" title="Hata" style={{ marginBottom: 16 }}>{errMsg}</Alert>}

      <div className="pf-grid">
        <Input label="Ürün adı" required value={name} error={err.name} onChange={(e) => setName(e.target.value)} placeholder="Örn. Caffè Latte" />
        <Select label="Kategori" required value={categoryId} error={err.categoryId} onChange={(e) => setCategoryId(e.target.value)}>
          <option value="">Seçiniz…</option>
          {categoryOptions.map((o) => <option key={o.value} value={o.value}>{o.label}</option>)}
        </Select>

        <Select label="Birim" required value={unit} onChange={(e) => setUnit(Number(e.target.value))}>
          {UNIT_OPTS.map((o) => <option key={o.value} value={o.value}>{o.label}</option>)}
        </Select>
        <Select label="KDV" required value={tax} onChange={(e) => setTax(Number(e.target.value))}>
          {TAX_OPTS.map((o) => <option key={o.value} value={o.value}>{o.label}</option>)}
        </Select>

        <Input label="Alış fiyatı (₺)" inputMode="decimal" value={purchasePrice} onChange={(e) => setPurchasePrice(e.target.value)} placeholder="0,00" />
        <Input label="Satış fiyatı (₺)" inputMode="decimal" value={salePrice} onChange={(e) => setSalePrice(e.target.value)} placeholder="0,00" />

        <Input label="Barkod" value={barcode} onChange={(e) => setBarcode(e.target.value)} placeholder="869…" />
        <Input label="Stok kodu" value={stockCode} onChange={(e) => setStockCode(e.target.value)} placeholder="SKU-…" />

        <Input label="Görsel URL" value={image} onChange={(e) => setImage(e.target.value)} placeholder="https://…" />
        <Input label="Sıra" type="number" value={sortOrder} onChange={(e) => setSortOrder(e.target.value)} />

        <div className="pf-col2">
          <Textarea label="Açıklama" rows={2} value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Kısa açıklama…" />
        </div>
      </div>

      <div className="pf-section">Ayarlar</div>
      <div className="pf-switches">
        <Switch label="Stok takibi" checked={stocktaking} onChange={(e) => setStocktaking(e.target.checked)} />
        <Switch label="Depo ürünü" checked={storeProduct} onChange={(e) => setStoreProduct(e.target.checked)} />
        <Switch label="POS ürünü" checked={posProduct} onChange={(e) => setPosProduct(e.target.checked)} />
        <Switch label="Favori" checked={favoriteProduct} onChange={(e) => setFavoriteProduct(e.target.checked)} />
        <Switch label="Ana ürün" checked={main} onChange={(e) => setMain(e.target.checked)} />
        <Switch label="Giriş ürünü" checked={entryProduct} onChange={(e) => setEntryProduct(e.target.checked)} />
      </div>

      {posList.length > 0 && (
        <>
          <div className="pf-section">
            POS bazlı fiyat
            <span className="pf-section__note">Boş bırakılan POS varsayılan fiyatı kullanır.</span>
          </div>
          <table className="pf-pos">
            <thead><tr><th>POS</th><th>Alış (₺)</th><th>Satış (₺)</th></tr></thead>
            <tbody>
              {posRows.map((r) => (
                <tr key={r.posId}>
                  <td>{r.name}</td>
                  <td><input className="pf-pos__in" inputMode="decimal" value={r.purchase} onChange={(e) => setRow(r.posId, { purchase: e.target.value })} placeholder="—" /></td>
                  <td><input className="pf-pos__in" inputMode="decimal" value={r.sale} onChange={(e) => setRow(r.posId, { sale: e.target.value })} placeholder="—" /></td>
                </tr>
              ))}
            </tbody>
          </table>
        </>
      )}
    </Drawer>
  );
}
