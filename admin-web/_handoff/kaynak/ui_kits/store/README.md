# Store & Loyalty — UI Kit

An interactive **Uyanık** eCommerce + loyalty storefront, built entirely from this design system. Demonstrates the navy/orange brand on a customer-facing surface (Turkish copy), for web and mobile loyalty.

## Run it
Open `index.html`:
1. **Storefront** — hero, "Altın üye" loyalty banner, and an 8-product reward grid (points shown per item).
2. Click a product → **Product detail** (gallery with colorways, size/color pickers, *Sepete ekle*).
3. Add to cart → **Sepet & Ödeme** (checkout): editable line items, address & payment, an order summary with a **"puanını kullan"** redeem toggle, then *Siparişi tamamla* → confirmation.
4. The **puan** chip / profile icon → **Hesabım** (My Account): loyalty tier card, profile, orders, points history, security.

The cart badge (orange) updates live; the navy footer and sticky header persist via the shell.

## Files
| File | Role |
|------|------|
| `index.html` | App router + cart state |
| `StoreShell.jsx` | Header (logo, search, points, cart), category nav, footer (`window.StoreShell`) |
| `StorefrontView.jsx` | Hero, loyalty banner, product grid (`window.StorefrontView`, `STORE_PRODUCTS`) |
| `ProductView.jsx` | Product detail / gallery (`window.ProductView`) |
| `CheckoutView.jsx` | Cart + checkout + confirmation (`window.CheckoutView`, `OrderDone`) |
| `AccountView.jsx` | My Account: tier, profile, orders, loyalty, security (`window.AccountView`) |

## Notes
- **Brand:** navy `#1F3864` is structural (header text, nav-active, footer, tier card); orange `#E08A2B` is reserved for CTAs (`<Button color="accent">`), the cart badge and points.
- **Imagery:** one real product photo (`assets/products/sneaker.png`) is re-tinted with CSS `hue-rotate` to show colorways across the grid; branded tiles cover non-footwear rewards (gift card, trail). Swap in real catalog photography for production.
- All primitives come from `window.MetronicDesignSystem_a73f8f`; charts/None here — pure component composition.
