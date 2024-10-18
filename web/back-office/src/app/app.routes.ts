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
      import('./components/item/item-list/item-list.component').then(
        (c) => c.ItemListComponent
      ),
    title: 'Item'
  },
  {
    path: 'equipment',
    loadComponent: () =>
      import(
        './components/equipment/equipment-list/equipment-list.component'
      ).then((c) => c.EquipmentListComponent),
    title: 'Equipment'
  },
  {
    path: 'weapon',
    loadComponent: () =>
      import('./components/weapon/weapon-list/weapon-list.component').then(
        (c) => c.WeaponListComponent
      ),
    title: 'Weapon'
  }
];
