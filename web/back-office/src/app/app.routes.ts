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
  },
  {
    path: 'ship',
    loadComponent: () =>
      import('./components/ship/ship-list/ship-list.component').then(
        (c) => c.ShipListComponent
      ),
    title: 'ship'
  },
  {
    path: 'crew',
    loadComponent: () =>
      import('./components/crew/crew-list/crew-list.component').then(
        (c) => c.CrewListComponent
      ),
    title: 'ship'
  },
  {
    path: 'crewMember',
    loadComponent: () =>
      import(
        './components/crew-member/crew-member-list/crew-member-list.component'
      ).then((c) => c.CrewMemberListComponent),
    title: 'ship'
  }
];
