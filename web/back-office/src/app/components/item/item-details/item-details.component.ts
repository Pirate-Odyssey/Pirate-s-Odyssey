import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDivider } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { injectParams } from 'ngxtension/inject-params';
import { DetailsComponent } from '../../../../../projects/bo/common/src/lib/components/details/details.component';
import { ItemService } from '../../../api';
import { SideContentComponent } from '../../common/side-content/side-content.component';
import { ItemStatListComponent } from '../../item-stat/item-stat-list/item-stat-list.component';

@Component({
  selector: 'bo-item-details',
  imports: [
    CommonModule,
    MatSidenavModule,
    MatCardModule,
    MatDivider,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    SideContentComponent,
    ItemStatListComponent,
    DetailsComponent
  ],
  templateUrl: './item-details.component.html',
  styleUrl: './item-details.component.scss'
})
export class ItemDetailsComponent {
  private readonly itemService = inject(ItemService);
  itemId = injectParams('id');

  item = rxResource({
    request: () => this.itemId(),
    loader: ({ request: id }) => this.itemService.getItem({ id: id! })
  });
}
