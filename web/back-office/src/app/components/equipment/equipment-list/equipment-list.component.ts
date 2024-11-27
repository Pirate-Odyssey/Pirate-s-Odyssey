import { Component, OnInit, inject, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AlertService } from '@bo/alert';
import { ListComponent } from '@bo/common';

import {
  AddEquipmentRequest,
  EditEquipmentRequest,
  EquipmentResponse,
  EquipmentService
} from '../../../api';
import { EquipmentFormComponent } from '../equipment-form/equipment-form.component';

@Component({
  selector: 'bo-equipment-list',
  imports: [ListComponent],
  templateUrl: './equipment-list.component.html',
  styleUrl: './equipment-list.component.scss'
})
export class EquipmentListComponent implements OnInit {
  private readonly equipmentService = inject(EquipmentService);
  private readonly dialog = inject(MatDialog);
  private readonly alertService = inject(AlertService);

  public data = signal<EquipmentResponse[]>([]);

  displayedColumns = [
    'name',
    'rarity',
    'price',
    'description',
    'equipmentType',
    'armor'
  ];

  ngOnInit(): void {
    this.equipmentService.getEquipments().subscribe({
      next: (response) => {
        this.data.set(response);
      }
    });
  }

  addEquipment(): void {
    this.dialog
      .open<EquipmentFormComponent, undefined, AddEquipmentRequest>(
        EquipmentFormComponent
      )
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          this.equipmentService
            .addEquipment({
              addEquipmentRequest: result
            })
            .subscribe({
              next: (response) => {
                this.data.update((d) => [...d, response]);

                this.alertService.alert({
                  message: 'Equipment added successfully',
                  type: 'success'
                });
              }
            });
        }
      });
  }

  editEquipment(id: string): void {
    const item = this.data().find((i) => i.id === id);
    if (!item) return;

    this.dialog
      .open<EquipmentFormComponent, EquipmentResponse, EditEquipmentRequest>(
        EquipmentFormComponent,
        {
          data: item
        }
      )
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          this.equipmentService
            .editEquipment({
              id: id,
              editEquipmentRequest: result
            })
            .subscribe({
              next: (response) => {
                const index = this.data().findIndex((d) => d.id === id);
                if (index !== -1) {
                  this.data.update((d) => {
                    d[index] = response;
                    return [...d];
                  });

                  this.alertService.alert({
                    message: 'Equipment edited successfully',
                    type: 'success'
                  });
                }
              }
            });
        }
      });
  }

  deleteEquipment(id: string): void {
    this.alertService
      .confirm({
        okLabel: 'Delete',
        title: 'Delete Equipment',
        message: 'Are you sur to delete this equipment?',
        okButtonColor: 'warn'
      })
      .subscribe(() => {
        this.equipmentService
          .deleteEquipment({
            id: id
          })
          .subscribe({
            next: () => {
              this.data.update((d) => d.filter((dd) => dd.id !== id));

              this.alertService.alert({
                message: 'Equipment deleted successfully',
                type: 'success'
              });
            }
          });
      });
  }
}
