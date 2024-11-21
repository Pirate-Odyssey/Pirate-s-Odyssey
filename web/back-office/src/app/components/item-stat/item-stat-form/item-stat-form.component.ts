import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormModalComponent } from '@bo/common';
import { ItemStatResponse, Stats } from '../../../api';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { KeyValuePipe } from '@angular/common';

@Component({
  selector: 'bo-item-stat-form',
  imports: [
    ReactiveFormsModule,
    FormModalComponent,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    KeyValuePipe
  ],
  templateUrl: './item-stat-form.component.html',
  styleUrl: './item-stat-form.component.scss'
})
export class ItemStatFormComponent implements OnInit {
  private readonly data = inject<ItemStatResponse>(MAT_DIALOG_DATA);
  private readonly dialogRef = inject<MatDialogRef<ItemStatFormComponent>>(
    MatDialogRef<ItemStatFormComponent>
  );
  private readonly fb = inject(FormBuilder);

  public formGroup = this.fb.group({
    value: this.fb.nonNullable.control(0, Validators.required),
    stats: this.fb.nonNullable.control('', Validators.required)
  });

  protected stats = Stats;

  isUpdate = !!this.data;

  ngOnInit(): void {
    if (this.data) {
      this.formGroup.setValue({
        value: this.data.value,
        stats: this.data.stats
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
