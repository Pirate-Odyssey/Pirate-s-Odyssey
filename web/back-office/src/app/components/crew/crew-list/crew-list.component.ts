import { Component, OnInit, inject, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import {
  AddCrewRequest,
  CrewResponse,
  CrewService,
  EditCrewRequest
} from '../../../api';
import { ListComponent } from '../../common/list/list.component';
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
                }
              }
            });
        }
      });
  }

  deleteCrew(id: string): void {
    this.crewService
      .deleteCrew({
        id: id
      })
      .subscribe({
        next: () => {
          this.data.update((d) => d.filter((dd) => dd.id !== id));
        }
      });
  }
}
