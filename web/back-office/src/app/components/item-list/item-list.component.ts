import {
  AfterViewInit,
  Component,
  OnInit,
  ViewChild,
  inject
} from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTable, MatTableModule } from '@angular/material/table';

import { ItemService } from '../../api';
import { ItemListDataSource, ItemListItem } from './item-list-datasource';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'bo-item-list',
  templateUrl: './item-list.component.html',
  styleUrl: './item-list.component.scss',
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule, MatSortModule, MatButtonModule]
})
export class ItemListComponent implements OnInit, AfterViewInit {
  private readonly itemService = inject(ItemService);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<ItemListItem>;
  dataSource = new ItemListDataSource();

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name'];

  ngOnInit(): void {
    this.itemService.getItems().subscribe({
      next: (response) => {
        console.log(response);
      }
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }
}
