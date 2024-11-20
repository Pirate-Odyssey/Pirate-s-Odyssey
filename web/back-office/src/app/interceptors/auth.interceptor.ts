import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  if (!req.headers.has('X-CSRF')) {
    req = req.clone({
      headers: req.headers.set('X-CSRF', '1')
    });
  }

  return next(req);
};
