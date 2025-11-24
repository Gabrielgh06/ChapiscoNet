import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { CartService } from '../services/cart.service';
import { SnackbarService } from '../services/snackbar.service';

export const emptyCartGuard: CanActivateFn = (route, state) => {
  const cartService = inject(CartService);
  const router = inject(Router);
  const snack = inject(SnackbarService);

  if (!cartService.cart() || cartService.cart()?.items.length === 0) {
    snack.error('Seu carrinho está vazio');
    router.navigateByUrl('/cart');
    return false;
  }
  return true;
};