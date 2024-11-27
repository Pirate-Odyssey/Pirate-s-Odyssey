import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { ItemService } from './api';
import { SignalRService } from './services/signal-r.service';

import { HeaderComponent } from './components/shared/header/header.component';

import { PrimeNGConfig } from 'primeng/api';

export interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

export type WeatherForecasts = WeatherForecast[];

@Component({
  selector: 'po-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  constructor(private primengConfig: PrimeNGConfig) {}
  title = 'pirate-s-odyssey';

  private readonly signalRService = inject(SignalRService);
  private readonly itemService = inject(ItemService);

  ngOnInit(): void {
    this.signalRService.startConnection().subscribe(() => {
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

    this.primengConfig.ripple = true;
  }

  sendMessage(message: string): void {
    this.signalRService.sendMessage(message);
  }
}
