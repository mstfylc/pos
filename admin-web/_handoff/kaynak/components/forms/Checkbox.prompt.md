Checkbox, Radio and Switch — selection controls sharing one stylesheet.

```jsx
<Checkbox label="I accept the Terms & Conditions" defaultChecked />
<Radio name="plan" label="Monthly" defaultChecked />
<Radio name="plan" label="Annual" />
<Switch label="Email notifications" defaultChecked />
```

Group radios with a shared `name`. All accept native input props (`checked`, `defaultChecked`, `disabled`, `onChange`).
