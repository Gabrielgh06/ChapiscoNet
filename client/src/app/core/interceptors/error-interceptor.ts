import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { SnackbarService } from '../services/snackbar.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
  const snackbar = inject(SnackbarService);

  //Se quisermos fazer algo na saída, faremos antes de next()
  return next(req).pipe(
    //Aqui dentro podemos manipular a resposta
    catchError((err: HttpErrorResponse) => {
      if (err.status == 400) {
        if (err.error.errors) {
          const modalStateErrors = [];
          for (const key in err.error.errors) {
            if (err.error.errors[key]) {
              modalStateErrors.push(err.error.errors[key]);
            }
          }
          throw modalStateErrors.flat();
        } else {
          snackbar.error(err.error.title || err.error);
        }
      }
      if (err.status == 401) {
        snackbar.error(err.error.title || err.error);
      }
      /*if (err.status == 400 || err.status == 401) {
        const errorMsg = typeof err.error === 'string'
          ? err.error
          : err.error?.title || 'Ocorreu um erro';
        snackbar.error(errorMsg);
      }*/
      if (err.status == 404) {
        router.navigateByUrl('/not-found');
      }
      if (err.status == 500) {
        const navigarionExtras: NavigationExtras = { state: { error: err.error } };
        router.navigateByUrl('/server-error', navigarionExtras);
      }
      return throwError(() => err);
    })
    //Se quisermos fazer algo no caminho de volta, faremos depois de next()

  )
};
