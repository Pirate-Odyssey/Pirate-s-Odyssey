import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrewMemberFormComponent } from './crew-member-form.component';

describe('CrewMemberFormComponent', () => {
  let component: CrewMemberFormComponent;
  let fixture: ComponentFixture<CrewMemberFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CrewMemberFormComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(CrewMemberFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
