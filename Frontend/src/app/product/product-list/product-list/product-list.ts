import { Component, CUSTOM_ELEMENTS_SCHEMA, inject } from '@angular/core';
import { ProductService } from '../../services/product-services';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-product-list',
  imports: [MatCardModule],
  templateUrl: './product-list.html',
  styleUrl: './product-list.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class ProductList {
private readonly productService = inject(ProductService)
private productList = this.productService.getAllProducts();

isLoading =  this.productList.isLoading;
isError = this.productList.error;
value = this.productList.value;

}
