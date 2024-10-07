import { Component, inject, OnInit, signal, Signal, WritableSignal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-boat',
  templateUrl: './boat.component.html',
  standalone: true,
  styleUrls: ['./boat.component.scss'],
  imports: [CommonModule]
})
export class BoatComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
  }
}
