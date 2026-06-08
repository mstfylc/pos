Primary action control — use for any clickable action; `solid primary` is the default CTA.

```jsx
<Button color="primary" iconStart="plus-squared">New project</Button>
<Button variant="light" color="success">Approve</Button>
<Button variant="outline" color="dark" size="sm">Cancel</Button>
<Button variant="ghost" iconEnd="chevron-down">Filters</Button>
```

Variants: `solid` (filled), `light` (soft tint → fills on hover), `outline`, `ghost`, `link`.
Colors: `primary` `secondary` `success` `danger` `warning` `info` `dark`. Sizes: `sm` `md` `lg`.
Pair with `iconStart` / `iconEnd` (KeenIcon names). Use `fullWidth` in forms/auth.
