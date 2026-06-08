/// <reference types="vite/client" />

interface ImportMetaEnv {
  /** Backend API taban adresi (bkz. .env.example) */
  readonly VITE_API_BASE_URL?: string;
}

interface ImportMeta {
  readonly env: ImportMetaEnv;
}
