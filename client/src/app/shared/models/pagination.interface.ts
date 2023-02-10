import { IProduct } from "./product.interface";

export interface IPagination {
  pageSize: number;
  pageIndex: number;
  count: number;
  data: IProduct[];
  firstPageLink: string;
  previousPageLink: string;
  nextPageLink: string;
  lastPageLink: string;
}

