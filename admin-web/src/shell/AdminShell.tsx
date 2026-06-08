import { useCallback, useEffect, useRef, useState, type ReactNode } from "react";
import { useNavigate, useLocation, Outlet } from "react-router-dom";
import { Icon, IconButton, Avatar, type IconName } from "@/design-system";
import { NAV } from "./nav";
import { can, getCurrentUser, logout } from "@/lib/auth";
import { logoMarkDark } from "@/lib/assets";
import "./AdminShell.css";

/* ---- Üst bar veri modelleri (mock — gerçekte API'den gelecek) ---- */
interface Branch {
  id: string;
  name: string;
  sub: string;
  depot: boolean;
}
const ADMIN_BRANCHES: Branch[] = [
  { id: "cayyolu", name: "Çayyolu Şubesi", sub: "Ankara · Açık", depot: false },
  { id: "bagdat", name: "Bağdat Caddesi", sub: "İstanbul · Açık", depot: false },
  { id: "alsancak", name: "Alsancak Şubesi", sub: "İzmir · Açık", depot: false },
  { id: "merkez", name: "Merkez Depo", sub: "Ankara · 7/24", depot: true },
];

interface Notification {
  id: number;
  icon: IconName;
  bg: string;
  fg: string;
  title: string;
  desc: string;
  time: string;
  unread: boolean;
  to: string;
}
const NOTIFICATIONS: Notification[] = [
  { id: 1, icon: "dots-square", bg: "var(--color-accent-soft)", fg: "var(--color-accent)", title: "Eşik-altı stok uyarısı", desc: "7 ürün eşik değerinin altında", time: "5 dk önce", unread: true, to: "/stock" },
  { id: 2, icon: "handcart", bg: "var(--color-primary-soft)", fg: "var(--color-primary)", title: "Yeni sipariş · UYK-2048", desc: "Çayyolu şubesi · 248 ₺", time: "8 dk önce", unread: true, to: "/orders" },
  { id: 3, icon: "heart", bg: "var(--color-success-soft)", fg: "var(--color-success)", title: "32 yeni sadakat üyesi", desc: "Bugün kaydolan müşteriler", time: "1 saat önce", unread: false, to: "/customers" },
  { id: 4, icon: "price-tag", bg: "var(--color-primary-soft)", fg: "var(--color-primary)", title: "Kampanya sona eriyor", desc: "“Hafta sonu kahve” 2 gün kaldı", time: "3 saat önce", unread: false, to: "/campaigns" },
];

/* Dışarı tıklamada kapat */
function useOutside(ref: React.RefObject<HTMLDivElement | null>, cb: () => void): void {
  useEffect(() => {
    function handle(e: MouseEvent): void {
      if (ref.current && !ref.current.contains(e.target as Node)) cb();
    }
    document.addEventListener("mousedown", handle);
    return () => document.removeEventListener("mousedown", handle);
  }, [ref, cb]);
}

/* ---------- Sidebar ---------- */
interface SidebarProps {
  active: string;
  onNavigate: (path: string) => void;
  open: boolean;
}
function Sidebar({ active, onNavigate, open }: SidebarProps): ReactNode {
  return (
    <aside className={"as-side" + (open ? " as-side--open" : "")}>
      <div className="as-side__brand">
        <img src={logoMarkDark} alt="Uyanık" />
        <span className="wm">Uyanık</span>
      </div>
      <nav className="as-side__scroll">
        {NAV.map((group) => {
          const items = group.items.filter((it) => can(it.perm));
          if (items.length === 0) return null;
          return (
            <div key={group.sec}>
              <div className="as-sec">{group.sec}</div>
              {items.map((it) => (
                <button
                  key={it.id}
                  className={"as-nav" + (active === it.path ? " as-nav--active" : "")}
                  onClick={() => onNavigate(it.path)}
                >
                  <Icon className="as-nav__ic" name={it.icon} size={17} />
                  <span>{it.label}</span>
                  {it.count && <span className="as-nav__count">{it.count}</span>}
                </button>
              ))}
            </div>
          );
        })}
      </nav>
    </aside>
  );
}

/* ---------- Şube seçici ---------- */
function BranchPicker(): ReactNode {
  const navigate = useNavigate();
  const [open, setOpen] = useState(false);
  const [sel, setSel] = useState(0);
  const ref = useRef<HTMLDivElement>(null);
  useOutside(ref, useCallback(() => setOpen(false), []));
  const b = ADMIN_BRANCHES[sel];
  return (
    <div className="as-branch" ref={ref}>
      <button className="as-branch__btn" onClick={() => setOpen((o) => !o)}>
        <span className="as-branch__pin">
          <Icon name={b.depot ? "folder" : "home"} size={15} color="var(--color-primary)" />
        </span>
        <span className="as-branch__txt">
          <b>{b.name}</b>
          <span>{b.depot ? "Depo" : "Şube · POS aktif"}</span>
        </span>
        <Icon name="chevron-down" size={13} color="var(--text-placeholder)" style={{ transform: open ? "rotate(180deg)" : "none", transition: "transform .15s" }} />
      </button>
      {open && (
        <div className="as-menu as-menu--left">
          {ADMIN_BRANCHES.map((br, i) => (
            <button key={br.id} className={"as-menu__item" + (i === sel ? " as-menu__item--active" : "")} onClick={() => { setSel(i); setOpen(false); }}>
              <Icon name={br.depot ? "folder" : "home"} size={16} color={i === sel ? "var(--color-primary)" : "var(--text-muted)"} />
              <span>{br.name}<small>{br.sub}</small></span>
              {i === sel && <Icon name="check-circle" size={15} color="var(--color-primary)" style={{ marginLeft: "auto" }} />}
            </button>
          ))}
          <div className="as-menu__sep" />
          <button className="as-menu__item" onClick={() => { setOpen(false); navigate("/company"); }}>
            <Icon name="setting-2" size={16} color="var(--text-muted)" />
            <span>Tüm şubeleri yönet</span>
          </button>
        </div>
      )}
    </div>
  );
}

/* ---------- Kullanıcı menüsü ---------- */
function UserMenu(): ReactNode {
  const navigate = useNavigate();
  const [open, setOpen] = useState(false);
  const ref = useRef<HTMLDivElement>(null);
  useOutside(ref, useCallback(() => setOpen(false), []));
  function doLogout(): void {
    setOpen(false);
    logout();
    navigate("/login");
  }
  const user = getCurrentUser();
  return (
    <div className="as-user" ref={ref}>
      <button className="as-user__btn" onClick={() => setOpen((o) => !o)}>
        <Avatar name={user.name} size={34} status="online" />
        <span className="as-user__txt"><b>{user.name}</b><span>{user.role}</span></span>
        <Icon name="chevron-down" size={13} color="var(--text-placeholder)" />
      </button>
      {open && (
        <div className="as-menu as-menu--right">
          <button className="as-menu__item" onClick={() => { setOpen(false); navigate("/users"); }}>
            <Icon name="profile-circle" size={16} color="var(--text-muted)" /><span>Profilim</span>
          </button>
          <button className="as-menu__item" onClick={() => { setOpen(false); navigate("/settings"); }}>
            <Icon name="setting-2" size={16} color="var(--text-muted)" /><span>Hesap ayarları</span>
          </button>
          <div className="as-menu__sep" />
          <button className="as-menu__item" style={{ color: "var(--color-danger)" }} onClick={doLogout}>
            <Icon name="exit-right" size={16} color="var(--color-danger)" /><span>Çıkış yap</span>
          </button>
        </div>
      )}
    </div>
  );
}

/* ---------- Bildirim çanı ---------- */
function NotificationBell(): ReactNode {
  const navigate = useNavigate();
  const [open, setOpen] = useState(false);
  const [items, setItems] = useState<Notification[]>(NOTIFICATIONS);
  const ref = useRef<HTMLDivElement>(null);
  useOutside(ref, useCallback(() => setOpen(false), []));
  const unread = items.filter((i) => i.unread).length;
  return (
    <div className="as-bell" ref={ref}>
      <IconButton icon="message-notif" aria-label="Bildirimler" onClick={() => setOpen((o) => !o)} />
      {unread > 0 && <span className="as-bell__dot" />}
      {open && (
        <div className="as-noti">
          <div className="as-noti__hd">
            <b>Bildirimler {unread > 0 ? `(${unread})` : ""}</b>
            {unread > 0 && <button onClick={() => setItems(items.map((i) => ({ ...i, unread: false })))}>Tümünü okundu işaretle</button>}
          </div>
          <div className="as-noti__list">
            {items.length === 0 ? (
              <div className="as-noti__empty">Yeni bildirim yok.</div>
            ) : (
              items.map((n) => (
                <div className="as-noti__i" key={n.id} onClick={() => { setItems(items.map((i) => (i.id === n.id ? { ...i, unread: false } : i))); setOpen(false); navigate(n.to); }}>
                  <span className="as-noti__ic" style={{ background: n.bg }}><Icon name={n.icon} size={16} color={n.fg} /></span>
                  <div className="as-noti__tx" style={{ flex: 1 }}><b>{n.title}</b><span>{n.desc}</span><time>{n.time}</time></div>
                  {n.unread && <span className="as-noti__unread" />}
                </div>
              ))
            )}
          </div>
          <div className="as-noti__ft"><button onClick={() => setOpen(false)}>Kapat</button></div>
        </div>
      )}
    </div>
  );
}

/* ---------- Üst bar ---------- */
function Topbar({ onBurger }: { onBurger: () => void }): ReactNode {
  const navigate = useNavigate();
  return (
    <header className="as-top">
      <div className="as-top__left">
        <button className="as-burger" onClick={onBurger} aria-label="Menü"><Icon name="dots-square" size={19} /></button>
        <BranchPicker />
        <div className="as-search">
          <Icon name="magnifier" size={15} />
          <input
            placeholder="Ürün, sipariş, müşteri ara…"
            onKeyDown={(e) => { if (e.key === "Enter" && e.currentTarget.value.trim()) navigate("/products"); }}
          />
          <kbd>⌘K</kbd>
        </div>
      </div>
      <div className="as-top__right">
        <IconButton icon="calendar" aria-label="Takvim" onClick={() => navigate("/reports")} />
        <NotificationBell />
        <UserMenu />
      </div>
    </header>
  );
}

/* ---------- Page header (sayfalar bunu içerikte kullanır) ---------- */
export interface PageHeaderProps {
  crumb?: string[];
  title: string;
  desc?: string;
  actions?: ReactNode;
}
export function PageHeader({ crumb, title, desc, actions }: PageHeaderProps): ReactNode {
  return (
    <div className="as-pagehd">
      <div>
        {crumb && (
          <div className="as-crumb">
            {crumb.map((c, i) => (
              <span key={i} style={{ display: "contents" }}>
                {i > 0 && <span className="sep">/</span>}
                {i === crumb.length - 1 ? <b>{c}</b> : <span>{c}</span>}
              </span>
            ))}
          </div>
        )}
        <h1>{title}</h1>
        {desc && <p>{desc}</p>}
      </div>
      {actions && <div className="as-pagehd__act">{actions}</div>}
    </div>
  );
}

/* ---------- Shell (router layout) ---------- */
export function AdminShell(): ReactNode {
  const navigate = useNavigate();
  const location = useLocation();
  const [menuOpen, setMenuOpen] = useState(false);

  useEffect(() => { setMenuOpen(false); }, [location.pathname]);

  function nav(path: string): void {
    navigate(path);
    setMenuOpen(false);
  }

  return (
    <div className="as-app">
      {menuOpen && <div className="as-scrim" onClick={() => setMenuOpen(false)} />}
      <Sidebar active={location.pathname} onNavigate={nav} open={menuOpen} />
      <div className="as-main">
        <Topbar onBurger={() => setMenuOpen((o) => !o)} />
        <div className="as-content">
          <Outlet />
        </div>
      </div>
    </div>
  );
}
