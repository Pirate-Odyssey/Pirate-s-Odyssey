import {
  Component,
  HostBinding,
  OnInit,
  computed,
  inject
} from '@angular/core';
import { RouterOutlet } from '@angular/router';

import {
  DARK_MODE_CLASS_NAME,
  LIGHT_MODE_CLASS_NAME,
  ThemeService
} from './services/theme.service';
import { LayoutComponent } from './components/layout/layout.component';
import { MatIconRegistry } from '@angular/material/icon';

@Component({
  selector: 'bo-root',
  standalone: true,
  imports: [RouterOutlet, LayoutComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  private readonly themeService = inject(ThemeService);
  private readonly matIconRegistry = inject(MatIconRegistry);

  ngOnInit(): void {
    this.matIconRegistry.setDefaultFontSetClass('material-symbols-outlined');
  }

  title = 'back-office';

  @HostBinding('class')
  public class = computed((): string => {
    if (
      this.themeService.theme() === 'dark' ||
      (this.themeService.theme() === 'auto' &&
        this.themeService.preferredScheme() === 'dark')
    ) {
      return DARK_MODE_CLASS_NAME;
    } else {
      return LIGHT_MODE_CLASS_NAME;
    }
  })();
}
