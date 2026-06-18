import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScanProduct } from './scan-product';

describe('ScanProduct', () => {
  let component: ScanProduct;
  let fixture: ComponentFixture<ScanProduct>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ScanProduct]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ScanProduct);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
