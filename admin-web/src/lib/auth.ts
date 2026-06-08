/* Auth genel yüzeyi — oturum durumu session.ts'te, login akışı api'de.
   Yetki iskeleti (can) şimdilik tüm öğeleri açık tutar; rol/izin matrisi
   API'den geldiğinde buraya bağlanacak. */
import { clearSession, getSession, hasSession } from "./session";

export interface CurrentUser {
  name: string;
  role: string;
}

/** Üst bar gösterimi. AuthTokenResult kullanıcı adını taşımıyor; userId kısaltması gösterilir. */
export function getCurrentUser(): CurrentUser {
  const s = getSession();
  const short = s ? `#${s.userId.slice(0, 8)}` : "—";
  return { name: "Yönetici", role: short };
}

export function isAuthed(): boolean {
  return hasSession();
}

export function logout(): void {
  clearSession();
}

/**
 * Yetki kontrolü iskeleti. Şimdilik tüm öğeler görünür (true).
 * API rol/izin matrisi bağlanınca burada değerlendirilecek.
 */
export function can(_perm?: string): boolean {
  return true;
}
