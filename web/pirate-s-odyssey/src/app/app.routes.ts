import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  {
    path: 'boat',
    loadComponent: () =>
      import('./components/boat/boat.component').then(
        (c) => c.BoatComponent
      ),
      title: 'Votre bateau'
  },
  {
    path: 'crew',
    loadComponent: () =>
      import('./components/crew/crew.component').then(
        (c) => c.CrewComponent
      ),
      title: 'Votre équipage'
  },
  {
    path: 'equipment',
    loadComponent: () =>
      import('./components/equipment/equipment.component').then(
        (c) => c.EquipmentComponent
      ),
      title: 'Votre équipement'
  },
  {
    path: 'exploration',
    loadComponent: () =>
      import('./components/exploration/exploration.component').then(
        (c) => c.ExplorationComponent
      ),
      title: 'Exploration'
  }
];
