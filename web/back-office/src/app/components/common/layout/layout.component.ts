import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { AsyncPipe, NgTemplateOutlet } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';

import { routes } from '../../../app.routes';
import { ThemeService, ThemeType } from '../../../services/theme.service';
import { SideContentService } from '../../../services/side-content.service';

@Component({
  selector: 'bo-layout',
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss',
  standalone: true,
  imports: [
    NgTemplateOutlet,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    MatMenuModule,
    MatExpansionModule,
    AsyncPipe,
    RouterLink,
    RouterLinkActive
  ]
})
export class LayoutComponent {
  private readonly breakpointObserver = inject(BreakpointObserver);
  public readonly themeService = inject(ThemeService);
  public readonly sideContentService = inject(SideContentService);

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
      title: 'Weapon',
      path: 'weapon',
      icon: 'swords'
    },
    {
      title: 'Equipment',
      path: 'equipment',
      icon: 'shield'
    },
    {
      title: 'Ship',
      path: 'ship',
      icon: 'sailing'
    },
    {
      title: 'Crew',
      path: 'crew',
      icon: 'groups'
    },
    {
      title: 'Crew Member',
      path: 'crewMember',
      icon: 'person'
    }
  ];

  themes = [
    {
      label: 'Light theme',
      icon: 'light_mode',
      theme: 'light' as ThemeType
    },
    {
      label: 'Dark theme',
      icon: 'dark_mode',
      theme: 'dark' as ThemeType
    },
    {
      label: 'System theme',
      icon: 'computer',
      theme: 'auto' as ThemeType
    }
  ];
}
