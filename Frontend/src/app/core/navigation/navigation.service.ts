import { Injectable } from '@angular/core';
import { NavigationItem } from './navigation-item';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {

  readonly items: NavigationItem[] = [
  {
    label: 'Dashboard',
    icon: 'dashboard',
    route: '/home'
  },
  {
    label: 'Produits',
    icon: 'inventory_2',
    route: '/products'
  },
  {
    label: 'Stocks',
    icon: 'warehouse',
    route: '/stocks'
  },
  {
    label: 'Scanner',
    icon: 'qr_code_scanner',
    route: '/scanner'
  }

  ];
}