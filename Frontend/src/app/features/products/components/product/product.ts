import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { ProductModel } from '../../models/product.model';

@Component({
  standalone: true,
  selector: 'app-product',
  imports: [MatCardModule, MatIconModule],
  templateUrl: './product.html',
  styleUrl: './product.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProductComponent {
 readonly product = input.required<ProductModel>();
 readonly selected = output<string>()

 open() {
  console.log(this.product());
    this.selected.emit(this.product().productId);
    }
}
