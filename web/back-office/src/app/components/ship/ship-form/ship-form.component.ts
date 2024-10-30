import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormModalComponent } from '@bo/common';

import { ShipResponse } from '../../../api';

@Component({
  selector: 'bo-ship-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    FormModalComponent
  ],
  templateUrl: './ship-form.component.html',
  styleUrl: './ship-form.component.scss'
})
export class ShipFormComponent implements OnInit {
  private readonly data = inject<ShipResponse>(MAT_DIALOG_DATA);
  private readonly dialogRef = inject<MatDialogRef<ShipFormComponent>>(
    MatDialogRef<ShipFormComponent>
  );
  private readonly fb = inject(FormBuilder);

  public formGroup = this.fb.group({
    name: this.fb.nonNullable.control('', Validators.required),
    minSeat: this.fb.nonNullable.control(1, [
      Validators.required,
      Validators.min(1)
    ]),
    maxSeat: this.fb.nonNullable.control(1, [
      Validators.required,
      Validators.min(1)
    ]),
    speed: this.fb.nonNullable.control(0, [
      Validators.required,
      Validators.min(1)
    ]),
    health: this.fb.nonNullable.control(10, [
      Validators.required,
      Validators.min(1)
    ])
  });

  ngOnInit(): void {
    if (this.data) {
      this.formGroup.setValue({
        health: this.data.health,
        maxSeat: this.data.maxSeat,
        minSeat: this.data.minSeat,
        name: this.data.name,
        speed: this.data.speed
      });
    }
  }

  onSubmit(): void {
    if (this.formGroup.invalid) {
      this.formGroup.markAllAsTouched();
      return;
    }

    this.dialogRef.close(this.formGroup.value);
  }
}
