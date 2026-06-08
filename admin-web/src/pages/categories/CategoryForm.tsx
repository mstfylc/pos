import { useState, type ReactNode } from "react";
import { useMutation } from "@tanstack/react-query";
import { Drawer, Input, Button, Alert } from "@/design-system";
import { createCategory, updateCategory } from "@/lib/api";
import { getCompanyId, getUserId } from "@/lib/session";
import { ApiError } from "@/lib/http";
import type { CategoryDto, CategoryWriteDto } from "@/lib/api/types";
import "../forms.css";

interface Props {
  open: boolean;
  onClose: () => void;
  category: CategoryDto | null;
  onSaved: () => void;
}

export function CategoryForm({ open, onClose, category, onSaved }: Props): ReactNode {
  const isEdit = category !== null;
  const [name, setName] = useState(category?.name ?? "");
  const [sortOrder, setSortOrder] = useState(String(category?.sortOrder ?? 0));
  // Renk/şekil: kontratta lookup ucu YOK (yalnız DB seed). Manuel UUID girilir.
  const [colorId, setColorId] = useState("");
  const [shapeId, setShapeId] = useState("");
  const [err, setErr] = useState<{ name?: string; colorId?: string; shapeId?: string }>({});

  const save = useMutation({
    mutationFn: async () => {
      const body: CategoryWriteDto = {
        companyId: getCompanyId(),
        userId: getUserId(),
        name: name.trim(),
        sortOrder: Number.parseInt(sortOrder, 10) || 0,
        categoryColorId: colorId.trim(),
        categoryShapeId: shapeId.trim(),
      };
      return isEdit ? updateCategory(category.id, body) : createCategory(body);
    },
    onSuccess: () => onSaved(),
  });

  function submit(): void {
    const e: typeof err = {};
    if (!name.trim()) e.name = "Kategori adı zorunludur.";
    if (!colorId.trim()) e.colorId = "Renk ID zorunludur.";
    if (!shapeId.trim()) e.shapeId = "Şekil ID zorunludur.";
    setErr(e);
    if (Object.keys(e).length) return;
    save.mutate();
  }

  const errMsg = save.error instanceof ApiError ? save.error.message : save.isError ? "Kaydetme başarısız." : null;

  return (
    <Drawer
      open={open}
      onClose={onClose}
      size="md"
      title={isEdit ? "Kategoriyi düzenle" : "Yeni kategori"}
      subtitle={isEdit ? category.name : "Yeni kategori ekle"}
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
      <div className="fm-grid">
        <Input label="Kategori adı" required value={name} error={err.name} onChange={(e) => setName(e.target.value)} placeholder="Örn. Espresso Bazlı" />
        <Input label="Sıra" type="number" value={sortOrder} onChange={(e) => setSortOrder(e.target.value)} />
      </div>

      <div className="fm-section">
        Renk & Şekil
        <span className="fm-section__note">Kontratta renk/şekil lookup ucu yok — UUID elle girilir (DB seed değeri).</span>
      </div>
      <div className="fm-grid">
        <Input label="Renk ID (UUID)" required value={colorId} error={err.colorId} onChange={(e) => setColorId(e.target.value)} placeholder="00000000-…" />
        <Input label="Şekil ID (UUID)" required value={shapeId} error={err.shapeId} onChange={(e) => setShapeId(e.target.value)} placeholder="00000000-…" />
      </div>
    </Drawer>
  );
}
