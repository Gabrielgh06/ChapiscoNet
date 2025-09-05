import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Pagination } from '../../shared/models/pagination';
import { Product } from '../../shared/models/product';
import { ShopParams } from '../../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  private http = inject(HttpClient);
  size: string[] = [];
  category: string[] = [];

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.sizes.length > 0) {
      params = params.append('sizes', shopParams.sizes.join(','));
    }
    if (shopParams.categories.length > 0) {
      params = params.append('categories', shopParams.categories.join(','));
    }
    if (shopParams.sort) {
      params = params.append('sort', shopParams.sort);
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    params = params.append('pageSize', shopParams.pageSize);
    params = params.append('pageIndex', shopParams.pageNumer);

    return this.http.get<Pagination<Product>>(this.baseUrl + 'products',{params});
  }

  getSizes() {
    if (this.size.length > 0) return;
    return this.http.get<string[]>(this.baseUrl + 'products/sizes').subscribe({ next: response => this.size = response, error: error => console.log(error) });
  }

  getCategories() {
    if (this.category.length > 0) return;
    return this.http.get<string[]>(this.baseUrl + 'products/categories').subscribe({ next: response => this.category = response, error: error => console.log(error) });
  }
}
