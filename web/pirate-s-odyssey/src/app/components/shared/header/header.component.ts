import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';

import { Resources } from '../../../models/resources.model';

@Component({
  selector: 'po-header',
  standalone: true,
  imports: [RouterOutlet, CommonModule, RouterModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  resources: Resources[] = [
    { resourceType: 'Wood', amount: 150, img: 'wood' },
    { resourceType: 'Gold', amount: 50, img: 'gold' },
    { resourceType: 'Food', amount: 75, img: 'food' },
    { resourceType: 'Iron', amount: 10, img: 'iron' },
    { resourceType: 'Rhum', amount: 110, img: 'rhum' }
  ];
}
