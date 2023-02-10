import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/brand.interface';
import { ErrorResponse } from '../shared/models/error-response.interface';
import { IProductType } from '../shared/models/product-type.interface';
import { IProduct } from '../shared/models/product.interface';
import { ShopParams } from '../shared/models/shop-params';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  products!: IProduct[];
  brands!: IBrand[];
  types!: IProductType[];
  shopParams = new ShopParams();
  totalCount!: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' },
  ];
  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.GetProducts();
    this.GetBrands();
    this.GetTypes();
  }

  GetProducts() {
    this.shopService.GetProducts(this.shopParams).subscribe({
      next: (res) => {
        this.products = res!.data;
        this.shopParams.pageIndex = res!.pageIndex;
        this.shopParams.pageSize = res!.pageSize;
        this.totalCount = res!.count > 0 ? res!.count : 0;
      },
      error: (err) => console.log(err),
    });
  }

  GetBrands() {
    this.shopService.GetBrands().subscribe({
      next: (res) => (this.brands = [{ id: 0, name: 'all' }, ...res]),
      error: (err) => console.log(err),
    });
  }

  GetTypes() {
    this.shopService.GetTypes().subscribe({
      next: (res) => (this.types = [{ id: 0, name: 'all' }, ...res]),
      error: (err) => console.log(err),
    });
  }

  onBrandSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.GetProducts();
  }

  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.GetProducts();
  }

  onSortSelected(val: string) {
    this.shopParams.sort = val;
    this.GetProducts();
  }

  onPageChange(pageNumber: number) {
    console.log(pageNumber);
    this.shopParams.pageIndex = pageNumber;
    this.GetProducts();
  }
}
