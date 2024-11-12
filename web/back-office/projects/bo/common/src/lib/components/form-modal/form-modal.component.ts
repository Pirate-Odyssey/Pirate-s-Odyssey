import { Component, input, output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'boc-form-modal',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule],
  templateUrl: './form-modal.component.html',
  styleUrl: './form-modal.component.scss'
})
export class FormModalComponent {
  title = input.required<string>();

  onSubmit = output<void>();
}
