import { Component, inject, OnInit, signal, Signal, WritableSignal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-exploration',
  templateUrl: './exploration.component.html',
  standalone: true,
  styleUrls: ['./exploration.component.scss'],
  imports: [CommonModule]
})
export class ExplorationComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
  }
}
