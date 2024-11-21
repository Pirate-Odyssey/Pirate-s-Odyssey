import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrewMemberListComponent } from './crew-member-list.component';

describe('CrewMemberListComponent', () => {
  let component: CrewMemberListComponent;
  let fixture: ComponentFixture<CrewMemberListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CrewMemberListComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(CrewMemberListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
