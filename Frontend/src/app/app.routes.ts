import { Routes } from '@angular/router';
import { HomeComponent } from './core/home/home-component/home-component';
import { ScanProduct } from './product/scan-product/scan-product';
import { ProductList } from './product/product-list/product-list/product-list';

export const routes: Routes = [
    {
        path:'', 
        component: HomeComponent
    },
    {
        path:'Scan',
        component: ScanProduct
    },
    {
        path:'ProduitList',
        component: ProductList
    }
];
