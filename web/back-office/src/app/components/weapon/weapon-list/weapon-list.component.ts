import { Component, OnInit, inject, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AlertService } from '@bo/alert';
import { ListComponent } from '@bo/common';

import {
  AddWeaponRequest,
  EditWeaponRequest,
  WeaponResponse,
  WeaponService
} from '../../../api';
import { WeaponFormComponent } from '../weapon-form/weapon-form.component';

@Component({
  selector: 'bo-weapon-list',
  imports: [ListComponent],
  templateUrl: './weapon-list.component.html',
  styleUrl: './weapon-list.component.scss'
})
export class WeaponListComponent implements OnInit {
  private readonly weaponService = inject(WeaponService);
  private readonly dialog = inject(MatDialog);
  private readonly alertService = inject(AlertService);

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

                this.alertService.alert({
                  message: 'Weapon added successfully',
                  type: 'success'
                });
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

                  this.alertService.alert({
                    message: 'Weapon edited successfully',
                    type: 'success'
                  });
                }
              }
            });
        }
      });
  }

  deleteWeapon(id: string): void {
    this.alertService
      .confirm({
        okLabel: 'Delete',
        title: 'Delete Weapon',
        message: 'Are you sur to delete this weapon?',
        okButtonColor: 'warn'
      })
      .subscribe(() => {
        this.weaponService
          .deleteWeapon({
            id: id
          })
          .subscribe({
            next: () => {
              this.data.update((d) => d.filter((dd) => dd.id !== id));

              this.alertService.alert({
                message: 'Weapon deleted successfully',
                type: 'success'
              });
            }
          });
      });
  }
}
