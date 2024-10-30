import { Injectable, inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import {
  MatSnackBar,
  MatSnackBarHorizontalPosition,
  MatSnackBarVerticalPosition
} from '@angular/material/snack-bar';
import { Observable, Subject } from 'rxjs';

import { AlertComponent, ConfirmationComponent } from '../components';
import { ConfirmationData } from '../components/confirmation/confirmation-data.interface';

@Injectable({
  providedIn: 'root'
})
export class AlertService {
  private readonly materialSnackbarService = inject(MatSnackBar);
  private readonly dialog = inject(MatDialog);

  public alert(data: {
    message: string;
    type: 'info' | 'warning' | 'error' | 'success';
    durationInSeconds?: number;
    hasAction?: boolean;
    horizontalPosition?: MatSnackBarHorizontalPosition;
    verticalPosition?: MatSnackBarVerticalPosition;
  }): void {
    this.materialSnackbarService.openFromComponent(AlertComponent, {
      duration: data.durationInSeconds ? data.durationInSeconds * 1000 : 2000,
      horizontalPosition: data.horizontalPosition ?? 'center',
      verticalPosition: data.verticalPosition ?? 'top',
      data: {
        type: data.type,
        content: data.message,
        hasAction: data.hasAction ?? false
      }
    });
  }

  public confirm(
    data?: ConfirmationData,
    maxWidth?: number
  ): Observable<boolean> {
    const subject = new Subject<boolean>();

    this.dialog
      .open(ConfirmationComponent, {
        data: data ?? {},
        maxWidth: maxWidth ? maxWidth : 328
      })
      .afterClosed()
      .subscribe((response) => {
        if (response) subject.next(true);
      });

    return subject;
  }
}
