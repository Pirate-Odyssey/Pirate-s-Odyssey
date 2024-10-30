import { ThemePalette } from '@angular/material/core';

export interface ConfirmationData {
  title?: string;
  okLabel?: string;
  okButtonColor?: ThemePalette;
  cancelLabel?: string;
  message?: string;
}
