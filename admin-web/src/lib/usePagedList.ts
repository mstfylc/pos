import { useState } from "react";
import { keepPreviousData, useQuery } from "@tanstack/react-query";
import type { ListQuery } from "./api";
import type { PagedResult } from "./api/types";

export interface SortState {
  key: string;
  dir: "asc" | "desc";
}

/** Sunucu-taraflı sayfalı liste yönetimi (page/filter/sort + react-query). */
export function usePagedList<T>(
  key: string,
  fetcher: (q: ListQuery) => Promise<PagedResult<T>>,
  toSort: (s: SortState) => string,
  pageSize = 20,
) {
  const [page, setPage] = useState(1);
  const [filter, setFilterRaw] = useState("");
  const [sort, setSortRaw] = useState<SortState | undefined>(undefined);

  const query = useQuery({
    queryKey: [key, page, pageSize, filter, sort],
    queryFn: () => fetcher({ page, pageSize, filter: filter || undefined, sort: sort ? toSort(sort) : undefined }),
    placeholderData: keepPreviousData,
  });

  return {
    query,
    page,
    setPage,
    pageSize,
    filter,
    setFilter: (v: string) => { setFilterRaw(v); setPage(1); },
    sort,
    setSort: (s: SortState) => { setSortRaw(s); setPage(1); },
  };
}
