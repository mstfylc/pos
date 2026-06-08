/* Üretilen OpenAPI client'tan (@mansis/api-client-ts) tip alias'ları.
   API tipi ELLE YAZILMAZ (CLAUDE.md §1) — hepsi kontrattan türetilir.
   Not: enum'lar kontratta integer; aşağıdaki sabitler backend enum sırasıyla birebir. */
import type { components } from "@mansis/api-client-ts";

type S = components["schemas"];

export type ProductDto = S["ProductDto"];
export type ProductWriteDto = S["ProductWriteDto"];
export type PosProductDto = S["PosProductDto"];
export type PosProductWriteDto = S["PosProductWriteDto"];
export type CategoryDto = S["CategoryDto"];
export type CategoryWriteDto = S["CategoryWriteDto"];
export type UserDto = S["UserDto"];
export type UserWriteDto = S["UserWriteDto"];
export type RoleDto = S["RoleDto"];
export type RoleWriteDto = S["RoleWriteDto"];
export type RolePermissionWriteDto = S["RolePermissionWriteDto"];
export type PermissionDto = S["PermissionDto"];
export type DiscountDto = S["DiscountDto"];
export type DiscountWriteDto = S["DiscountWriteDto"];
export type CampaignDto = S["CampaignDto"];
export type CampaignWriteDto = S["CampaignWriteDto"];
export type PosDto = S["PosDto"];
export type StoreDto = S["StoreDto"];
export type LoyaltyTierDto = S["LoyaltyTierDto"];
export type AuthTokenResult = S["AuthTokenResult"];
export type ProblemDetails = S["ProblemDetails"];

export interface PagedResult<T> {
  items: T[];
  page: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
}

/* ---- Enum sabitleri (backend LegacyEnums sırası) ---- */
export const ProductUnit = { Adet: 0, MiliLitre: 1, Gram: 2 } as const;
export const Tax = { Sifir: 0, Bir: 1, Sekiz: 2, OnSekiz: 3 } as const;
export const CampaignTypeEnum = { ExtraPoints: 0, DiscountAmount: 1, Stamp: 2 } as const;
export const DiscountTypeEnum = { Percentage: 0, Amount: 1 } as const;
export const DiscountCategoryEnum = { All: 0, Branch: 1, Personnel: 2, Pos: 3 } as const;

export const UNIT_LABEL: Record<number, string> = { 0: "Adet", 1: "ml", 2: "gr" };
export const TAX_LABEL: Record<number, string> = { 0: "%0", 1: "%1", 2: "%8", 3: "%18" };
export const CAMPAIGN_TYPE_LABEL: Record<number, string> = { 0: "Ekstra Puan", 1: "İndirim Tutarı", 2: "Damga" };
export const DISCOUNT_TYPE_LABEL: Record<number, string> = { 0: "Yüzde (%)", 1: "Tutar (₺)" };
export const DISCOUNT_CATEGORY_LABEL: Record<number, string> = { 0: "Tümü", 1: "Şube", 2: "Personel", 3: "POS" };
