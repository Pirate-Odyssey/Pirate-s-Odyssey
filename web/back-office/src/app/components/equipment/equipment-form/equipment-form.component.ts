import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { FormModalComponent } from '@bo/common';

import { EquipmentResponse, EquipmentType, ItemRarity } from '../../../api';

@Component({
  selector: 'bo-equipment-form',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    FormModalComponent
  ],
  templateUrl: './equipment-form.component.html',
  styleUrl: './equipment-form.component.scss'
})
export class EquipmentFormComponent implements OnInit {
  private readonly data = inject<EquipmentResponse>(MAT_DIALOG_DATA);
  private readonly dialogRef = inject<MatDialogRef<EquipmentFormComponent>>(
    MatDialogRef<EquipmentFormComponent>
  );
  private readonly fb = inject(FormBuilder);

  public formGroup = this.fb.group({
    name: this.fb.nonNullable.control('', Validators.required),
    description: this.fb.nonNullable.control('', Validators.required),
    rarity: this.fb.nonNullable.control('', Validators.required),
    price: this.fb.nonNullable.control(0, [
      Validators.required,
      Validators.min(1)
    ]),
    armor: this.fb.nonNullable.control(0, [
      Validators.required,
      Validators.min(1)
    ]),
    equipmentType: this.fb.nonNullable.control('', Validators.required)
  });

  protected rarities = ItemRarity;
  protected equipmentTypes = EquipmentType;

  isUpdate = !!this.data;

  ngOnInit(): void {
    if (this.data) {
      this.formGroup.setValue({
        description: this.data.description,
        name: this.data.name,
        price: this.data.price,
        rarity: this.data.rarity,
        armor: this.data.armor,
        equipmentType: this.data.equipmentType
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
