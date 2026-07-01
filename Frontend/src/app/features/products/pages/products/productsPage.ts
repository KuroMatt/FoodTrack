import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { ProductList } from '../../components/product-list/product-list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@Component({
  standalone: true,
  selector: 'app-products',
  imports: [MatIconModule, MatFormFieldModule,ProductList, MatInputModule],
  templateUrl: './productsPage.html',
  styleUrl: './productsPage.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProductsPageComponent {
  
}
