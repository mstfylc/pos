User avatar — pass a photo `src`, or just a `name` to get auto-colored initials.

```jsx
<Avatar name="Jenny Klabber" status="online" />
<Avatar src="/uploads/jenny.jpg" size="lg" ring />
<AvatarGroup people={[{name:"A B"},{name:"C D"},{src:"/x.jpg"}]} max={3} />
```

Sizes `xs|sm|md|lg|xl` or a number. `status` adds a presence dot (online/busy/away/offline). AvatarGroup overlaps and shows “+N”.
