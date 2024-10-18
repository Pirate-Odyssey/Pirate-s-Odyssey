import { Component, OnInit, inject, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import {
  AddEquipmentRequest,
  EditEquipmentRequest,
  EquipmentResponse,
  EquipmentService
} from '../../../api';
import { ListComponent } from '../../common/list/list.component';
import { EquipmentFormComponent } from '../equipment-form/equipment-form.component';

@Component({
  selector: 'bo-equipment-list',
  standalone: true,
  imports: [ListComponent],
  templateUrl: './equipment-list.component.html',
  styleUrl: './equipment-list.component.scss'
})
export class EquipmentListComponent implements OnInit {
  private readonly equipmentService = inject(EquipmentService);
  private readonly dialog = inject(MatDialog);

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
                }
              }
            });
        }
      });
  }

  deleteEquipment(id: string): void {
    this.equipmentService
      .deleteEquipment({
        id: id
      })
      .subscribe({
        next: () => {
          this.data.update((d) => d.filter((dd) => dd.id !== id));
        }
      });
  }
}
