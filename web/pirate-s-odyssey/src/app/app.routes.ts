import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  {
    path: 'ship',
    loadComponent: () =>
      import('./components/ship/ship.component').then((c) => c.ShipComponent),
    title: 'Bateau'
  },
  {
    path: 'crew',
    loadComponent: () =>
      import('./components/crew/crew.component').then((c) => c.CrewComponent),
    title: 'Equipage'
  },
  {
    path: 'equipment',
    loadComponent: () =>
      import('./components/equipment/equipment.component').then(
        (c) => c.EquipmentComponent
      ),
    title: 'Equipement'
  },
  {
    path: 'exploration',
    loadComponent: () =>
      import('./components/exploration/exploration.component').then(
        (c) => c.ExplorationComponent
      ),
    title: 'Exploration'
  },
  {
    path: 'shop',
    loadComponent: () =>
      import('./components/shop/shop.component').then((c) => c.ShopComponent),
    title: 'Shop'
  }
];
