import { CommonModule } from '@angular/common';
import { Component, OnInit, Signal, inject, signal } from '@angular/core';
import { ShipService } from '../../api';
// import { Resources } from '../../models/resources.model';

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
  selector: 'po-ship',
  templateUrl: './ship.component.html',
  styleUrls: ['./ship.component.scss'],
  imports: [CommonModule]
})
export class ShipComponent implements OnInit {
  private readonly shipService = inject(ShipService);

  boatHealth: Signal<number> = signal(25);

  crewMembers: Signal<CrewMember[]> = signal([
    { name: 'Jack Sparrow', role: 'Captain', health: 100 },
    { name: 'Anne Bonny', role: 'First Mate', health: 90 },
    { name: 'Blackbeard', role: 'Gunner', health: 85 }
  ]);

  upgrades: Upgrade[] = [
    {
      name: 'Improved Sails',
      description: 'Increase speed',
      cost: 50,
      resourceType: 'wood'
    },
    {
      name: 'Reinforced Hull',
      description: 'Increase durability',
      cost: 100,
      resourceType: 'wood'
    },
    {
      name: 'Extra Cannons',
      description: 'Increase firepower',
      cost: 150,
      resourceType: 'iron'
    }
  ];

  ngOnInit(): void {
    this.shipService.getShips().subscribe((response) => {
      console.log(response);
    });
  }

  applyUpgrade(upgrade: Upgrade) {
    console.log(`Applying upgrade: ${upgrade.name}`);
  }
}
