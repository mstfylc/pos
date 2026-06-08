import { useState, type ReactNode } from "react";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { Button, DataGrid, Input, IconButton, StatusBadge, Badge, Modal, useToast, type DataGridColumn } from "@/design-system";
import { PageHeader } from "@/shell/AdminShell";
import { listProducts, listCategories, listPos, deleteProduct } from "@/lib/api";
import { usePagedList, type SortState } from "@/lib/usePagedList";
import { ApiError } from "@/lib/http";
import { TAX_LABEL, UNIT_LABEL, type ProductDto } from "@/lib/api/types";
import { ProductForm } from "./ProductForm";
import "./ProductsPage.css";

function money(v: number | null | undefined): string {
  if (v == null) return "—";
  return `${v.toLocaleString("tr-TR", { minimumFractionDigits: 2, maximumFractionDigits: 2 })} ₺`;
}

// DataGrid sort → backend sort string (EfCoreCrudStore.ListProductsAsync)
function productSort(s: SortState): string {
  if (s.key === "salePrice") return s.dir === "desc" ? "sale_price_desc" : "sale_price";
  if (s.key === "status") return s.dir === "desc" ? "active_desc" : "active";
  if (s.key === "name") return s.dir === "desc" ? "name_desc" : "";
  return "";
}

export function ProductsPage(): ReactNode {
  const qc = useQueryClient();
  const toast = useToast();
  const { query, page, setPage, pageSize, filter, setFilter, sort, setSort } = usePagedList("products", listProducts, productSort);

  const categories = useQuery({ queryKey: ["categories"], queryFn: listCategories });
  const pos = useQuery({ queryKey: ["pos"], queryFn: listPos });

  const [formOpen, setFormOpen] = useState(false);
  const [editing, setEditing] = useState<ProductDto | null>(null);
  const [toDelete, setToDelete] = useState<ProductDto | null>(null);

  const catName = (id: string): string => (categories.data ?? []).find((c) => c.id === id)?.name ?? "—";

  const del = useMutation({
    mutationFn: (id: string) => deleteProduct(id),
    onSuccess: () => {
      toast({ type: "success", title: "Ürün pasife alındı" });
      setToDelete(null);
      void qc.invalidateQueries({ queryKey: ["products"] });
    },
    onError: (e) => toast({ type: "error", title: "Silme başarısız", description: e instanceof ApiError ? e.message : undefined }),
  });

  function openNew(): void { setEditing(null); setFormOpen(true); }
  function openEdit(p: ProductDto): void { setEditing(p); setFormOpen(true); }
  function onSaved(): void {
    toast({ type: "success", title: editing ? "Ürün güncellendi" : "Ürün oluşturuldu" });
    setFormOpen(false);
    void qc.invalidateQueries({ queryKey: ["products"] });
  }

  const columns: DataGridColumn<ProductDto>[] = [
    {
      key: "name", header: "Ürün", sortable: true,
      render: (p) => (
        <div className="pp-name">
          <b>{p.name}</b>
          <div className="pp-name__tags">
            {p.favoriteProduct && <Badge color="warning" variant="light" size="sm">Favori</Badge>}
            {p.entryProduct && <Badge color="info" variant="light" size="sm">Giriş</Badge>}
            {p.stockCode && <span className="pp-sku">{p.stockCode}</span>}
          </div>
        </div>
      ),
    },
    { key: "category", header: "Kategori", render: (p) => catName(p.categoryId) },
    { key: "unit", header: "Birim", render: (p) => UNIT_LABEL[p.productUnitType] ?? "—" },
    { key: "tax", header: "KDV", render: (p) => TAX_LABEL[p.taxType] ?? "—" },
    { key: "salePrice", header: "Satış", align: "right", sortable: true, render: (p) => money(p.salePrice) },
    { key: "status", header: "Durum", sortable: true, render: (p) => <StatusBadge status={p.active ? "aktif" : "pasif"} /> },
    {
      key: "actions", header: "", align: "right", width: 96,
      render: (p) => (
        <div className="pp-actions">
          <IconButton icon="notepad-edit" aria-label="Düzenle" onClick={() => openEdit(p)} />
          <IconButton icon="trash" aria-label="Sil" onClick={() => setToDelete(p)} />
        </div>
      ),
    },
  ];

  const data = query.data;

  return (
    <>
      <PageHeader
        crumb={["Genel", "Ürünler"]}
        title="Ürünler"
        desc="Katalog yönetimi · sunucu-taraflı arama, sıralama, sayfalama"
        actions={<Button color="accent" iconStart="plus-squared" onClick={openNew}>Yeni ürün</Button>}
      />

      <div className="as-filter">
        <Input iconLead="magnifier" placeholder="Ürün, barkod, stok kodu…" value={filter} onChange={(e) => setFilter(e.target.value)} style={{ width: 300 }} />
        <div className="as-filter__sp" />
        <span className="pp-count">{data ? `${data.totalCount} ürün` : ""}</span>
      </div>

      <DataGrid<ProductDto>
        columns={columns}
        rows={data?.items ?? []}
        rowKey={(p) => p.id}
        loading={query.isLoading}
        error={query.isError ? (query.error instanceof ApiError ? query.error.message : "Ürünler yüklenemedi.") : null}
        onRetry={() => void query.refetch()}
        empty={{
          icon: "notepad-bookmark",
          title: filter ? "Eşleşen ürün yok" : "Henüz ürün yok",
          subtitle: filter ? "Aramayı değiştirip tekrar deneyin." : "İlk ürününü ekleyerek başla.",
          action: <Button color="accent" iconStart="plus-squared" onClick={openNew}>Yeni ürün</Button>,
        }}
        sort={sort}
        onSortChange={setSort}
        page={page}
        pageSize={pageSize}
        total={data?.totalCount ?? 0}
        onPageChange={setPage}
      />

      {formOpen && (
        <ProductForm
          open={formOpen}
          onClose={() => setFormOpen(false)}
          product={editing}
          categories={categories.data ?? []}
          posList={pos.data ?? []}
          onSaved={onSaved}
        />
      )}

      <Modal
        open={toDelete !== null}
        onClose={() => setToDelete(null)}
        tone="danger"
        icon="trash"
        title="Ürünü sil"
        subtitle={toDelete ? `"${toDelete.name}" pasife alınacak.` : ""}
        footer={
          <>
            <Button variant="light" color="dark" onClick={() => setToDelete(null)} disabled={del.isPending}>Vazgeç</Button>
            <Button color="danger" iconStart="trash" onClick={() => toDelete && del.mutate(toDelete.id)} disabled={del.isPending}>
              {del.isPending ? "Siliniyor…" : "Sil"}
            </Button>
          </>
        }
      />
    </>
  );
}
