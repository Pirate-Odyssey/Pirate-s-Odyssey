import { Component, OnInit, inject, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import {
  AddCrewMemberRequest,
  CrewMemberResponse,
  CrewMemberService,
  EditCrewMemberRequest
} from '../../../api';
import { ListComponent } from '../../common/list/list.component';
import { CrewMemberFormComponent } from '../crew-member-form/crew-member-form.component';

@Component({
  selector: 'bo-crew-member-list',
  standalone: true,
  imports: [ListComponent],
  templateUrl: './crew-member-list.component.html',
  styleUrl: './crew-member-list.component.scss'
})
export class CrewMemberListComponent implements OnInit {
  private readonly crewMemberService = inject(CrewMemberService);
  private readonly dialog = inject(MatDialog);

  public data = signal<CrewMemberResponse[]>([]);

  displayedColumns = ['name'];

  ngOnInit(): void {
    this.crewMemberService.getCrewMembers().subscribe({
      next: (response) => {
        this.data.set(response);
      }
    });
  }

  addCrewMember(): void {
    this.dialog
      .open<CrewMemberFormComponent, undefined, AddCrewMemberRequest>(
        CrewMemberFormComponent
      )
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          this.crewMemberService
            .addCrewMember({
              addCrewMemberRequest: result
            })
            .subscribe({
              next: (response) => {
                this.data.update((d) => [...d, response]);
              }
            });
        }
      });
  }

  editCrewMember(id: string): void {
    const crew = this.data().find((i) => i.id === id);
    if (!crew) return;

    this.dialog
      .open<CrewMemberFormComponent, CrewMemberResponse, EditCrewMemberRequest>(
        CrewMemberFormComponent,
        {
          data: crew
        }
      )
      .afterClosed()
      .subscribe({
        next: (result) => {
          if (!result) return;

          this.crewMemberService
            .editCrewMember({
              id: id,
              editCrewMemberRequest: result
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

  deleteCrewMember(id: string): void {
    this.crewMemberService
      .deleteCrewMember({
        id: id
      })
      .subscribe({
        next: () => {
          this.data.update((d) => d.filter((dd) => dd.id !== id));
        }
      });
  }
}
