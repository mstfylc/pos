/* Oturum durumu — login sonrası AuthTokenResult'tan saklanır.
   sessionStorage: token + multi-tenant scope (companyId/userId).
   Gerçek token akışı openapi client ile; secret koda yazılmaz. */
import type { AuthTokenResult } from "./api/types";

const KEY = "uyanik_admin_session";

export interface Session {
  accessToken: string;
  refreshToken: string;
  userId: string;
  companyId: string;
  expiresAt: string;
}

export function setSession(r: AuthTokenResult): void {
  const s: Session = {
    accessToken: r.accessToken,
    refreshToken: r.refreshToken,
    userId: r.userId,
    companyId: r.companyId,
    expiresAt: r.expiresAt,
  };
  sessionStorage.setItem(KEY, JSON.stringify(s));
}

export function getSession(): Session | null {
  const raw = sessionStorage.getItem(KEY);
  if (!raw) return null;
  try {
    return JSON.parse(raw) as Session;
  } catch {
    return null;
  }
}

export function clearSession(): void {
  sessionStorage.removeItem(KEY);
}

export function hasSession(): boolean {
  return getSession() !== null;
}

export function getToken(): string | null {
  return getSession()?.accessToken ?? null;
}

export function getCompanyId(): string {
  const id = getSession()?.companyId;
  if (!id) throw new Error("Oturum yok: companyId bulunamadı");
  return id;
}

export function getUserId(): string {
  const id = getSession()?.userId;
  if (!id) throw new Error("Oturum yok: userId bulunamadı");
  return id;
}
