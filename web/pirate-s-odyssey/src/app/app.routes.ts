import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  {
    path: 'boat',
    loadComponent: () =>
      import('./components/boat/boat.component').then((c) => c.BoatComponent),
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
