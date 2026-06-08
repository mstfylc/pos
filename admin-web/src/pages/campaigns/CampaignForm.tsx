import { useState, type ReactNode } from "react";
import { useMutation, useQuery } from "@tanstack/react-query";
import { Drawer, Input, Select, Textarea, Switch, Button, Alert } from "@/design-system";
import { createCampaign, updateCampaign, listLoyaltyTiers } from "@/lib/api";
import { getCompanyId, getUserId } from "@/lib/session";
import { ApiError } from "@/lib/http";
import { parseDec, decStr, toIso, toLocalInput } from "@/lib/format";
import { CampaignTypeEnum, CAMPAIGN_TYPE_LABEL } from "@/lib/api/types";
import type { CampaignDto, CampaignWriteDto } from "@/lib/api/types";
import "../forms.css";

interface Props {
  open: boolean;
  onClose: () => void;
  campaign: CampaignDto | null;
  onSaved: () => void;
}

export function CampaignForm({ open, onClose, campaign, onSaved }: Props): ReactNode {
  const isEdit = campaign !== null;
  const tiers = useQuery({ queryKey: ["loyalty-tiers"], queryFn: listLoyaltyTiers });

  const [name, setName] = useState(campaign?.name ?? "");
  const [description, setDescription] = useState(campaign?.description ?? "");
  const [campaignType, setCampaignType] = useState<number>(campaign?.campaignType ?? CampaignTypeEnum.ExtraPoints);
  const [ruleJson, setRuleJson] = useState(campaign?.ruleJson ?? "{}");
  const [priority, setPriority] = useState(String(campaign?.priority ?? 0));
  const [maxTotalDiscount, setMaxTotalDiscount] = useState(decStr(campaign?.maxTotalDiscount));
  const [targetTierId, setTargetTierId] = useState(campaign?.targetTierId ?? "");
  const [startsAt, setStartsAt] = useState(toLocalInput(campaign?.startsAt));
  const [endsAt, setEndsAt] = useState(toLocalInput(campaign?.endsAt));
  const [active, setActive] = useState(campaign?.active ?? true);
  const [err, setErr] = useState<{ name?: string; ruleJson?: string }>({});

  const save = useMutation({
    mutationFn: () => {
      const body: CampaignWriteDto = {
        companyId: getCompanyId(),
        userId: getUserId(),
        name: name.trim(),
        description: description.trim() || null,
        campaignType,
        ruleJson: ruleJson.trim() || "{}",
        priority: Number.parseInt(priority, 10) || 0,
        maxTotalDiscount: parseDec(maxTotalDiscount),
        targetTierId: targetTierId || null,
        startsAt: toIso(startsAt),
        endsAt: toIso(endsAt),
        active,
      };
      return isEdit ? updateCampaign(campaign.id, body) : createCampaign(body);
    },
    onSuccess: () => onSaved(),
  });

  function submit(): void {
    const e: typeof err = {};
    if (!name.trim()) e.name = "Kampanya adı zorunludur.";
    try { JSON.parse(ruleJson.trim() || "{}"); } catch { e.ruleJson = "Geçerli JSON girin."; }
    setErr(e);
    if (Object.keys(e).length) return;
    save.mutate();
  }

  const errMsg = save.error instanceof ApiError ? save.error.message : save.isError ? "Kaydetme başarısız." : null;

  return (
    <Drawer
      open={open} onClose={onClose} size="lg"
      title={isEdit ? "Kampanyayı düzenle" : "Yeni kampanya"}
      subtitle={isEdit ? campaign.name : "Kampanya kuralı tanımla"}
      footer={
        <>
          <Button variant="light" color="dark" onClick={onClose} disabled={save.isPending}>İptal</Button>
          <Button color="accent" iconStart="check-circle" onClick={submit} disabled={save.isPending}>{save.isPending ? "Kaydediliyor…" : isEdit ? "Kaydet" : "Oluştur"}</Button>
        </>
      }
    >
      {errMsg && <Alert color="danger" title="Hata" style={{ marginBottom: 16 }}>{errMsg}</Alert>}
      <div className="fm-grid">
        <Input label="Kampanya adı" required value={name} error={err.name} onChange={(e) => setName(e.target.value)} placeholder="Örn. Hafta sonu kahve" />
        <Select label="Tip" value={campaignType} onChange={(e) => setCampaignType(Number(e.target.value))}>
          {Object.entries(CAMPAIGN_TYPE_LABEL).map(([v, l]) => <option key={v} value={v}>{l}</option>)}
        </Select>
        <Input label="Öncelik" type="number" value={priority} onChange={(e) => setPriority(e.target.value)} />
        <Input label="Maks. toplam indirim (₺)" inputMode="decimal" value={maxTotalDiscount} onChange={(e) => setMaxTotalDiscount(e.target.value)} placeholder="Boş = limitsiz" />
        <Select label="Hedef sadakat seviyesi" value={targetTierId} onChange={(e) => setTargetTierId(e.target.value)}>
          <option value="">Tümü</option>
          {(tiers.data ?? []).map((t) => <option key={t.id} value={t.id}>{t.name}</option>)}
        </Select>
        <Input label="Başlangıç" type="datetime-local" value={startsAt} onChange={(e) => setStartsAt(e.target.value)} />
        <Input label="Bitiş" type="datetime-local" value={endsAt} onChange={(e) => setEndsAt(e.target.value)} />
        <div className="fm-col2"><Textarea label="Açıklama" rows={2} value={description} onChange={(e) => setDescription(e.target.value)} /></div>
        <div className="fm-col2"><Textarea label="Kural (JSON)" rows={4} value={ruleJson} error={err.ruleJson} onChange={(e) => setRuleJson(e.target.value)} placeholder='{"minTotal": 100}' /></div>
      </div>

      <div className="fm-switches" style={{ marginTop: 14 }}>
        <Switch label="Aktif" checked={active} onChange={(e) => setActive(e.target.checked)} />
      </div>
    </Drawer>
  );
}
