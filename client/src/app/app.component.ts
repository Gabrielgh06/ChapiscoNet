// import { Component } from '@angular/core';
// import { RouterOutlet } from '@angular/router';
// import { HeaderComponent } from './layout/header/header.component';
// import { ShopComponent } from "./features/shop/shop.component";

// @Component({
//   selector: 'app-root',
//   standalone: true,
//   imports: [RouterOutlet, HeaderComponent, ShopComponent],
//   templateUrl: './app.component.html',
//   styleUrl: './app.component.scss'
// })
// export class AppComponent  {
//   title = 'Chapisco';
// }
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './layout/header/header.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    CommonModule,
    HeaderComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Chapisco';
}
