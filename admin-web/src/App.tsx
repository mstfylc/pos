import { type ReactNode } from "react";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { QueryClientProvider } from "@tanstack/react-query";
import { ToastProvider } from "@/design-system";
import { AdminShell } from "@/shell/AdminShell";
import { ALL_ITEMS } from "@/shell/nav";
import { isAuthed } from "@/lib/auth";
import { queryClient } from "@/lib/queryClient";
import { LoginPage } from "@/pages/LoginPage";
import { DashboardPage } from "@/pages/DashboardPage";
import { PlaceholderPage } from "@/pages/PlaceholderPage";
import { ProductsPage } from "@/pages/products/ProductsPage";
import { CategoriesPage } from "@/pages/categories/CategoriesPage";
import { UsersPage } from "@/pages/users/UsersPage";
import { RolesPage } from "@/pages/roles/RolesPage";
import { DiscountsPage } from "@/pages/discounts/DiscountsPage";
import { CampaignsPage } from "@/pages/campaigns/CampaignsPage";

const CUSTOM_PATHS = new Set(["/", "/products", "/categories", "/users", "/roles", "/campaigns", "/discounts"]);

function RequireAuth({ children }: { children: ReactNode }): ReactNode {
  return isAuthed() ? <>{children}</> : <Navigate to="/login" replace />;
}

export default function App(): ReactNode {
  return (
    <QueryClientProvider client={queryClient}>
      <ToastProvider>
        <BrowserRouter>
          <Routes>
            <Route path="/login" element={<LoginPage />} />
            <Route
              element={
                <RequireAuth>
                  <AdminShell />
                </RequireAuth>
              }
            >
              <Route index element={<DashboardPage />} />
              <Route path="/products" element={<ProductsPage />} />
              <Route path="/categories" element={<CategoriesPage />} />
              <Route path="/users" element={<UsersPage />} />
              <Route path="/roles" element={<RolesPage />} />
              <Route path="/discounts" element={<DiscountsPage />} />
              <Route path="/campaigns" element={<CampaignsPage />} />
              {ALL_ITEMS.filter((i) => !CUSTOM_PATHS.has(i.path)).map((i) => (
                <Route key={i.path} path={i.path} element={<PlaceholderPage />} />
              ))}
            </Route>
            <Route path="*" element={<Navigate to="/" replace />} />
          </Routes>
        </BrowserRouter>
      </ToastProvider>
    </QueryClientProvider>
  );
}
