import { useMemo, useState, type ReactNode } from "react";
import { useMutation, useQuery } from "@tanstack/react-query";
import { Drawer, Input, Button, Alert } from "@/design-system";
import { createRole, updateRole, listPermissions, setRolePermissions } from "@/lib/api";
import { getCompanyId, getUserId } from "@/lib/session";
import { ApiError } from "@/lib/http";
import type { PermissionDto, RoleDto, RoleWriteDto } from "@/lib/api/types";
import "../forms.css";

interface Props {
  open: boolean;
  onClose: () => void;
  role: RoleDto | null;
  onSaved: () => void;
}

export function RoleForm({ open, onClose, role, onSaved }: Props): ReactNode {
  const isEdit = role !== null;
  const [name, setName] = useState(role?.name ?? "");
  const [selected, setSelected] = useState<Set<string>>(new Set(role?.permissionIds ?? []));
  const [nameErr, setNameErr] = useState<string | undefined>();

  const perms = useQuery({ queryKey: ["permissions"], queryFn: listPermissions });

  const groups = useMemo(() => {
    const byType = new Map<number, PermissionDto[]>();
    for (const p of perms.data ?? []) {
      const arr = byType.get(p.permissionType) ?? [];
      arr.push(p);
      byType.set(p.permissionType, arr);
    }
    return [...byType.entries()].sort((a, b) => a[0] - b[0]);
  }, [perms.data]);

  function toggle(id: string): void {
    setSelected((s) => {
      const next = new Set(s);
      if (next.has(id)) next.delete(id); else next.add(id);
      return next;
    });
  }

  const save = useMutation({
    mutationFn: async (): Promise<void> => {
      const body: RoleWriteDto = { companyId: getCompanyId(), userId: getUserId(), name: name.trim() };
      const saved = isEdit ? await updateRole(role.id, body) : await createRole(body);
      await setRolePermissions(saved.id, [...selected]);
    },
    onSuccess: () => onSaved(),
  });

  function submit(): void {
    if (!name.trim()) { setNameErr("Rol adı zorunludur."); return; }
    setNameErr(undefined);
    save.mutate();
  }

  const errMsg = save.error instanceof ApiError ? save.error.message : save.isError ? "Kaydetme başarısız." : null;

  return (
    <Drawer
      open={open}
      onClose={onClose}
      size="lg"
      title={isEdit ? "Rolü düzenle" : "Yeni rol"}
      subtitle={isEdit ? role.name : "Rol ve yetkilerini tanımla"}
      footer={
        <>
          <Button variant="light" color="dark" onClick={onClose} disabled={save.isPending}>İptal</Button>
          <Button color="accent" iconStart="check-circle" onClick={submit} disabled={save.isPending}>
            {save.isPending ? "Kaydediliyor…" : isEdit ? "Kaydet" : "Oluştur"}
          </Button>
        </>
      }
    >
      {errMsg && <Alert color="danger" title="Hata" style={{ marginBottom: 16 }}>{errMsg}</Alert>}
      <Input label="Rol adı" required value={name} error={nameErr} onChange={(e) => setName(e.target.value)} placeholder="Örn. Şube Müdürü" />

      <div className="fm-section">Yetkiler ({selected.size} seçili)</div>
      {perms.isLoading && <div className="fm-multi__empty">Yetkiler yükleniyor…</div>}
      {perms.isError && <Alert color="danger" title="Yetkiler yüklenemedi">Tekrar deneyin.</Alert>}
      <div className="fm-perm">
        {groups.map(([type, items]) => (
          <div className="fm-perm__group" key={type}>
            <b>Yetki grubu {type}</b>
            <div className="fm-perm__items">
              {items.map((p) => (
                <label className="fm-multi__row" key={p.id}>
                  <input type="checkbox" checked={selected.has(p.id)} onChange={() => toggle(p.id)} />
                  <span>{p.displayName ?? p.name}</span>
                </label>
              ))}
            </div>
          </div>
        ))}
      </div>
    </Drawer>
  );
}
