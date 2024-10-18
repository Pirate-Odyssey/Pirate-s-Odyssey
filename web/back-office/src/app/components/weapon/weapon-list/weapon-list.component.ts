import { Component, OnInit, inject, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import {
  AddWeaponRequest,
  EditWeaponRequest,
  WeaponResponse,
  WeaponService
} from '../../../api';
import { ListComponent } from '../../common/list/list.component';
import { WeaponFormComponent } from '../weapon-form/weapon-form.component';

@Component({
  selector: 'bo-weapon-list',
  standalone: true,
  imports: [ListComponent],
  templateUrl: './weapon-list.component.html',
  styleUrl: './weapon-list.component.scss'
})
export class WeaponListComponent implements OnInit {
  private readonly weaponService = inject(WeaponService);
  private readonly dialog = inject(MatDialog);

  public data = signal<WeaponResponse[]>([]);

  displayedColumns = [
    'name',
    'rarity',
    'price',
    'description',
    'damage',
    'speed',
    'twoHanded'
  ];

  ngOnInit(): void {
    this.weaponService.getWeapons().subscribe({
      next: (response) => {
        this.data.set(response);
      }
    });
  }

  addWeapon(): void {
    this.dialog
      .open<WeaponFormComponent, undefined, AddWeaponRequest>(
        WeaponFormComponent
      )
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          this.weaponService
            .addWeapon({
              addWeaponRequest: result
            })
            .subscribe({
              next: (response) => {
                this.data.update((d) => [...d, response]);
              }
            });
        }
      });
  }

  editWeapon(id: string): void {
    const item = this.data().find((i) => i.id === id);
    if (!item) return;

    this.dialog
      .open<WeaponFormComponent, WeaponResponse, EditWeaponRequest>(
        WeaponFormComponent,
        {
          data: item
        }
      )
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          this.weaponService
            .editWeapon({
              id: id,
              editWeaponRequest: result
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

  deleteWeapon(id: string): void {
    this.weaponService
      .deleteWeapon({
        id: id
      })
      .subscribe({
        next: () => {
          this.data.update((d) => d.filter((dd) => dd.id !== id));
        }
      });
  }
}
