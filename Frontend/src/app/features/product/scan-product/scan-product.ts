import { Component, inject, input } from '@angular/core';
import { ProductService } from '../services/product-services';
import { ProductDto } from '../models/product.model';

@Component({
  selector: 'app-scan-product',
  imports: [],
  templateUrl: './scan-product.html',
  styleUrl: './scan-product.css',
})
export class ScanProduct {
  private readonly productService = inject(ProductService)
  codeBarre = input<string>();

  
}
