import { JsonPipe } from '@angular/common';
import { Component, inject, linkedSignal, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AlertService } from '@bo/alert';
import { ListComponent } from '@bo/common';
import { derivedFrom } from 'ngxtension/derived-from';
import { of, pipe, switchMap } from 'rxjs';

import { rxResource } from '@angular/core/rxjs-interop';
import {
  AddItemRequest,
  EditItemRequest,
  ItemResponse,
  ItemService
} from '../../../api';
import { SideContentComponent } from '../../common/side-content/side-content.component';
import { ItemFormComponent } from '../item-form/item-form.component';

@Component({
  selector: 'bo-item-list',
  templateUrl: './item-list.component.html',
  styleUrl: './item-list.component.scss',
  imports: [ListComponent, SideContentComponent, JsonPipe]
})
export class ItemListComponent {
  private readonly itemService = inject(ItemService);
  private readonly dialog = inject(MatDialog);
  private readonly alertService = inject(AlertService);
  private readonly router = inject(Router);

  public resourceData = rxResource({
    loader: () => this.itemService.getItems()
  });
  public data = linkedSignal(() =>
    this.resourceData.hasValue()
      ? (this.resourceData.value() as ItemResponse[])
      : []
  );

  public selectedItemId = signal<string | undefined>(undefined);
  public selectedItem = derivedFrom(
    [this.selectedItemId],
    pipe(
      switchMap(([id]) =>
        id != null
          ? this.itemService.getItem({
              id
            })
          : of(null)
      )
    ),
    {
      initialValue: null
    }
  );

  displayedColumns = [
    'name',
    'type',
    'rarity',
    'price',
    'description',
    'stats'
  ];

  readItem(id: string): void {
    void this.router.navigate(['item', id]);
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
