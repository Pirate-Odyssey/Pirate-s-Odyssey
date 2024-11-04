import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemContainerComponent } from './item-container.component';

describe('ItemContainerComponent', () => {
  let component: ItemContainerComponent;
  let fixture: ComponentFixture<ItemContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ItemContainerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItemContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
