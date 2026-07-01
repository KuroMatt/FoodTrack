import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ProductService } from '../../services/product-services';
import { ErrorStateComponent } from '../../../../shared/ui/error-state/error-state';
import { LoadingComponent } from '../../../../shared/ui/loading/loading';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-product-details',
  imports: [MatIconModule,LoadingComponent,ErrorStateComponent,MatCardModule,RouterLink],
  templateUrl: './product-details.html',
  styleUrl: './product-details.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProductDetailsComponent {

    private readonly route = inject(ActivatedRoute);
    private readonly productService = inject(ProductService);

    readonly id = this.route.snapshot.paramMap.get('id')

    readonly product = this.productService.getById(this.id!);
}
