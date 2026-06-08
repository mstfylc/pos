import { useState, type ReactNode } from "react";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { Button, DataGrid, Input, IconButton, StatusBadge, Modal, useToast, type DataGridColumn } from "@/design-system";
import { PageHeader } from "@/shell/AdminShell";
import { listCampaigns, deleteCampaign } from "@/lib/api";
import { usePagedList, type SortState } from "@/lib/usePagedList";
import { ApiError } from "@/lib/http";
import { money, fmtDate } from "@/lib/format";
import { CAMPAIGN_TYPE_LABEL, type CampaignDto } from "@/lib/api/types";
import { CampaignForm } from "./CampaignForm";
import "../forms.css";

function campaignSort(s: SortState): string {
  if (s.key === "priority") return s.dir === "desc" ? "priority_desc" : "priority";
  if (s.key === "name") return s.dir === "desc" ? "name_desc" : "name";
  return "";
}

export function CampaignsPage(): ReactNode {
  const qc = useQueryClient();
  const toast = useToast();
  const { query, page, setPage, pageSize, filter, setFilter, sort, setSort } = usePagedList("campaigns", listCampaigns, campaignSort);

  const [formOpen, setFormOpen] = useState(false);
  const [editing, setEditing] = useState<CampaignDto | null>(null);
  const [toDelete, setToDelete] = useState<CampaignDto | null>(null);

  const del = useMutation({
    mutationFn: (id: string) => deleteCampaign(id),
    onSuccess: () => { toast({ type: "success", title: "Kampanya pasife alındı" }); setToDelete(null); void qc.invalidateQueries({ queryKey: ["campaigns"] }); },
    onError: (e) => toast({ type: "error", title: "Silme başarısız", description: e instanceof ApiError ? e.message : undefined }),
  });

  function openNew(): void { setEditing(null); setFormOpen(true); }
  function openEdit(c: CampaignDto): void { setEditing(c); setFormOpen(true); }
  function onSaved(): void { toast({ type: "success", title: editing ? "Kampanya güncellendi" : "Kampanya oluşturuldu" }); setFormOpen(false); void qc.invalidateQueries({ queryKey: ["campaigns"] }); }

  const columns: DataGridColumn<CampaignDto>[] = [
    { key: "name", header: "Kampanya", sortable: true, render: (c) => <b style={{ color: "var(--text-heading)" }}>{c.name}</b> },
    { key: "type", header: "Tip", render: (c) => CAMPAIGN_TYPE_LABEL[c.campaignType] ?? "—" },
    { key: "priority", header: "Öncelik", align: "right", sortable: true, render: (c) => c.priority },
    { key: "max", header: "Maks. indirim", align: "right", render: (c) => c.maxTotalDiscount == null ? "—" : money(c.maxTotalDiscount) },
    { key: "dates", header: "Tarih", render: (c) => `${fmtDate(c.startsAt)} – ${fmtDate(c.endsAt)}` },
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

  const data = query.data;

  return (
    <>
      <PageHeader crumb={["Müşteri & Sadakat", "Kampanya"]} title="Kampanyalar" desc="Kampanya kuralları · tip, öncelik, tarih, seviye" actions={<Button color="accent" iconStart="plus-squared" onClick={openNew}>Yeni kampanya</Button>} />

      <div className="as-filter">
        <Input iconLead="magnifier" placeholder="Kampanya ara…" value={filter} onChange={(e) => setFilter(e.target.value)} style={{ width: 300 }} />
        <div className="as-filter__sp" />
        <span className="pp-count">{data ? `${data.totalCount} kampanya` : ""}</span>
      </div>

      <DataGrid<CampaignDto>
        columns={columns}
        rows={data?.items ?? []}
        rowKey={(c) => c.id}
        loading={query.isLoading}
        error={query.isError ? (query.error instanceof ApiError ? query.error.message : "Kampanyalar yüklenemedi.") : null}
        onRetry={() => void query.refetch()}
        empty={{ icon: "rocket", title: filter ? "Eşleşen kampanya yok" : "Henüz kampanya yok", subtitle: filter ? "Aramayı değiştirin." : "İlk kampanyayı ekleyin.", action: <Button color="accent" iconStart="plus-squared" onClick={openNew}>Yeni kampanya</Button> }}
        sort={sort}
        onSortChange={setSort}
        page={page}
        pageSize={pageSize}
        total={data?.totalCount ?? 0}
        onPageChange={setPage}
      />

      {formOpen && <CampaignForm open={formOpen} onClose={() => setFormOpen(false)} campaign={editing} onSaved={onSaved} />}

      <Modal open={toDelete !== null} onClose={() => setToDelete(null)} tone="danger" icon="trash" title="Kampanyayı sil"
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
