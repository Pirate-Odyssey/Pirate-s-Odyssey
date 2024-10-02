import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { ItemService } from './api';
import { SignalRService } from './services/signal-r.service';

@Component({
  selector: 'po-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'pirate-s-odyssey';

  private readonly signalRService = inject(SignalRService);
  private readonly itemService = inject(ItemService);

  ngOnInit(): void {
    this.signalRService.startConnection().subscribe(() => {
      console.log('connection stared');
      this.signalRService.receiveMessage().subscribe((message) => {
        console.log(message);
      });
    });

    this.itemService.getItems().subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  sendMessage(message: string): void {
    this.signalRService.sendMessage(message);
  }
}
