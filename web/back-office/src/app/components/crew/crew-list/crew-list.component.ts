import { Component, OnInit, inject, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AlertService } from '@bo/alert';
import { ListComponent } from '@bo/common';

import {
  AddCrewRequest,
  CrewResponse,
  CrewService,
  EditCrewRequest
} from '../../../api';
import { CrewFormComponent } from '../../crew/crew-form/crew-form.component';

@Component({
  selector: 'bo-crew-list',
  standalone: true,
  imports: [ListComponent],
  templateUrl: './crew-list.component.html',
  styleUrl: './crew-list.component.scss'
})
export class CrewListComponent implements OnInit {
  private readonly crewService = inject(CrewService);
  private readonly dialog = inject(MatDialog);
  private readonly alertService = inject(AlertService);

  public data = signal<CrewResponse[]>([]);

  displayedColumns = ['name'];

  ngOnInit(): void {
    this.crewService.getCrews().subscribe({
      next: (response) => {
        this.data.set(response);
      }
    });
  }

  addCrew(): void {
    this.dialog
      .open<CrewFormComponent, undefined, AddCrewRequest>(CrewFormComponent)
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          this.crewService
            .addCrew({
              addCrewRequest: result
            })
            .subscribe({
              next: (response) => {
                this.data.update((d) => [...d, response]);

                this.alertService.alert({
                  message: 'Crew added successfully',
                  type: 'success'
                });
              }
            });
        }
      });
  }

  editCrew(id: string): void {
    const crew = this.data().find((i) => i.id === id);
    if (!crew) return;

    this.dialog
      .open<CrewFormComponent, CrewResponse, EditCrewRequest>(
        CrewFormComponent,
        {
          data: crew
        }
      )
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          this.crewService
            .editCrew({
              id: id,
              editCrewRequest: result
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
                    message: 'Crew edited successfully',
                    type: 'success'
                  });
                }
              }
            });
        }
      });
  }

  deleteCrew(id: string): void {
    this.alertService
      .confirm({
        okLabel: 'Delete',
        title: 'Delete Crew',
        message: 'Are you sur to delete this crew?',
        okButtonColor: 'warn'
      })
      .subscribe(() => {
        this.crewService
          .deleteCrew({
            id: id
          })
          .subscribe({
            next: () => {
              this.data.update((d) => d.filter((dd) => dd.id !== id));

              this.alertService.alert({
                message: 'Crew deleted successfully',
                type: 'success'
              });
            }
          });
      });
  }
}
