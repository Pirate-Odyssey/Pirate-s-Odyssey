import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'dashboard',
    loadComponent: () =>
      import('./components/dashboard/dashboard.component').then(
        (c) => c.DashboardComponent
      ),
    title: 'Dashboard'
  },
  {
    path: 'item',
    loadComponent: () =>
      import('./components/item-list/item-list.component').then(
        (c) => c.ItemListComponent
      ),
    title: 'Item'
  }
];
