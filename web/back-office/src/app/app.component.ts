import { Component, HostBinding, OnInit, effect, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import {
  DARK_MODE_CLASS_NAME,
  LIGHT_MODE_CLASS_NAME,
  ThemeService
} from './services/theme.service';
import { LayoutComponent } from './components/common/layout/layout.component';
import { MatIconRegistry } from '@angular/material/icon';

@Component({
  selector: 'bo-root',
  imports: [RouterOutlet, LayoutComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  private readonly themeService = inject(ThemeService);
  private readonly matIconRegistry = inject(MatIconRegistry);

  title = 'back-office';

  @HostBinding('class')
  public class: string | undefined;

  constructor() {
    effect(() => {
      this.class =
        this.themeService.theme() === 'dark' ||
        (this.themeService.theme() === 'auto' &&
          this.themeService.preferredScheme === 'dark')
          ? DARK_MODE_CLASS_NAME
          : LIGHT_MODE_CLASS_NAME;
    });
  }

  ngOnInit(): void {
    this.themeService.initTheme();
    this.matIconRegistry.setDefaultFontSetClass('material-symbols-outlined');
  }
}
