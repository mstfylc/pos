import { useState, type ReactNode } from "react";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { Button, DataGrid, Input, IconButton, StatusBadge, Modal, useToast, type DataGridColumn } from "@/design-system";
import { PageHeader } from "@/shell/AdminShell";
import { listUsers, deleteUser, listRoles } from "@/lib/api";
import { usePagedList, type SortState } from "@/lib/usePagedList";
import { ApiError } from "@/lib/http";
import type { UserDto } from "@/lib/api/types";
import { UserForm } from "./UserForm";
import "../forms.css";

function userSort(s: SortState): string {
  if (s.key === "username") return s.dir === "desc" ? "username_desc" : "username";
  if (s.key === "name") return s.dir === "desc" ? "name_desc" : "";
  return "";
}

export function UsersPage(): ReactNode {
  const qc = useQueryClient();
  const toast = useToast();
  const { query, page, setPage, pageSize, filter, setFilter, sort, setSort } = usePagedList("users", listUsers, userSort);
  const roles = useQuery({ queryKey: ["roles"], queryFn: listRoles });

  const [formOpen, setFormOpen] = useState(false);
  const [editing, setEditing] = useState<UserDto | null>(null);
  const [toDelete, setToDelete] = useState<UserDto | null>(null);

  const roleName = (id: string): string => (roles.data ?? []).find((r) => r.id === id)?.name ?? "—";

  const del = useMutation({
    mutationFn: (id: string) => deleteUser(id),
    onSuccess: () => { toast({ type: "success", title: "Kullanıcı pasife alındı" }); setToDelete(null); void qc.invalidateQueries({ queryKey: ["users"] }); },
    onError: (e) => toast({ type: "error", title: "Silme başarısız", description: e instanceof ApiError ? e.message : undefined }),
  });

  function openNew(): void { setEditing(null); setFormOpen(true); }
  function openEdit(u: UserDto): void { setEditing(u); setFormOpen(true); }
  function onSaved(): void { toast({ type: "success", title: editing ? "Kullanıcı güncellendi" : "Kullanıcı oluşturuldu" }); setFormOpen(false); void qc.invalidateQueries({ queryKey: ["users"] }); }

  const columns: DataGridColumn<UserDto>[] = [
    { key: "name", header: "Ad Soyad", sortable: true, render: (u) => <b style={{ color: "var(--text-heading)" }}>{u.firstName} {u.lastName}</b> },
    { key: "username", header: "Kullanıcı adı", sortable: true, render: (u) => u.username },
    { key: "role", header: "Rol", render: (u) => roleName(u.roleId) },
    { key: "mail", header: "E-posta", render: (u) => u.mail ?? "—" },
    { key: "status", header: "Durum", render: (u) => <StatusBadge status={u.active ? "aktif" : "pasif"} /> },
    {
      key: "actions", header: "", align: "right", width: 96,
      render: (u) => (
        <div className="pp-actions">
          <IconButton icon="notepad-edit" aria-label="Düzenle" onClick={() => openEdit(u)} />
          <IconButton icon="trash" aria-label="Sil" onClick={() => setToDelete(u)} />
        </div>
      ),
    },
  ];

  const data = query.data;

  return (
    <>
      <PageHeader crumb={["Yönetim", "Kullanıcılar"]} title="Kullanıcılar" desc="Personel hesapları · sunucu-taraflı liste" actions={<Button color="accent" iconStart="plus-squared" onClick={openNew}>Yeni kullanıcı</Button>} />

      <div className="as-filter">
        <Input iconLead="magnifier" placeholder="Ad, kullanıcı adı…" value={filter} onChange={(e) => setFilter(e.target.value)} style={{ width: 300 }} />
        <div className="as-filter__sp" />
        <span className="pp-count">{data ? `${data.totalCount} kullanıcı` : ""}</span>
      </div>

      <DataGrid<UserDto>
        columns={columns}
        rows={data?.items ?? []}
        rowKey={(u) => u.id}
        loading={query.isLoading}
        error={query.isError ? (query.error instanceof ApiError ? query.error.message : "Kullanıcılar yüklenemedi.") : null}
        onRetry={() => void query.refetch()}
        empty={{ icon: "people", title: filter ? "Eşleşen kullanıcı yok" : "Henüz kullanıcı yok", subtitle: filter ? "Aramayı değiştirin." : "İlk kullanıcıyı ekleyin.", action: <Button color="accent" iconStart="plus-squared" onClick={openNew}>Yeni kullanıcı</Button> }}
        sort={sort}
        onSortChange={setSort}
        page={page}
        pageSize={pageSize}
        total={data?.totalCount ?? 0}
        onPageChange={setPage}
      />

      {formOpen && <UserForm open={formOpen} onClose={() => setFormOpen(false)} user={editing} onSaved={onSaved} />}

      <Modal open={toDelete !== null} onClose={() => setToDelete(null)} tone="danger" icon="trash" title="Kullanıcıyı sil"
        subtitle={toDelete ? `"${toDelete.firstName} ${toDelete.lastName}" pasife alınacak.` : ""}
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
