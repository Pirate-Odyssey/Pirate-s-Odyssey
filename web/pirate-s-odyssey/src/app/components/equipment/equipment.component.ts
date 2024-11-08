import { Component, inject, OnInit, signal, Signal, WritableSignal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-equipment',
  templateUrl: './equipment.component.html',
  standalone: true,
  styleUrls: ['./equipment.component.scss'],
  imports: [CommonModule]
})
export class EquipmentComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
  }
}
