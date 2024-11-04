import { Component, computed, signal } from '@angular/core';
import { SelectorComponent } from '../../../../projects/po/common/src/lib/selector/selector.component';
import { CommonModule } from '@angular/common';
import { ItemContainerComponent } from '../../../../projects/po/common/src/lib/item-container/item-container.component';

@Component({
  selector: 'po-shop',
  templateUrl: './shop.component.html',
  standalone: true,
  styleUrls: ['./shop.component.scss'],
  imports: [CommonModule, SelectorComponent, ItemContainerComponent]
})
export class ShopComponent {
  // Les options disponibles dans le shop
  shopOptions = ['Sword', 'Boots', 'Shield'];

  // Option sélectionnée par défaut
  selectedOption = signal(this.shopOptions[0]);

  // Les items à afficher dans les lib-item-container
  shopItems = signal([
    {
      itemName: 'Sword',
      itemDescription: 'A sharp blade for close combat.',
      buttonText: 'Buy'
    },
    {
      itemName: 'Sword',
      itemDescription: 'A sharp blade for close combat.',
      buttonText: 'Buy'
    },
    {
      itemName: 'Sword',
      itemDescription: 'A sharp blade for close combat.',
      buttonText: 'Buy'
    },
    {
      itemName: 'Sword',
      itemDescription: 'A sharp blade for close combat.',
      buttonText: 'Buy'
    },
    {
      itemName: 'Sword',
      itemDescription: 'A sharp blade for close combat.',
      buttonText: 'Buy'
    },
    {
      itemName: 'Sword',
      itemDescription: 'A sharp blade for close combat.',
      buttonText: 'Buy'
    },
    {
      itemName: 'Sword',
      itemDescription: 'A sharp blade for close combat.',
      buttonText: 'Buy'
    },
    {
      itemName: 'Sword',
      itemDescription: 'A sharp blade for close combat.',
      buttonText: 'Buy'
    },
    {
      itemName: 'Sword',
      itemDescription: 'A sharp blade for close combat.',
      buttonText: 'Buy'
    },
    {
      itemName: 'Sword',
      itemDescription: 'A sharp blade for close combat.',
      buttonText: 'Buy'
    },
    {
      itemName: 'Boots',
      itemDescription: 'Fast and sturdy boots for quick movements.',
      buttonText: 'Buy'
    },
    {
      itemName: 'Shield',
      itemDescription: 'A strong shield to block incoming attacks.',
      buttonText: 'Buy'
    }
  ]);

  // Propriété pour stocker les items filtrés
  filteredItems = computed(() =>
    this.shopItems().filter((item) => item.itemName === this.selectedOption())
  );

  constructor() {}

  // Méthode appelée lors du changement de sélection
  onSelectionChange(option: string) {
    this.selectedOption.set(option); // Mise à jour de la sélection avec le signal
  }
}
