/* Endpoint fonksiyonları — yalnızca kontratta TANIMLI uçlar.
   Path/method/DTO openapi.yaml ile birebir; tipler üretilen client'tan. */
import { http } from "../http";
import { getCompanyId, getUserId, setSession } from "../session";
import type {
  AuthTokenResult,
  CampaignDto,
  CampaignWriteDto,
  CategoryDto,
  CategoryWriteDto,
  DiscountDto,
  DiscountWriteDto,
  LoyaltyTierDto,
  PagedResult,
  PermissionDto,
  PosDto,
  PosProductDto,
  PosProductWriteDto,
  ProductDto,
  ProductWriteDto,
  RoleDto,
  RolePermissionWriteDto,
  RoleWriteDto,
  StoreDto,
  UserDto,
  UserWriteDto,
} from "./types";

/** Sunucu-taraflı liste parametreleri */
export interface ListQuery {
  page: number;
  pageSize: number;
  sort?: string;
  filter?: string;
}

function paged(q: ListQuery): Record<string, string | number | undefined> {
  return { companyId: getCompanyId(), page: q.page, pageSize: q.pageSize, sort: q.sort || undefined, filter: q.filter || undefined };
}

function scope(): { companyId: string; userId: string } {
  return { companyId: getCompanyId(), userId: getUserId() };
}

/* ---- Auth ---- */
export async function login(companyId: string, username: string, password: string): Promise<AuthTokenResult> {
  const result = await http.post<AuthTokenResult>("/api/v1/auth/login", { companyId, username, password }, { anonymous: true });
  setSession(result);
  return result;
}

/* ---- Products (sunucu-taraflı sayfalı) ---- */
export function listProducts(q: ListQuery): Promise<PagedResult<ProductDto>> {
  return http.get<PagedResult<ProductDto>>("/api/v1/admin/products", paged(q));
}
export function createProduct(body: ProductWriteDto): Promise<ProductDto> {
  return http.post<ProductDto>("/api/v1/admin/products", body);
}
export function updateProduct(id: string, body: ProductWriteDto): Promise<ProductDto> {
  return http.put<ProductDto>(`/api/v1/admin/products/${id}`, body);
}
export function deleteProduct(id: string): Promise<void> {
  return http.del<void>(`/api/v1/admin/products/${id}`, scope());
}

/* ---- POS bazlı fiyat ---- */
export function listPosProductsForProduct(productId: string): Promise<PosProductDto[]> {
  return http.get<PosProductDto[]>(`/api/v1/admin/products/${productId}/pos-products`, { companyId: getCompanyId() });
}
export function createPosProduct(body: PosProductWriteDto): Promise<PosProductDto> {
  return http.post<PosProductDto>("/api/v1/admin/pos-products", body);
}
export function updatePosProduct(id: string, body: PosProductWriteDto): Promise<PosProductDto> {
  return http.put<PosProductDto>(`/api/v1/admin/pos-products/${id}`, body);
}

/* ---- Categories (düz liste) ---- */
export function listCategories(): Promise<CategoryDto[]> {
  return http.get<CategoryDto[]>("/api/v1/admin/categories", { companyId: getCompanyId() });
}
export function createCategory(body: CategoryWriteDto): Promise<CategoryDto> {
  return http.post<CategoryDto>("/api/v1/admin/categories", body);
}
export function updateCategory(id: string, body: CategoryWriteDto): Promise<CategoryDto> {
  return http.put<CategoryDto>(`/api/v1/admin/categories/${id}`, body);
}
export function deleteCategory(id: string): Promise<void> {
  return http.del<void>(`/api/v1/admin/categories/${id}`, scope());
}

/* ---- Users (sunucu-taraflı sayfalı) ---- */
export function listUsers(q: ListQuery): Promise<PagedResult<UserDto>> {
  return http.get<PagedResult<UserDto>>("/api/v1/admin/users", paged(q));
}
export function createUser(body: UserWriteDto): Promise<UserDto> {
  return http.post<UserDto>("/api/v1/admin/users", body);
}
export function updateUser(id: string, body: UserWriteDto): Promise<UserDto> {
  return http.put<UserDto>(`/api/v1/admin/users/${id}`, body);
}
export function deleteUser(id: string): Promise<void> {
  return http.del<void>(`/api/v1/admin/users/${id}`, scope());
}

/* ---- Roles + permissions (düz liste) ---- */
export function listRoles(): Promise<RoleDto[]> {
  return http.get<RoleDto[]>("/api/v1/admin/roles", { companyId: getCompanyId() });
}
export function createRole(body: RoleWriteDto): Promise<RoleDto> {
  return http.post<RoleDto>("/api/v1/admin/roles", body);
}
export function updateRole(id: string, body: RoleWriteDto): Promise<RoleDto> {
  return http.put<RoleDto>(`/api/v1/admin/roles/${id}`, body);
}
export function deleteRole(id: string): Promise<void> {
  return http.del<void>(`/api/v1/admin/roles/${id}`, scope());
}
export function listPermissions(): Promise<PermissionDto[]> {
  return http.get<PermissionDto[]>("/api/v1/admin/permissions");
}
export function setRolePermissions(id: string, permissionIds: string[]): Promise<RoleDto> {
  return http.put<RoleDto>(`/api/v1/admin/roles/${id}/permissions`, { ...scope(), permissionIds } satisfies RolePermissionWriteDto);
}

/* ---- Discounts (sunucu-taraflı sayfalı) ---- */
export function listDiscounts(q: ListQuery): Promise<PagedResult<DiscountDto>> {
  return http.get<PagedResult<DiscountDto>>("/api/v1/admin/discounts", paged(q));
}
export function createDiscount(body: DiscountWriteDto): Promise<DiscountDto> {
  return http.post<DiscountDto>("/api/v1/admin/discounts", body);
}
export function updateDiscount(id: string, body: DiscountWriteDto): Promise<DiscountDto> {
  return http.put<DiscountDto>(`/api/v1/admin/discounts/${id}`, body);
}
export function deleteDiscount(id: string): Promise<void> {
  return http.del<void>(`/api/v1/admin/discounts/${id}`, scope());
}

/* ---- Campaigns (sunucu-taraflı sayfalı) ---- */
export function listCampaigns(q: ListQuery): Promise<PagedResult<CampaignDto>> {
  return http.get<PagedResult<CampaignDto>>("/api/v1/admin/campaigns", paged(q));
}
export function createCampaign(body: CampaignWriteDto): Promise<CampaignDto> {
  return http.post<CampaignDto>("/api/v1/admin/campaigns", body);
}
export function updateCampaign(id: string, body: CampaignWriteDto): Promise<CampaignDto> {
  return http.put<CampaignDto>(`/api/v1/admin/campaigns/${id}`, body);
}
export function deleteCampaign(id: string): Promise<void> {
  return http.del<void>(`/api/v1/admin/campaigns/${id}`, scope());
}

/* ---- Lookups ---- */
export function listPos(): Promise<PosDto[]> {
  return http.get<PosDto[]>("/api/v1/admin/pos", { companyId: getCompanyId() });
}
export function listStores(): Promise<StoreDto[]> {
  return http.get<StoreDto[]>("/api/v1/admin/stores", { companyId: getCompanyId() });
}
export function listLoyaltyTiers(): Promise<LoyaltyTierDto[]> {
  return http.get<LoyaltyTierDto[]>("/api/v1/admin/loyalty-tiers", { companyId: getCompanyId() });
}
