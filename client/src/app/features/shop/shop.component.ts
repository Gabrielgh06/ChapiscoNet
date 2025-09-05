import { Component, inject, OnInit } from '@angular/core';
import { ShopService } from '../../core/services/shop.service';
import { Product } from '../../shared/models/product';
import { ProductItemComponent } from "./product-item/product-item.component";
import { MatDialog } from '@angular/material/dialog';
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatSelectionList, MatListOption, MatSelectionListChange } from '@angular/material/list';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { ShopParams } from '../../shared/models/shopParams';
import { Pagination } from '../../shared/models/pagination';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-shop',
  imports: [
    ProductItemComponent,
    MatButton,
    MatIcon,
    MatMenu,
    MatSelectionList,
    MatListOption,
    MatMenuTrigger,
    MatPaginator,
    FormsModule
  ],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})
export class ShopComponent implements OnInit {
  private shopService = inject(ShopService);
  private dialog = inject(MatDialog)
  products?: Pagination<Product> ;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Preço: Baixo para Alto', value: 'priceAsc' },
    { name: 'Preço: Alto para Baixo', value: 'priceDesc' },
    //{name: 'Newest Arrivals', value: 'newest'},
  ]
  // selectedPriceRange: number[] = [0, 1000];
  shopParams = new ShopParams();
  pageSizeOptions = [5, 10, 15, 20];

  ngOnInit(): void {
    this.initialiseShop();
  }

  initialiseShop() {
    this.shopService.getSizes();
    this.shopService.getCategories();
    this.getProducts();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe({
      next: (response: any) => this.products = response,
      error: (error: unknown) => console.log(error)
    })
  }

  onSearchChange() {
    this.shopParams.pageNumer = 1;
    this.getProducts();
  }

  handlePageEvent(event: PageEvent) {
    this.shopParams.pageNumer = event.pageIndex + 1;
    this.shopParams.pageSize = event.pageSize;
    this.getProducts();
  }

  onSortChange(event: MatSelectionListChange) {
    const selectedOption = event.options[0];
    if (selectedOption) {
      this.shopParams.sort = selectedOption.value;
      this.shopParams.pageNumer = 1;
      this.getProducts();
    }
  }

  openFiltersDialog() {
    const dialogRef = this.dialog.open(FiltersDialogComponent, {
      minWidth: '500px',
      data: {
        selectedSizes: this.shopParams.sizes,
        selectedCategories: this.shopParams.categories,
        // selectedPriceRange: this.selectedPriceRange
      }
    });
    dialogRef.afterClosed().subscribe({
      next: result => {
        if (result) {
          this.shopParams.sizes = result.selectedSizes;
          this.shopParams.categories = result.selectedCategories;
          this.shopParams.pageNumer = 1;
          this.getProducts();
          // this.selectedPriceRange = result.selectedPriceRange;
        }
      }
    })
  }
}
