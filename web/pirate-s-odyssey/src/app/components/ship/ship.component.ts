import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { CrewMemberService, ShipService } from '../../api';
import { BehaviorSubject, forkJoin } from 'rxjs';

interface CrewMember {
  name: string;
  health: number;
}

interface Upgrade {
  name: string;
  description: string;
  cost: number;
  resourceType: string;
}

interface Ship {
  id: string;
  name: string;
  minSeat: number;
  maxSeat: number;
  speed: number;
  health: number;
  crewMembers: CrewMember[];
}

@Component({
  selector: 'po-ship',
  templateUrl: './ship.component.html',
  standalone: true,
  styleUrls: ['./ship.component.scss'],
  imports: [CommonModule]
})
export class ShipComponent implements OnInit {
  private readonly shipService = inject(ShipService);
  private readonly crewMemberService = inject(CrewMemberService);

  // BehaviorSubject to hold the boat data
  boat = new BehaviorSubject<Ship | null>(null);
  boatHealthPercentage = new BehaviorSubject<number>(0);

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
    this.loadBoatData();
  }

  private loadBoatData(): void {
    forkJoin({
      boatResponse: this.shipService.getShips(),
      crewResponse: this.crewMemberService.getCrewMembers()
    }).subscribe(({ boatResponse, crewResponse }) => {
      if (boatResponse.length > 0) {
        const boatData = boatResponse[0];
        const mappedBoat: Ship = {
          ...boatData,
          crewMembers: crewResponse.map((member) => ({
            name: member.name,
            health: 100 // Valeur par défaut pour health
          }))
        };

        this.boat.next(mappedBoat); // Met à jour le BehaviorSubject `boat`
        this.boatHealthPercentage.next((mappedBoat.health / 1500) * 100); // Calcule le pourcentage de santé
      }
    });
  }

  applyUpgrade(upgrade: Upgrade) {
    console.log(`Applying upgrade: ${upgrade.name}`);
  }
}
