import { useMemo, useState, type ReactNode } from "react";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { Button, DataGrid, Input, IconButton, StatusBadge, Badge, Modal, useToast, type DataGridColumn } from "@/design-system";
import { PageHeader } from "@/shell/AdminShell";
import { listRoles, deleteRole } from "@/lib/api";
import { ApiError } from "@/lib/http";
import type { RoleDto } from "@/lib/api/types";
import { RoleForm } from "./RoleForm";
import "../forms.css";

export function RolesPage(): ReactNode {
  const qc = useQueryClient();
  const toast = useToast();
  const list = useQuery({ queryKey: ["roles"], queryFn: listRoles });

  const [q, setQ] = useState("");
  const [formOpen, setFormOpen] = useState(false);
  const [editing, setEditing] = useState<RoleDto | null>(null);
  const [toDelete, setToDelete] = useState<RoleDto | null>(null);

  const rows = useMemo(() => {
    const n = q.trim().toLocaleLowerCase("tr");
    const all = list.data ?? [];
    return n ? all.filter((r) => r.name.toLocaleLowerCase("tr").includes(n)) : all;
  }, [list.data, q]);

  const del = useMutation({
    mutationFn: (id: string) => deleteRole(id),
    onSuccess: () => { toast({ type: "success", title: "Rol pasife alındı" }); setToDelete(null); void qc.invalidateQueries({ queryKey: ["roles"] }); },
    onError: (e) => toast({ type: "error", title: "Silme başarısız", description: e instanceof ApiError ? e.message : undefined }),
  });

  function openNew(): void { setEditing(null); setFormOpen(true); }
  function openEdit(r: RoleDto): void { setEditing(r); setFormOpen(true); }
  function onSaved(): void { toast({ type: "success", title: editing ? "Rol güncellendi" : "Rol oluşturuldu" }); setFormOpen(false); void qc.invalidateQueries({ queryKey: ["roles"] }); }

  const columns: DataGridColumn<RoleDto>[] = [
    { key: "name", header: "Rol", render: (r) => <b style={{ color: "var(--text-heading)" }}>{r.name}</b> },
    { key: "perms", header: "Yetki", render: (r) => <Badge color="primary" variant="light" size="sm">{r.permissionIds.length} yetki</Badge> },
    { key: "status", header: "Durum", render: (r) => <StatusBadge status={r.active ? "aktif" : "pasif"} /> },
    {
      key: "actions", header: "", align: "right", width: 96,
      render: (r) => (
        <div className="pp-actions">
          <IconButton icon="notepad-edit" aria-label="Düzenle" onClick={() => openEdit(r)} />
          <IconButton icon="trash" aria-label="Sil" onClick={() => setToDelete(r)} />
        </div>
      ),
    },
  ];

  return (
    <>
      <PageHeader crumb={["Yönetim", "Roller & Yetkiler"]} title="Roller & Yetkiler" desc="Rol tanımları ve yetki matrisi" actions={<Button color="accent" iconStart="plus-squared" onClick={openNew}>Yeni rol</Button>} />

      <div className="as-filter">
        <Input iconLead="magnifier" placeholder="Rol ara…" value={q} onChange={(e) => setQ(e.target.value)} style={{ width: 280 }} />
        <div className="as-filter__sp" />
        <span className="pp-count">{list.isSuccess ? `${rows.length} rol` : ""}</span>
      </div>

      <DataGrid<RoleDto>
        columns={columns}
        rows={rows}
        rowKey={(r) => r.id}
        loading={list.isLoading}
        error={list.isError ? (list.error instanceof ApiError ? list.error.message : "Roller yüklenemedi.") : null}
        onRetry={() => void list.refetch()}
        empty={{ icon: "key", title: q ? "Eşleşen rol yok" : "Henüz rol yok", subtitle: q ? "Aramayı değiştirin." : "İlk rolü ekleyin.", action: <Button color="accent" iconStart="plus-squared" onClick={openNew}>Yeni rol</Button> }}
      />

      {formOpen && <RoleForm open={formOpen} onClose={() => setFormOpen(false)} role={editing} onSaved={onSaved} />}

      <Modal open={toDelete !== null} onClose={() => setToDelete(null)} tone="danger" icon="trash" title="Rolü sil"
        subtitle={toDelete ? `"${toDelete.name}" pasife alınacak.` : ""}
        footer={
          <>
            <Button variant="light" color="dark" onClick={() => setToDelete(null)} disabled={del.isPending}>Vazgeç</Button>
            <Button color="danger" iconStart="trash" onClick={() => toDelete && del.mutate(toDelete.id)} disabled={del.isPending}>{del.isPending ? "Siliniyor…" : "Sil"}</Button>
          </>
        }
      />
    </>
  );
}
