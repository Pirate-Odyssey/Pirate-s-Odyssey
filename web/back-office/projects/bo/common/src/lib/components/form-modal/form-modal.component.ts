import { Component, computed, input, output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
    selector: 'boc-form-modal',
    imports: [MatDialogModule, MatButtonModule],
    templateUrl: './form-modal.component.html',
    styleUrl: './form-modal.component.scss'
})
export class FormModalComponent {
  title = input.required<string>();

  isUpdate = input.required<boolean>();

  actionName = computed(() => (this.isUpdate() === true ? 'Edit' : 'Add'));

  onSubmit = output<void>();
}
