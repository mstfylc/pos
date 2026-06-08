/* Tek HTTP katmanı — bearer interceptor + Problem hata yönetimi.
   Tüm endpoint fonksiyonları (api.ts) bunu kullanır. */
import type { ProblemDetails } from "./api/types";
import { getToken } from "./session";

const BASE = (import.meta.env.VITE_API_BASE_URL ?? "http://localhost:5080").replace(/\/$/, "");

export class ApiError extends Error {
  status: number;
  problem?: ProblemDetails;
  constructor(status: number, message: string, problem?: ProblemDetails) {
    super(message);
    this.name = "ApiError";
    this.status = status;
    this.problem = problem;
  }
}

type Query = Record<string, string | number | boolean | undefined>;

function buildUrl(path: string, query?: Query): string {
  const url = new URL(BASE + path);
  if (query) {
    for (const [k, v] of Object.entries(query)) {
      if (v !== undefined) url.searchParams.set(k, String(v));
    }
  }
  return url.toString();
}

interface RequestOpts {
  query?: Query;
  body?: unknown;
  /** Authorization header ekleme (login gibi public uçlar) */
  anonymous?: boolean;
}

async function request<T>(method: string, path: string, opts: RequestOpts = {}): Promise<T> {
  const headers: Record<string, string> = { Accept: "application/json" };
  if (opts.body !== undefined) headers["Content-Type"] = "application/json";
  if (!opts.anonymous) {
    const token = getToken();
    if (token) headers["Authorization"] = `Bearer ${token}`;
  }

  let res: Response;
  try {
    res = await fetch(buildUrl(path, opts.query), {
      method,
      headers,
      body: opts.body !== undefined ? JSON.stringify(opts.body) : undefined,
    });
  } catch (e) {
    throw new ApiError(0, "Sunucuya ulaşılamadı. Backend çalışıyor mu?", undefined);
  }

  if (res.status === 204) return undefined as T;

  const text = await res.text();
  const data = text ? JSON.parse(text) : undefined;

  if (!res.ok) {
    const problem = data as ProblemDetails | undefined;
    const msg = problem?.detail ?? problem?.title ?? `İstek başarısız (${res.status})`;
    throw new ApiError(res.status, msg, problem);
  }
  return data as T;
}

export const http = {
  get: <T>(path: string, query?: Query) => request<T>("GET", path, { query }),
  post: <T>(path: string, body?: unknown, opts?: RequestOpts) => request<T>("POST", path, { ...opts, body }),
  put: <T>(path: string, body?: unknown, query?: Query) => request<T>("PUT", path, { body, query }),
  del: <T>(path: string, query?: Query) => request<T>("DELETE", path, { query }),
};
