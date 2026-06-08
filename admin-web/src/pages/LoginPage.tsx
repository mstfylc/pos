import { useState, type FormEvent, type ReactNode } from "react";
import { useNavigate } from "react-router-dom";
import { Icon } from "@/design-system";
import { login } from "@/lib/api";
import { ApiError } from "@/lib/http";
import { logoMarkDark, logoMark } from "@/lib/assets";
import "./Login.css";

interface FieldErrors {
  companyId?: string;
  username?: string;
  pass?: string;
}

export function LoginPage(): ReactNode {
  const navigate = useNavigate();
  const [companyId, setCompanyId] = useState("");
  const [username, setUsername] = useState("");
  const [pass, setPass] = useState("");
  const [show, setShow] = useState(false);
  const [remember, setRemember] = useState(true);
  const [err, setErr] = useState<FieldErrors>({});
  const [authErr, setAuthErr] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);

  async function submit(e: FormEvent): Promise<void> {
    e.preventDefault();
    const er: FieldErrors = {};
    if (!companyId.trim()) er.companyId = "Şirket ID zorunludur.";
    if (!username.trim()) er.username = "Kullanıcı adı zorunludur.";
    if (!pass) er.pass = "Parola zorunludur.";
    setErr(er);
    setAuthErr(null);
    if (Object.keys(er).length) return;

    setLoading(true);
    try {
      await login(companyId.trim(), username.trim(), pass);
      navigate("/");
    } catch (e) {
      const msg = e instanceof ApiError ? e.message : "Giriş başarısız. Tekrar deneyin.";
      setAuthErr(msg);
    } finally {
      setLoading(false);
    }
  }

  return (
    <div className="lg-wrap">
      <div className="lg-brand">
        <div className="lg-brand__top">
          <img src={logoMarkDark} alt="Uyanık" />
          <b>Uyanık</b>
        </div>
        <div className="lg-brand__mid">
          <h1>Kahvenin ritmini<br />tek panelden yönet.</h1>
          <p>
            Sipariş, stok, sadakat ve şubeler — Uyanık yönetim paneliyle her şey kontrol altında.
            Çayyolu'ndan Alsancak'a, tüm operasyonun nabzı burada.
          </p>
        </div>
        <div className="lg-stats">
          <div className="lg-stat"><b>4</b><span>Şube</span></div>
          <div className="lg-stat"><b>1.240</b><span>Sadakat üyesi</span></div>
          <div className="lg-stat"><b>₺312K</b><span>Aylık ciro</span></div>
        </div>
      </div>

      <div className="lg-form">
        <form className="lg-card" onSubmit={submit} noValidate>
          <div className="lg-card__mb"><img src={logoMark} alt="Uyanık" /><b>Uyanık</b></div>
          <h2>Tekrar hoş geldin 👋</h2>
          <p className="lg-card__sub">Devam etmek için hesabınla giriş yap.</p>

          {authErr && (
            <div className="lg-alert"><Icon name="cross-circle" size={16} color="var(--color-danger)" />{authErr}</div>
          )}

          <div className="lg-field">
            <label className="lg-label" htmlFor="lg-company">Şirket ID</label>
            <div className="lg-input-wrap">
              <span className="lg-ic"><Icon name="dots-square" size={17} color="var(--text-placeholder)" /></span>
              <input id="lg-company" className={"lg-input" + (err.companyId ? " err" : "")} type="text" placeholder="UUID" value={companyId} onChange={(e) => setCompanyId(e.target.value)} />
            </div>
            {err.companyId && <span className="lg-err"><Icon name="cross-circle" size={12} color="var(--color-danger)" />{err.companyId}</span>}
          </div>

          <div className="lg-field">
            <label className="lg-label" htmlFor="lg-user">Kullanıcı adı</label>
            <div className="lg-input-wrap">
              <span className="lg-ic"><Icon name="user" size={17} color="var(--text-placeholder)" /></span>
              <input id="lg-user" className={"lg-input" + (err.username ? " err" : "")} type="text" placeholder="kullanici.adi" value={username} onChange={(e) => setUsername(e.target.value)} />
            </div>
            {err.username && <span className="lg-err"><Icon name="cross-circle" size={12} color="var(--color-danger)" />{err.username}</span>}
          </div>

          <div className="lg-field">
            <label className="lg-label" htmlFor="lg-pass">Parola</label>
            <div className="lg-input-wrap">
              <span className="lg-ic"><Icon name="key" size={17} color="var(--text-placeholder)" /></span>
              <input id="lg-pass" className={"lg-input" + (err.pass ? " err" : "")} type={show ? "text" : "password"} placeholder="••••••••" value={pass} onChange={(e) => setPass(e.target.value)} />
              <button type="button" className="lg-eye" onClick={() => setShow((s) => !s)} aria-label="Parolayı göster">
                <Icon name={show ? "cross-circle" : "magnifier"} size={16} />
              </button>
            </div>
            {err.pass && <span className="lg-err"><Icon name="cross-circle" size={12} color="var(--color-danger)" />{err.pass}</span>}
          </div>

          <div className="lg-rowbtw">
            <label className="lg-check"><input type="checkbox" checked={remember} onChange={(e) => setRemember(e.target.checked)} />Beni hatırla</label>
            <a className="lg-link" onClick={(e) => e.preventDefault()}>Parolamı unuttum</a>
          </div>

          <button className="lg-btn" type="submit" disabled={loading}>
            {loading ? (<><span className="lg-spin" />Giriş yapılıyor…</>) : (<>Giriş yap<Icon name="chevron-right" size={17} /></>)}
          </button>

          <div className="lg-foot">© 2026 Uyanık Kahve · Tüm hakları saklıdır</div>
        </form>
      </div>
    </div>
  );
}
