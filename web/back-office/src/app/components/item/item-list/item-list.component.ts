import {
  AfterViewInit,
  Component,
  OnInit,
  ViewChild,
  inject
} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';
import {
  MatTable,
  MatTableDataSource,
  MatTableModule
} from '@angular/material/table';

import {
  AddItemRequest,
  EditItemRequest,
  ItemResponse,
  ItemService
} from '../../../api';
import { ItemListItem } from './item-list-datasource';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialog } from '@angular/material/dialog';
import { ItemFormComponent } from '../item-form/item-form.component';

@Component({
  selector: 'bo-item-list',
  templateUrl: './item-list.component.html',
  styleUrl: './item-list.component.scss',
  standalone: true,
  imports: [
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule
  ]
})
export class ItemListComponent implements OnInit, AfterViewInit {
  private readonly itemService = inject(ItemService);
  private readonly dialog = inject(MatDialog);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<ItemListItem>;
  dataSource = new MatTableDataSource<ItemListItem>();

  displayedColumns = [
    'name',
    'type',
    'rarity',
    'price',
    'description',
    'action'
  ];

  ngOnInit(): void {
    this.itemService.getItems().subscribe({
      next: (response) => {
        this.dataSource.data = response.map((i) => {
          return {
            description: i.description ?? '',
            id: i.id!,
            name: i.name!,
            price: i.price!,
            rarity: i.rarity!,
            type: i.type!
          };
        });
      }
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
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
                this.dataSource.data.push(response);
                this.dataSource._updateChangeSubscription();
              }
            });
        }
      });
  }

  editItem(id: string): void {
    const item = this.dataSource.data.find((i) => i.id === id);
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
                const index = this.dataSource.data.findIndex(
                  (d) => d.id === id
                );
                if (index !== -1) {
                  this.dataSource.data[index] = response;
                  this.dataSource._updateChangeSubscription();
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
          const index = this.dataSource.data.findIndex((d) => d.id === id);
          if (index !== -1) {
            this.dataSource.data.splice(index, 1);
            this.dataSource._updateChangeSubscription();
          }
        }
      });
  }
}
