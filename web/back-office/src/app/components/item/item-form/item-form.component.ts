import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef
} from '@angular/material/dialog';

import { ItemRarity, ItemResponse } from '../../../api';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'bo-item-form',
  standalone: true,
  imports: [
    CommonModule,

    ReactiveFormsModule,

    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule
  ],
  templateUrl: './item-form.component.html',
  styleUrl: './item-form.component.scss'
})
export class ItemFormComponent implements OnInit {
  private readonly data = inject<ItemResponse>(MAT_DIALOG_DATA);
  private readonly dialogRef = inject<MatDialogRef<ItemFormComponent>>(
    MatDialogRef<ItemFormComponent>
  );
  private readonly fb = inject(FormBuilder);

  public formGroup = this.fb.group({
    name: this.fb.nonNullable.control('', Validators.required),
    description: this.fb.nonNullable.control('', Validators.required),
    rarity: this.fb.nonNullable.control('', Validators.required),
    price: this.fb.nonNullable.control(0, [
      Validators.required,
      Validators.min(1)
    ])
  });

  protected rarities = ItemRarity;

  ngOnInit(): void {
    if (this.data) {
      console.log(this.data);
      this.formGroup.setValue({
        description: this.data.description,
        name: this.data.name,
        price: this.data.price,
        rarity: this.data.rarity
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
