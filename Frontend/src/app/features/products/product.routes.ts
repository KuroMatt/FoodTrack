import { Routes } from '@angular/router';
import { ProductsPageComponent } from './pages/products/productsPage';
import { ProductDetailsComponent } from './pages/product-details/product-details';

export const PRODUCT_ROUTES: Routes = [
  {
    path: '',
    component: ProductsPageComponent
  },
  {
    path: ':id',
    component: ProductDetailsComponent
  }
];