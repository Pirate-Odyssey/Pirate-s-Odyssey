import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

import { ItemRarity, WeaponResponse } from '../../../api';

@Component({
  selector: 'bo-weapon-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatSlideToggleModule
  ],
  templateUrl: './weapon-form.component.html',
  styleUrl: './weapon-form.component.scss'
})
export class WeaponFormComponent implements OnInit {
  private readonly data = inject<WeaponResponse>(MAT_DIALOG_DATA);
  private readonly dialogRef = inject<MatDialogRef<WeaponFormComponent>>(
    MatDialogRef<WeaponFormComponent>
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
    damage: this.fb.nonNullable.control(0, [
      Validators.required,
      Validators.min(1)
    ]),
    speed: this.fb.nonNullable.control(0, [
      Validators.required,
      Validators.min(0.1)
    ]),
    twoHanded: this.fb.nonNullable.control(false)
  });

  protected rarities = ItemRarity;

  ngOnInit(): void {
    if (this.data) {
      this.formGroup.setValue({
        description: this.data.description,
        name: this.data.name,
        price: this.data.price,
        rarity: this.data.rarity,
        damage: this.data.damage,
        speed: this.data.speed,
        twoHanded: this.data.twoHanded
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
