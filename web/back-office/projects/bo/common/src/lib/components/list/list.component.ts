import { SelectionModel } from '@angular/cdk/collections';
import { NgPlural, NgPluralCase, TitleCasePipe } from '@angular/common';
import {
  AfterViewInit,
  Component,
  ViewChild,
  computed,
  effect,
  input,
  output
} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import {
  MatTable,
  MatTableDataSource,
  MatTableModule
} from '@angular/material/table';

@Component({
  selector: 'boc-list',
  imports: [
    TitleCasePipe,
    MatIconModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule,
    NgPlural,
    NgPluralCase
  ],
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss'
})
export class ListComponent<T = any> implements AfterViewInit {
  public data = input.required<T[]>();

  public displayedColumns = input.required<string[]>();

  public columns = computed(() => [...this.displayedColumns(), 'action']);

  public selectItem = output<string | undefined>();

  public readItem = output<string>();

  public addItem = output();

  public editItem = output<string>();

  public deleteItem = output<string>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<T>;
  dataSource = new MatTableDataSource<T>();

  selection = new SelectionModel<T>(false);

  constructor() {
    effect(() => {
      this.dataSource.data = this.data();
    });
    this.selection.changed.subscribe((value) => {
      this.selectItem.emit(
        (value.added[0]?.['id' as keyof T] as string) ?? undefined
      );
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

  getType(item?: any): string {
    if (Array.isArray(item)) return 'array';
    return typeof item;
  }
}
