import { CommonModule, JsonPipe } from '@angular/common';
import { Component, ViewChild, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDivider } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatDrawer, MatSidenavModule } from '@angular/material/sidenav';
import { RouterLink } from '@angular/router';
import { derivedFrom } from 'ngxtension/derived-from';
import { injectParams } from 'ngxtension/inject-params';
import { startWith, switchMap } from 'rxjs';

import { ItemService } from '../../../api';
import { SideContentComponent } from '../../common/side-content/side-content.component';

@Component({
  selector: 'bo-item-details',
  standalone: true,
  imports: [
    CommonModule,
    JsonPipe,
    MatSidenavModule,
    MatCardModule,
    MatDivider,
    RouterLink,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    SideContentComponent
  ],
  templateUrl: './item-details.component.html',
  styleUrl: './item-details.component.scss'
})
export class ItemDetailsComponent {
  private readonly itemService = inject(ItemService);
  itemId = injectParams('id');

  item = derivedFrom(
    [this.itemId],
    switchMap(([id]) =>
      this.itemService
        .getItem({
          id: id!
        })
        .pipe(startWith(null))
    )
  );
}
