import { Component, CUSTOM_ELEMENTS_SCHEMA, inject } from '@angular/core';
import { ProductService } from '../../services/product-services';
import { MatCardModule } from '@angular/material/card';
import { ProductComponent } from '../product/product';
import { Router } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-product-list',
  imports: [MatCardModule,ProductComponent],
  templateUrl: './product-list.html',
  styleUrl: './product-list.scss',
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class ProductList {
private readonly productService = inject(ProductService)
private readonly router = inject(Router);
private productList = this.productService.products;

isLoading =  this.productList.isLoading;
isError = this.productList.error;
value = this.productList.value;

openProduct(id:string){
  this.router.navigate(['/products', id]);
  }
}
