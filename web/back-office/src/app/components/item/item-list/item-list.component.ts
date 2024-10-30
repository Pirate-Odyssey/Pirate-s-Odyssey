import { Component, OnInit, inject, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AlertService } from '@bo/alert';
import { ListComponent } from '@bo/common';

import {
  AddItemRequest,
  EditItemRequest,
  ItemResponse,
  ItemService
} from '../../../api';
import { ItemFormComponent } from '../item-form/item-form.component';

@Component({
  selector: 'bo-item-list',
  templateUrl: './item-list.component.html',
  styleUrl: './item-list.component.scss',
  standalone: true,
  imports: [ListComponent]
})
export class ItemListComponent implements OnInit {
  private readonly itemService = inject(ItemService);
  private readonly dialog = inject(MatDialog);
  private readonly alertService = inject(AlertService);

  public data = signal<ItemResponse[]>([]);

  displayedColumns = ['name', 'type', 'rarity', 'price', 'description'];

  ngOnInit(): void {
    this.itemService.getItems().subscribe({
      next: (response) => {
        this.data.set(response);
      }
    });
  }

  addItem(): void {
    this.dialog
      .open<ItemFormComponent, undefined, AddItemRequest>(ItemFormComponent)
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          this.itemService
            .addItem({
              addItemRequest: result
            })
            .subscribe({
              next: (response) => {
                this.data.update((d) => [...d, response]);

                this.alertService.alert({
                  message: 'Item added successfully',
                  type: 'success'
                });
              }
            });
        }
      });
  }

  editItem(id: string): void {
    const item = this.data().find((i) => i.id === id);
    if (!item) return;

    this.dialog
      .open<ItemFormComponent, ItemResponse, EditItemRequest>(
        ItemFormComponent,
        {
          data: item
        }
      )
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          this.itemService
            .editItem({
              id: id,
              editItemRequest: result
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
                    message: 'Item edited successfully',
                    type: 'success'
                  });
                }
              }
            });
        }
      });
  }

  deleteItem(id: string): void {
    this.alertService
      .confirm({
        okLabel: 'Delete',
        title: 'Delete Item',
        message: 'Are you sur to delete this item?',
        okButtonColor: 'warn'
      })
      .subscribe(() => {
        this.itemService
          .deleteItem({
            id: id
          })
          .subscribe({
            next: () => {
              this.data.update((d) => d.filter((dd) => dd.id !== id));

              this.alertService.alert({
                message: 'Item deleted successfully',
                type: 'success'
              });
            }
          });
      });
  }
}
