import { Component, OnInit, inject } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef
} from '@angular/material/dialog';
import { CrewFormComponent } from '../../crew/crew-form/crew-form.component';
import { CrewResponse } from '../../../api';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'bo-crew-member-form',
  standalone: true,
  imports: [
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule
  ],
  templateUrl: './crew-member-form.component.html',
  styleUrl: './crew-member-form.component.scss'
})
export class CrewMemberFormComponent implements OnInit {
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
