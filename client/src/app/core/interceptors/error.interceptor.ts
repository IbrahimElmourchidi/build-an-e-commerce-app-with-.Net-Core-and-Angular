import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { catchError, delay, Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastService } from '../toast/toast.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router, private toastService: ToastService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error) => {
        if (error) {
          if (error.status == 400) {
            if (error.error.errors) {
              throw error.error;
            } else this.toastService.showError(error.error.message);
          } else if (error.status == 401) {
            this.toastService.showError(error.error.message);
          } else if (error.status == 404) {
            this.router.navigateByUrl('/notfound');
          } else if (error.status == 500) {
            const navigationExtras: NavigationExtras = {
              state: { error: error.error },
            };
            this.router.navigateByUrl('/servererror', navigationExtras);
          }
        }
        return throwError(() => error);
      })
    );
  }
}
