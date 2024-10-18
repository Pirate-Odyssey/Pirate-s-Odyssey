import { Component, OnInit, inject, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import {
  AddShipRequest,
  EditShipRequest,
  ShipResponse,
  ShipService
} from '../../../api';
import { ListComponent } from '../../common/list/list.component';
import { ShipFormComponent } from '../ship-form/ship-form.component';

@Component({
  selector: 'bo-ship-list',
  standalone: true,
  imports: [ListComponent],
  templateUrl: './ship-list.component.html',
  styleUrl: './ship-list.component.scss'
})
export class ShipListComponent implements OnInit {
  private readonly shipService = inject(ShipService);
  private readonly dialog = inject(MatDialog);

  public data = signal<ShipResponse[]>([]);

  displayedColumns = ['name', 'minSeat', 'maxSeat', 'speed', 'health'];

  ngOnInit(): void {
    this.shipService.getShips().subscribe({
      next: (response) => {
        this.data.set(response);
      }
    });
  }

  addShip(): void {
    this.dialog
      .open<ShipFormComponent, undefined, AddShipRequest>(ShipFormComponent)
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          this.shipService
            .addShip({
              addShipRequest: result
            })
            .subscribe({
              next: (response) => {
                this.data.update((d) => [...d, response]);
              }
            });
        }
      });
  }

  editShip(id: string): void {
    const ship = this.data().find((i) => i.id === id);
    if (!ship) return;

    this.dialog
      .open<ShipFormComponent, ShipResponse, EditShipRequest>(
        ShipFormComponent,
        {
          data: ship
        }
      )
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          this.shipService
            .editShip({
              id: id,
              editShipRequest: result
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

  deleteShip(id: string): void {
    this.shipService
      .deleteShip({
        id: id
      })
      .subscribe({
        next: () => {
          this.data.update((d) => d.filter((dd) => dd.id !== id));
        }
      });
  }
}
