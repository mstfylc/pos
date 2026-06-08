# Admin Dashboard — UI Kit

A high-fidelity, interactive recreation of the **Metronic** admin template's core surfaces, composed entirely from this design system's components.

## Run it
Open `index.html`. You land on the **Sign in** screen (any credentials work — click *Sign in*). Once in, the left sidebar switches between:

- **Dashboards** — stat cards, an earnings area-chart, the all-time-sales Highlights widget, and the Teams table.
- **Public Profile** — profile hero, tab bar, About / Skills cards, blog promo, Sales Overview chart, Contributors list and the Assistance donut.

Other nav items render an honest placeholder (not part of the sample).

## Files
| File | Role |
|------|------|
| `index.html` | Auth gate + app router; mounts the shell and views |
| `Shell.jsx` | `AppShell`, `Sidebar`, `Topbar` — the persistent chrome (`window.MTShell`) |
| `DashboardView.jsx` | Dashboard widgets + inline area chart (`window.DashboardView`) |
| `ProfileView.jsx` | Public profile surface + donut/area charts (`window.ProfileView`) |

## How it's wired
Each `.jsx` is loaded as a `text/babel` script and assigns its exports to `window`. All UI primitives (Button, Card, Badge, Avatar, Input, Tabs, Progress, Icon, …) come from the compiled bundle at `window.MetronicDesignSystem_a73f8f`. Charts are inline SVG (data-viz, not icons). No component logic is re-implemented — the kit only composes.
