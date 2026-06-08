Labeled text field — the default form input. Add `error` to show a validation message and red state.

```jsx
<Input label="Email" type="email" placeholder="you@company.com" iconLead="messages" required />
<Input label="Search" iconLead="magnifier" placeholder="Search members" size="sm" />
<Input label="Password" type="password" error="Password is too short" />
```

Sizes `sm|md|lg`. `iconLead`/`iconTrail` take KeenIcon names. Without `label`/`hint`/`error` it renders a bare `<input>` you can place anywhere.
