import { Component, inject, OnInit, signal, Signal, WritableSignal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-crew',
  templateUrl: './crew.component.html',
  standalone: true,
  styleUrls: ['./crew.component.scss'],
  imports: [CommonModule]
})
export class CrewComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
  }
}
