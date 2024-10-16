import {
  AfterViewInit,
  Component,
  OnInit,
  ViewChild,
  inject
} from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import {
  MatTable,
  MatTableDataSource,
  MatTableModule
} from '@angular/material/table';

import { EquipmentService } from '../../../api';
import { EquipmentListItem } from './equipment-list-datasource';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'bo-equipment-list',
  standalone: true,
  imports: [
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatButtonModule
  ],
  templateUrl: './equipment-list.component.html',
  styleUrl: './equipment-list.component.scss'
})
export class EquipmentListComponent implements OnInit, AfterViewInit {
  private readonly equipmentService = inject(EquipmentService);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<EquipmentListItem>;
  dataSource = new MatTableDataSource<EquipmentListItem>();

  displayedColumns = [
    'name',
    'rarity',
    'price',
    'description',
    'equipmentType',
    'armor',
    'action'
  ];

  ngOnInit(): void {
    this.equipmentService.getEquipments().subscribe({
      next: (response) => {
        console.log(response);
        this.dataSource.data = response.map((e) => {
          return {
            description: e.description ?? '',
            id: e.id!,
            name: e.name!,
            price: e.price!,
            rarity: e.rarity!,
            armor: e.armor!,
            equipmentType: e.equipmentType!
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
