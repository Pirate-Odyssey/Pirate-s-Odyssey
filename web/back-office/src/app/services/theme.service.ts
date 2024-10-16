import { isPlatformBrowser } from '@angular/common';
import { Injectable, PLATFORM_ID, inject, signal } from '@angular/core';
import { Subject } from 'rxjs';

// Keep these constants in sync with the code in index.html

export const THEME_PREFERENCE_LOCAL_STORAGE_KEY = 'themePreference';
export const DARK_MODE_CLASS_NAME = 'dark-mode';
export const LIGHT_MODE_CLASS_NAME = 'light-mode';
export const PREFERS_COLOR_SCHEME_DARK = '(prefers-color-scheme: dark)';

export type ThemeType = 'dark' | 'light' | 'auto';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {
  private readonly platformId = inject(PLATFORM_ID);

  theme = signal<ThemeType>(this.getThemeFromLocalStorageValue());
  readonly theme$ = new Subject<ThemeType>();

  preferredScheme: 'dark' | 'light' = window.matchMedia(
    PREFERS_COLOR_SCHEME_DARK
  ).matches
    ? 'dark'
    : 'light';

  constructor() {
    if (!isPlatformBrowser(this.platformId)) {
      return;
    }
  }

  setTheme(theme: ThemeType): void {
    this.theme.set(theme);
    this.theme$.next(this.theme());
    this.setThemeInLocalStorage();
  }

  private getThemeFromLocalStorageValue(): ThemeType {
    const theme = localStorage.getItem(
      THEME_PREFERENCE_LOCAL_STORAGE_KEY
    ) as ThemeType;
    return theme ?? this.preferredScheme;
  }

  private setThemeInLocalStorage(): void {
    if (this.theme()) {
      localStorage.setItem(THEME_PREFERENCE_LOCAL_STORAGE_KEY, this.theme());
    }
  }
}
