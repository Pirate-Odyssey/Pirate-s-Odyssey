import { isPlatformBrowser } from '@angular/common';
import { Injectable, PLATFORM_ID, inject, signal } from '@angular/core';

// Keep these constants in sync with the code in index.html

export const THEME_PREFERENCE_LOCAL_STORAGE_KEY = 'themePreference';
export const DARK_MODE_CLASS_NAME = 'dark-mode';
export const LIGHT_MODE_CLASS_NAME = 'light-mode';
export const PREFERS_COLOR_SCHEME_DARK = '(prefers-color-scheme: dark)';

export type Theme = 'dark' | 'light' | 'auto';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {
  private readonly platformId = inject(PLATFORM_ID);

  readonly theme = signal<Theme>(this.getThemeFromLocalStorageValue());

  constructor() {
    if (!isPlatformBrowser(this.platformId)) {
      return;
    }
  }

  setTheme(theme: Theme): void {
    this.theme.set(theme);
    this.setThemeInLocalStorage();
  }

  private getThemeFromLocalStorageValue(): Theme {
    const theme = localStorage.getItem(
      THEME_PREFERENCE_LOCAL_STORAGE_KEY
    ) as Theme;
    return theme ?? this.preferredScheme();
  }

  private setThemeInLocalStorage(): void {
    if (this.theme()) {
      localStorage.setItem(THEME_PREFERENCE_LOCAL_STORAGE_KEY, this.theme());
    }
  }

  public preferredScheme(): 'dark' | 'light' {
    return window.matchMedia(PREFERS_COLOR_SCHEME_DARK).matches
      ? 'dark'
      : 'light';
  }
}
