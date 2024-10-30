import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';

import { CrewResponse } from '../../../api';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'bo-crew-form',
  standalone: true,
  imports: [
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule
  ],
  templateUrl: './crew-form.component.html',
  styleUrl: './crew-form.component.scss'
})
export class CrewFormComponent implements OnInit {
  private readonly data = inject<CrewResponse>(MAT_DIALOG_DATA);
  private readonly dialogRef = inject<MatDialogRef<CrewFormComponent>>(
    MatDialogRef<CrewFormComponent>
  );
  private readonly fb = inject(FormBuilder);

  public formGroup = this.fb.group({
    name: this.fb.nonNullable.control('', Validators.required)
  });

  ngOnInit(): void {
    if (this.data) {
      this.formGroup.setValue({
        name: this.data.name
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