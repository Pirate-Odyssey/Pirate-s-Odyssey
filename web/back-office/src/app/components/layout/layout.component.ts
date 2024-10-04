import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { routes } from '../../app.routes';

@Component({
  selector: 'bo-layout',
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss',
  standalone: true,
  imports: [
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    MatExpansionModule,
    AsyncPipe,
    RouterLink,
    RouterLinkActive
  ]
})
export class LayoutComponent {
  private breakpointObserver = inject(BreakpointObserver);

  rootRoutes = routes.filter((r) => r.path);

  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(
      map((result) => result.matches),
      shareReplay()
    );

  menuItems = [
    {
      title: 'Dashboard',
      path: 'dashboard',
      icon: 'dashboard'
    },
    {
      title: 'Item',
      path: 'item',
      icon: 'category'
    },
    {
      title: 'Equipment',
      path: '',
      icon: 'swords'
    }
  ];
}
