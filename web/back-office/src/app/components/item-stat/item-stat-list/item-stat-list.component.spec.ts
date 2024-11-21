import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemStatListComponent } from './item-stat-list.component';

describe('ItemStatListComponent', () => {
  let component: ItemStatListComponent;
  let fixture: ComponentFixture<ItemStatListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ItemStatListComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(ItemStatListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
