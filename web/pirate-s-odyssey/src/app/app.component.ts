import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SignalRService } from './services/signal-r.service';

export interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

export type WeatherForecasts = WeatherForecast[];

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'pirate-s-odyssey';
  forecasts: WeatherForecasts = [];

  private readonly signalRService = inject(SignalRService)

  constructor(private readonly http: HttpClient) {
    this.http.get<WeatherForecasts>('api/weatherforecast').subscribe({
      next: result => this.forecasts = result,
      error: console.error
    });
  }

  ngOnInit(): void {
    this.signalRService.startConnection().subscribe(() => {
      console.log('connection stared')
      this.signalRService.receiveMessage().subscribe((message) => {
        console.log(message);
      });
    });
  }

  sendMessage(message: string): void {
    this.signalRService.sendMessage(message);
  }
}
