import { Injectable, InputSignal } from '@angular/core';
import { httpResource } from '@angular/common/http';

import { ProductModel } from '../models/product.model';
import { environment } from '../../../../environment/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly apiUrl : string = `${environment.apiBaseUrl}/api/products`;
  readonly products = httpResource<ProductModel[]>(() => this.apiUrl);

  getByBarcode(barcode: InputSignal<string | undefined>)  {
    return httpResource<ProductModel>(() => `${this.apiUrl}/${barcode}`);
  }

  getById(id: string) {
    return httpResource<ProductModel>(() =>
        `${this.apiUrl}/${id}`
    );

}

}