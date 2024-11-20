import { Component, computed, inject } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import {
  MAT_SNACK_BAR_DATA,
  MatSnackBarModule,
  MatSnackBarRef
} from '@angular/material/snack-bar';

import { AlertData } from './alert-data.interface';
import { MatButtonModule } from '@angular/material/button';

@Component({
    selector: 'boa-alert',
    imports: [MatIconModule, MatSnackBarModule, MatButtonModule],
    templateUrl: './alert.component.html',
    styleUrl: './alert.component.scss'
})
export class AlertComponent {
  private readonly data = inject<AlertData>(MAT_SNACK_BAR_DATA);
  private readonly snackRef = inject(MatSnackBarRef<AlertComponent>);

  public type = computed(() => this.data.type);

  public content = computed(() => this.data.content);

  public hasAction = computed(() => this.data.hasAction);

  public close(): void {
    this.snackRef.dismiss();
  }
}
