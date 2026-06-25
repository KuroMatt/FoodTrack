import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/pages/home/home';



export const routes: Routes = [
    
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'dashboard',
        component: HomeComponent
    },
    {
        path: 'home',
        component: HomeComponent
    },

  {
    path: 'products',
    loadChildren: () =>
      import('./features/products/product.routes').then(m => m.PRODUCT_ROUTES)
  },

  {
    path: 'stocks',
    loadChildren: () =>
      import('./features/stocks/stock.routes').then(m => m.STOCK_ROUTES)    
  },

  {
    path: 'scanner',
    loadChildren: () =>
      import('./features/scanner/scanner.routes').then(m => m.SCANNER_ROUTES)
  },

    {
        path: '**',
        redirectTo: 'home'
    }

];
