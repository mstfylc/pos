Inline contextual banner — confirmations, warnings, errors.

```jsx
<Alert color="success" title="Saved" onClose={() => {}}>Your changes are live.</Alert>
<Alert color="danger" variant="solid">Payment failed — update your card.</Alert>
<Alert color="warning" title="Heads up">Your trial ends in 3 days.</Alert>
```

`variant`: light (default), solid, outline. A default icon is chosen per color — override with `icon` or pass `icon={null}`.
