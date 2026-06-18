import { inject, Injectable, InputSignal } from '@angular/core';
import { HttpClient, httpResource } from '@angular/common/http';

import { ProductDto } from '../models/product.model';
import { environment } from '../../../environment/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly apiUrl : string = `${environment.apiBaseUrl}/product`;

  getByBarcode(barcode: InputSignal<string | undefined>)  {
    return httpResource<ProductDto>(() => `${this.apiUrl}/${barcode}`);
  }

  getAllProducts() {
    return httpResource<ProductDto[]>(() => `${this.apiUrl}/Products` );
  }
}