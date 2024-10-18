import { Component, OnInit, inject, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import {
  AddItemRequest,
  EditItemRequest,
  ItemResponse,
  ItemService
} from '../../../api';
import { ListComponent } from '../../common/list/list.component';
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
                }
              }
            });
        }
      });
  }

  deleteItem(id: string): void {
    this.itemService
      .deleteItem({
        id: id
      })
      .subscribe({
        next: () => {
          this.data.update((d) => d.filter((dd) => dd.id !== id));
        }
      });
  }
}