import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBrand } from '../shared/models/brand.interface';
import { IPagination } from '../shared/models/pagination.interface';
import { IProductType } from '../shared/models/product-type.interface';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shop-params';
import { IProduct } from '../shared/models/product.interface';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) {}

  GetProducts(shopParams: ShopParams) {
    let params = new HttpParams();
    if (shopParams.brandId)
      params = params.append('brandId', shopParams.brandId.toString());
    if (shopParams.typeId)
      params = params.append('typeId', shopParams.typeId.toString());
    if (shopParams.search) params = params.append('search', shopParams.search);
    params = params
      .append('sort', shopParams.sort)
      .append('pageIndex', shopParams.pageIndex.toString())
      .append('pageSize', shopParams.pageSize.toString());
    return this.http
      .get<IPagination>(this.baseUrl + 'product', {
        observe: 'response',
        params,
      })
      .pipe(map((res) => res.body));
  }

  GetBrands(): Observable<IBrand[]> {
    return this.http.get<IBrand[]>(this.baseUrl + 'product/brands');
  }

  GetTypes(): Observable<IProductType[]> {
    return this.http.get<IProductType[]>(this.baseUrl + 'product/types');
  }

  GetSingleProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + `product/${id}`);
  }
}
