import { useState, type ReactNode } from "react";
import { useMutation, useQuery } from "@tanstack/react-query";
import { Drawer, Input, Select, Switch, Button, Alert } from "@/design-system";
import { MultiSelect } from "../MultiSelect";
import { createUser, updateUser, listRoles, listStores, listPos } from "@/lib/api";
import { getCompanyId, getUserId } from "@/lib/session";
import { ApiError } from "@/lib/http";
import type { UserDto, UserWriteDto } from "@/lib/api/types";
import "../forms.css";

interface Props {
  open: boolean;
  onClose: () => void;
  user: UserDto | null;
  onSaved: () => void;
}

function useSet(initial: string[]): [Set<string>, (id: string) => void] {
  const [s, setS] = useState<Set<string>>(new Set(initial));
  const toggle = (id: string): void => setS((prev) => {
    const next = new Set(prev);
    if (next.has(id)) next.delete(id); else next.add(id);
    return next;
  });
  return [s, toggle];
}

export function UserForm({ open, onClose, user, onSaved }: Props): ReactNode {
  const isEdit = user !== null;
  const roles = useQuery({ queryKey: ["roles"], queryFn: listRoles });
  const stores = useQuery({ queryKey: ["stores"], queryFn: listStores });
  const pos = useQuery({ queryKey: ["pos"], queryFn: listPos });

  const [firstName, setFirstName] = useState(user?.firstName ?? "");
  const [lastName, setLastName] = useState(user?.lastName ?? "");
  const [username, setUsername] = useState(user?.username ?? "");
  const [mail, setMail] = useState(user?.mail ?? "");
  const [phone, setPhone] = useState(user?.phone ?? "");
  const [roleId, setRoleId] = useState(user?.roleId ?? "");
  const [pin, setPin] = useState(user?.pin ?? "");
  const [password, setPassword] = useState("");
  const [mustChange, setMustChange] = useState(user?.mustChangePassword ?? true);
  const [storeIds, toggleStore] = useSet(user?.storeIds ?? []);
  const [posIds, togglePos] = useSet(user?.posIds ?? []);

  const [err, setErr] = useState<{ firstName?: string; lastName?: string; username?: string; roleId?: string }>({});

  const save = useMutation({
    mutationFn: () => {
      const body: UserWriteDto = {
        companyId: getCompanyId(),
        userId: getUserId(),
        firstName: firstName.trim(),
        lastName: lastName.trim(),
        username: username.trim(),
        phone: phone.trim() || null,
        mail: mail.trim() || null,
        roleId,
        cardId: user?.cardId ?? null,
        pin: pin.trim() || null,
        password: password.trim() || null,
        mustChangePassword: mustChange,
        branchIds: user?.branchIds ?? [],
        posIds: [...posIds],
        storeIds: [...storeIds],
      };
      return isEdit ? updateUser(user.id, body) : createUser(body);
    },
    onSuccess: () => onSaved(),
  });

  function submit(): void {
    const e: typeof err = {};
    if (!firstName.trim()) e.firstName = "Ad zorunludur.";
    if (!lastName.trim()) e.lastName = "Soyad zorunludur.";
    if (!username.trim()) e.username = "Kullanıcı adı zorunludur.";
    if (!roleId) e.roleId = "Rol seçiniz.";
    setErr(e);
    if (Object.keys(e).length) return;
    save.mutate();
  }

  const errMsg = save.error instanceof ApiError ? save.error.message : save.isError ? "Kaydetme başarısız." : null;

  return (
    <Drawer
      open={open} onClose={onClose} size="lg"
      title={isEdit ? "Kullanıcıyı düzenle" : "Yeni kullanıcı"}
      subtitle={isEdit ? `${user.firstName} ${user.lastName}` : "Personel hesabı oluştur"}
      footer={
        <>
          <Button variant="light" color="dark" onClick={onClose} disabled={save.isPending}>İptal</Button>
          <Button color="accent" iconStart="check-circle" onClick={submit} disabled={save.isPending}>{save.isPending ? "Kaydediliyor…" : isEdit ? "Kaydet" : "Oluştur"}</Button>
        </>
      }
    >
      {errMsg && <Alert color="danger" title="Hata" style={{ marginBottom: 16 }}>{errMsg}</Alert>}
      <div className="fm-grid">
        <Input label="Ad" required value={firstName} error={err.firstName} onChange={(e) => setFirstName(e.target.value)} />
        <Input label="Soyad" required value={lastName} error={err.lastName} onChange={(e) => setLastName(e.target.value)} />
        <Input label="Kullanıcı adı" required value={username} error={err.username} onChange={(e) => setUsername(e.target.value)} />
        <Select label="Rol" required value={roleId} error={err.roleId} onChange={(e) => setRoleId(e.target.value)}>
          <option value="">Seçiniz…</option>
          {(roles.data ?? []).map((r) => <option key={r.id} value={r.id}>{r.name}</option>)}
        </Select>
        <Input label="E-posta" type="email" value={mail} onChange={(e) => setMail(e.target.value)} />
        <Input label="Telefon" value={phone} onChange={(e) => setPhone(e.target.value)} />
        <Input label="PIN" value={pin} onChange={(e) => setPin(e.target.value)} placeholder="POS PIN" />
        <Input label={isEdit ? "Yeni parola (boş=değişmez)" : "Parola"} type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
      </div>

      <div className="fm-switches" style={{ marginTop: 14 }}>
        <Switch label="İlk girişte parola değiştir" checked={mustChange} onChange={(e) => setMustChange(e.target.checked)} />
      </div>

      <div className="fm-section">Depo erişimi</div>
      <MultiSelect options={(stores.data ?? []).map((s) => ({ id: s.id, label: s.name }))} selected={storeIds} onToggle={toggleStore} emptyText="Depo yok." />

      <div className="fm-section">POS erişimi</div>
      <MultiSelect options={(pos.data ?? []).map((p) => ({ id: p.id, label: p.name }))} selected={posIds} onToggle={togglePos} emptyText="POS yok." />
    </Drawer>
  );
}
