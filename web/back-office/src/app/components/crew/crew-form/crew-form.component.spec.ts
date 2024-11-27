import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrewFormComponent } from './crew-form.component';

describe('CrewFormComponent', () => {
  let component: CrewFormComponent;
  let fixture: ComponentFixture<CrewFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CrewFormComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(CrewFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
