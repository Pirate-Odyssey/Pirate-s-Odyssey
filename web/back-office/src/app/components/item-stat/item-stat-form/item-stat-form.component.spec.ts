import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemStatFormComponent } from './item-stat-form.component';

describe('ItemStatFormComponent', () => {
  let component: ItemStatFormComponent;
  let fixture: ComponentFixture<ItemStatFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ItemStatFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItemStatFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
