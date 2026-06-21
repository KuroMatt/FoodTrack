import { Injectable } from '@angular/core';
import { NavigationItem } from './navigation-item';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {

  readonly items: NavigationItem[] = [
    {
      label: 'Scanner',
      icon: 'barcode_reader',
      route: '/scan'
    },
    {
      label: 'Produits',
      icon: 'inventory_2',
      route: '/products'
    },
    {
      label: 'Stock',
      icon: 'warehouse',
      route: '/stock'
    }
  ];
}