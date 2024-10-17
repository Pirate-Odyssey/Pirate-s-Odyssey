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

import { WeaponService } from '../../../api';
import { WeaponListItem } from './weapon-list-datasource';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'bo-weapon-list',
  standalone: true,
  imports: [
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatButtonModule
  ],
  templateUrl: './weapon-list.component.html',
  styleUrl: './weapon-list.component.scss'
})
export class WeaponListComponent implements OnInit, AfterViewInit {
  private readonly weaponService = inject(WeaponService);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<WeaponListItem>;
  dataSource = new MatTableDataSource<WeaponListItem>();

  displayedColumns = [
    'name',
    'rarity',
    'price',
    'description',
    'damage',
    'speed',
    'twoHanded',
    'action'
  ];

  ngOnInit(): void {
    this.weaponService.getWeapons().subscribe({
      next: (response) => {
        this.dataSource.data = response;
      }
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }
}
