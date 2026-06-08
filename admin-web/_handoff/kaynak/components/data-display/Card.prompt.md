Card surface — the primary container for dashboard widgets, lists and forms.

```jsx
<Card>
  <CardHeader title="Teams" subtitle="52 members" toolbar={<Button size="sm" variant="light">Manage</Button>} />
  <CardBody>…</CardBody>
  <CardFooter><Button variant="ghost" size="sm">View all</Button></CardFooter>
</Card>
```

White, 12px radius, soft `shadow-sm`. Use `flush` to drop the shadow when nesting. Header/Body/Footer are optional.
