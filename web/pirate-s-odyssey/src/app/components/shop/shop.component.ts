import { CommonModule } from '@angular/common';
import { Component, OnInit, computed, inject, signal } from '@angular/core';
import { ItemContainerComponent, SelectorComponent } from '@po/common';
import { EquipmentResponse, EquipmentService } from '../../api';

import { Button } from 'primeng/button';

@Component({
  selector: 'po-shop',
  templateUrl: './shop.component.html',
  standalone: true,
  styleUrls: ['./shop.component.scss'],
  imports: [CommonModule, ItemContainerComponent, SelectorComponent, Button]
})
export class ShopComponent implements OnInit {
  private readonly equipmentService = inject(EquipmentService);

  // Les options disponibles dans le shop (basées sur les types d'équipements)
  shopOptions = signal(['Helmet', 'Sword', 'Boots', 'Shield', 'Chestplate']);

  // Option sélectionnée par défaut
  selectedOption = signal(this.shopOptions()[0]);

  // Les items à afficher dans les lib-item-container
  shopItems = signal<EquipmentResponse[]>([]);

  // Propriété pour stocker les items filtrés
  filteredItems = computed(() =>
    this.shopItems().filter(
      (item) => item.equipmentType === this.selectedOption()
    )
  );

  ngOnInit(): void {
    // Appel de l'API pour obtenir les équipements
    this.equipmentService.getEquipments().subscribe({
      next: (response: EquipmentResponse[]) => {
        console.log('response', response);
        this.shopItems.set(response); // Utilisation directe de la réponse typée
      }
    });
  }

  // Méthode appelée lors du changement de sélection
  onSelectionChange(option: string) {
    this.selectedOption.set(option); // Mise à jour de la sélection avec le signal
  }
}
