import { Component, computed, inject, input, model } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { AlertService } from '@bo/alert';
import { orderBy } from 'lodash';

import {
  AddItemStatRequest,
  EditItemStatRequest,
  ItemStatResponse,
  ItemStatService
} from '../../../api';
import { ItemStatFormComponent } from '../item-stat-form/item-stat-form.component';

@Component({
    selector: 'bo-item-stat-list',
    imports: [MatIconModule, MatListModule, MatButtonModule],
    templateUrl: './item-stat-list.component.html',
    styleUrl: './item-stat-list.component.scss'
})
export class ItemStatListComponent {
  private readonly itemStatService = inject(ItemStatService);
  private readonly dialog = inject(MatDialog);
  private readonly alertService = inject(AlertService);

  stats = model.required<ItemStatResponse[]>();
  itemId = input.required<string>();

  orderedStats = computed(() => orderBy(this.stats(), 'value', 'desc'));

  addItemStat(): void {
    this.dialog
      .open<ItemStatFormComponent, undefined, AddItemStatRequest>(
        ItemStatFormComponent
      )
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          result.itemId = this.itemId();

          this.itemStatService
            .addItemStat({
              addItemStatRequest: result
            })
            .subscribe({
              next: (response) => {
                this.stats.update((d) => [...d, response]);

                this.alertService.alert({
                  message: 'Item stat added successfully',
                  type: 'success'
                });
              }
            });
        }
      });
  }

  editItemStat(id: string): void {
    const itemStat = this.stats().find((i) => i.id === id);
    if (!itemStat) return;

    this.dialog
      .open<ItemStatFormComponent, ItemStatResponse, EditItemStatRequest>(
        ItemStatFormComponent,
        {
          data: itemStat
        }
      )
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          result.itemId = itemStat.itemId;

          this.itemStatService
            .editItemStat({
              id: id,
              editItemStatRequest: result
            })
            .subscribe({
              next: (response) => {
                const index = this.stats().findIndex((d) => d.id === id);
                if (index !== -1) {
                  this.stats.update((d) => {
                    d[index] = response;
                    return [...d];
                  });

                  this.alertService.alert({
                    message: 'Item stat edited successfully',
                    type: 'success'
                  });
                }
              }
            });
        }
      });
  }

  deleteItemStat(id: string): void {
    this.alertService
      .confirm({
        okLabel: 'Delete',
        title: 'Delete Item stat',
        message: 'Are you sur to delete this item stat?',
        okButtonColor: 'warn'
      })
      .subscribe(() => {
        this.itemStatService
          .deleteItemStat({
            id: id
          })
          .subscribe({
            next: () => {
              this.stats.update((d) => d.filter((dd) => dd.id !== id));

              this.alertService.alert({
                message: 'Item stat deleted successfully',
                type: 'success'
              });
            }
          });
      });
  }
}
