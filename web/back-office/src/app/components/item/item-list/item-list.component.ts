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
import {
  MatTable,
  MatTableDataSource,
  MatTableModule
} from '@angular/material/table';

import { ItemService } from '../../../api';
import { ItemListItem } from './item-list-datasource';

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
    MatIconModule
  ]
})
export class ItemListComponent implements OnInit, AfterViewInit {
  private readonly itemService = inject(ItemService);

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
}
