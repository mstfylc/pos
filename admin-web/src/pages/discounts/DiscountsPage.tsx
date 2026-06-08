import { useState, type ReactNode } from "react";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { Button, DataGrid, Input, IconButton, StatusBadge, Badge, Modal, useToast, type DataGridColumn } from "@/design-system";
import { PageHeader } from "@/shell/AdminShell";
import { listDiscounts, deleteDiscount } from "@/lib/api";
import { usePagedList, type SortState } from "@/lib/usePagedList";
import { ApiError } from "@/lib/http";
import { money, fmtDate } from "@/lib/format";
import { DISCOUNT_TYPE_LABEL, DISCOUNT_CATEGORY_LABEL, DiscountTypeEnum, type DiscountDto } from "@/lib/api/types";
import { DiscountForm } from "./DiscountForm";
import "../forms.css";

const noSort = (_s: SortState): string => "";

export function DiscountsPage(): ReactNode {
  const qc = useQueryClient();
  const toast = useToast();
  const { query, page, setPage, pageSize, filter, setFilter } = usePagedList("discounts", listDiscounts, noSort);

  const [formOpen, setFormOpen] = useState(false);
  const [editing, setEditing] = useState<DiscountDto | null>(null);
  const [toDelete, setToDelete] = useState<DiscountDto | null>(null);

  const del = useMutation({
    mutationFn: (id: string) => deleteDiscount(id),
    onSuccess: () => { toast({ type: "success", title: "İndirim pasife alındı" }); setToDelete(null); void qc.invalidateQueries({ queryKey: ["discounts"] }); },
    onError: (e) => toast({ type: "error", title: "Silme başarısız", description: e instanceof ApiError ? e.message : undefined }),
  });

  function openNew(): void { setEditing(null); setFormOpen(true); }
  function openEdit(d: DiscountDto): void { setEditing(d); setFormOpen(true); }
  function onSaved(): void { toast({ type: "success", title: editing ? "İndirim güncellendi" : "İndirim oluşturuldu" }); setFormOpen(false); void qc.invalidateQueries({ queryKey: ["discounts"] }); }

  const amountText = (d: DiscountDto): string => d.discountType === DiscountTypeEnum.Percentage ? `%${d.amount}` : money(d.amount);

  const columns: DataGridColumn<DiscountDto>[] = [
    { key: "description", header: "Açıklama", render: (d) => <b style={{ color: "var(--text-heading)" }}>{d.description ?? "—"}</b> },
    { key: "type", header: "Tip", render: (d) => DISCOUNT_TYPE_LABEL[d.discountType] ?? "—" },
    { key: "scope", header: "Kapsam", render: (d) => <Badge color="secondary" variant="light" size="sm">{DISCOUNT_CATEGORY_LABEL[d.discountCategory] ?? "—"}</Badge> },
    { key: "amount", header: "Tutar/Oran", align: "right", render: (d) => amountText(d) },
    { key: "monthly", header: "Aylık limit", align: "right", render: (d) => d.monthlyLimit == null ? "—" : money(d.monthlyLimit) },
    { key: "expire", header: "Bitiş", render: (d) => fmtDate(d.expireDate) },
    { key: "status", header: "Durum", render: (d) => <StatusBadge status={d.active ? "aktif" : "pasif"} /> },
    {
      key: "actions", header: "", align: "right", width: 96,
      render: (d) => (
        <div className="pp-actions">
          <IconButton icon="notepad-edit" aria-label="Düzenle" onClick={() => openEdit(d)} />
          <IconButton icon="trash" aria-label="Sil" onClick={() => setToDelete(d)} />
        </div>
      ),
    },
  ];

  const data = query.data;

  return (
    <>
      <PageHeader crumb={["Müşteri & Sadakat", "İndirim"]} title="İndirimler" desc="İndirim kuralları · kapsam, tip, aylık limit" actions={<Button color="accent" iconStart="plus-squared" onClick={openNew}>Yeni indirim</Button>} />

      <div className="as-filter">
        <Input iconLead="magnifier" placeholder="Açıklama ara…" value={filter} onChange={(e) => setFilter(e.target.value)} style={{ width: 300 }} />
        <div className="as-filter__sp" />
        <span className="pp-count">{data ? `${data.totalCount} indirim` : ""}</span>
      </div>

      <DataGrid<DiscountDto>
        columns={columns}
        rows={data?.items ?? []}
        rowKey={(d) => d.id}
        loading={query.isLoading}
        error={query.isError ? (query.error instanceof ApiError ? query.error.message : "İndirimler yüklenemedi.") : null}
        onRetry={() => void query.refetch()}
        empty={{ icon: "price-tag", title: filter ? "Eşleşen indirim yok" : "Henüz indirim yok", subtitle: filter ? "Aramayı değiştirin." : "İlk indirimi ekleyin.", action: <Button color="accent" iconStart="plus-squared" onClick={openNew}>Yeni indirim</Button> }}
        page={page}
        pageSize={pageSize}
        total={data?.totalCount ?? 0}
        onPageChange={setPage}
      />

      {formOpen && <DiscountForm open={formOpen} onClose={() => setFormOpen(false)} discount={editing} onSaved={onSaved} />}

      <Modal open={toDelete !== null} onClose={() => setToDelete(null)} tone="danger" icon="trash" title="İndirimi sil"
        subtitle={toDelete ? `"${toDelete.description ?? "İndirim"}" pasife alınacak.` : ""}
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
