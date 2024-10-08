import { CommonModule } from '@angular/common';
import { Component, Signal, signal } from '@angular/core';
import { Resources } from '../../models/resources.model';

interface CrewMember {
  name: string;
  role: string;
  health: number;
}

interface Upgrade {
  name: string;
  description: string;
  cost: number;
  resourceType: string;
}

@Component({
  selector: 'app-boat',
  templateUrl: './boat.component.html',
  standalone: true,
  styleUrls: ['./boat.component.scss'],
  imports: [CommonModule]
})
export class BoatComponent {
  boatHealth: Signal<number> = signal(25);

  crewMembers: Signal<CrewMember[]> = signal([
    { name: 'Jack Sparrow', role: 'Captain', health: 100 },
    { name: 'Anne Bonny', role: 'First Mate', health: 90 },
    { name: 'Blackbeard', role: 'Gunner', health: 85 }
  ]);

  upgrades: Upgrade[] = [
    { name: 'Improved Sails', description: 'Increase speed', cost: 50, resourceType: 'wood' },
    { name: 'Reinforced Hull', description: 'Increase durability', cost: 100, resourceType: 'wood' },
    { name: 'Extra Cannons', description: 'Increase firepower', cost: 150, resourceType: 'iron' }
  ];

  applyUpgrade(upgrade: Upgrade) {
    console.log(`Applying upgrade: ${upgrade.name}`);
  }
}
