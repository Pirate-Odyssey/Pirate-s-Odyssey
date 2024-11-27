import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'po-crew',
  templateUrl: './crew.component.html',
  styleUrls: ['./crew.component.scss'],
  imports: [CommonModule]
})
export class CrewComponent {
  constructor(
    private route: ActivatedRoute,
    private router: Router
  ) {}
}
