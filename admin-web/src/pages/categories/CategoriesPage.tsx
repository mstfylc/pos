import { useMemo, useState, type ReactNode } from "react";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { Button, DataGrid, Input, IconButton, StatusBadge, Modal, useToast, type DataGridColumn } from "@/design-system";
import { PageHeader } from "@/shell/AdminShell";
import { listCategories, deleteCategory } from "@/lib/api";
import { ApiError } from "@/lib/http";
import type { CategoryDto } from "@/lib/api/types";
import { CategoryForm } from "./CategoryForm";
import "../forms.css";

export function CategoriesPage(): ReactNode {
  const qc = useQueryClient();
  const toast = useToast();
  const list = useQuery({ queryKey: ["categories"], queryFn: listCategories });

  const [q, setQ] = useState("");
  const [formOpen, setFormOpen] = useState(false);
  const [editing, setEditing] = useState<CategoryDto | null>(null);
  const [toDelete, setToDelete] = useState<CategoryDto | null>(null);

  const rows = useMemo(() => {
    const n = q.trim().toLocaleLowerCase("tr");
    const all = list.data ?? [];
    return n ? all.filter((c) => c.name.toLocaleLowerCase("tr").includes(n)) : all;
  }, [list.data, q]);

  const del = useMutation({
    mutationFn: (id: string) => deleteCategory(id),
    onSuccess: () => { toast({ type: "success", title: "Kategori pasife alındı" }); setToDelete(null); void qc.invalidateQueries({ queryKey: ["categories"] }); },
    onError: (e) => toast({ type: "error", title: "Silme başarısız", description: e instanceof ApiError ? e.message : undefined }),
  });

  function openNew(): void { setEditing(null); setFormOpen(true); }
  function openEdit(c: CategoryDto): void { setEditing(c); setFormOpen(true); }
  function onSaved(): void { toast({ type: "success", title: editing ? "Kategori güncellendi" : "Kategori oluşturuldu" }); setFormOpen(false); void qc.invalidateQueries({ queryKey: ["categories"] }); }

  const columns: DataGridColumn<CategoryDto>[] = [
    { key: "name", header: "Kategori", render: (c) => <b style={{ color: "var(--text-heading)" }}>{c.name}</b> },
    { key: "sortOrder", header: "Sıra", align: "right", render: (c) => c.sortOrder },
    { key: "status", header: "Durum", render: (c) => <StatusBadge status={c.active ? "aktif" : "pasif"} /> },
    {
      key: "actions", header: "", align: "right", width: 96,
      render: (c) => (
        <div className="pp-actions">
          <IconButton icon="notepad-edit" aria-label="Düzenle" onClick={() => openEdit(c)} />
          <IconButton icon="trash" aria-label="Sil" onClick={() => setToDelete(c)} />
        </div>
      ),
    },
  ];

  return (
    <>
      <PageHeader crumb={["Genel", "Kategoriler"]} title="Kategoriler" desc="Ürün kategorileri" actions={<Button color="accent" iconStart="plus-squared" onClick={openNew}>Yeni kategori</Button>} />

      <div className="as-filter">
        <Input iconLead="magnifier" placeholder="Kategori ara…" value={q} onChange={(e) => setQ(e.target.value)} style={{ width: 280 }} />
        <div className="as-filter__sp" />
        <span className="pp-count">{list.isSuccess ? `${rows.length} kategori` : ""}</span>
      </div>

      <DataGrid<CategoryDto>
        columns={columns}
        rows={rows}
        rowKey={(c) => c.id}
        loading={list.isLoading}
        error={list.isError ? (list.error instanceof ApiError ? list.error.message : "Kategoriler yüklenemedi.") : null}
        onRetry={() => void list.refetch()}
        empty={{ icon: "category", title: q ? "Eşleşen kategori yok" : "Henüz kategori yok", subtitle: q ? "Aramayı değiştirin." : "İlk kategoriyi ekleyin.", action: <Button color="accent" iconStart="plus-squared" onClick={openNew}>Yeni kategori</Button> }}
      />

      {formOpen && <CategoryForm open={formOpen} onClose={() => setFormOpen(false)} category={editing} onSaved={onSaved} />}

      <Modal open={toDelete !== null} onClose={() => setToDelete(null)} tone="danger" icon="trash" title="Kategoriyi sil"
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
