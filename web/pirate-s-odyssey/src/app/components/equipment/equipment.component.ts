import { CommonModule } from '@angular/common';
import { Component, OnInit, computed, inject, signal } from '@angular/core';
import { ItemContainerComponent, SelectorComponent } from '@po/common';
import { EquipmentResponse, EquipmentService } from '../../api';

@Component({
  selector: 'po-equipment',
  templateUrl: './equipment.component.html',
  standalone: true,
  styleUrls: ['./equipment.component.scss'],
  imports: [CommonModule, ItemContainerComponent, SelectorComponent]
})
export class EquipmentComponent implements OnInit {
  private readonly equipmentService = inject(EquipmentService);

  // Les options disponibles dans le shop (basées sur les types d'équipements)
  shopOptions = ['Helmet', 'Sword', 'Boots', 'Shield'];

  // Option sélectionnée par défaut
  selectedOption = signal(this.shopOptions[0]);

  // Les items à afficher dans les lib-item-container
  shopItems = signal<EquipmentResponse[]>([]);

  // Propriété pour stocker les items filtrés
  filteredItems = computed(() =>
    this.shopItems().filter(
      (item) => item.equipmentType === this.selectedOption()
    )
  );

  // filteredItems = computed(() => {
  //   const items = this.shopItems().filter(
  //     (item) => item.equipmentType === this.selectedOption()
  //   );
  //   console.log(items); // Ajoutez ceci pour vérifier le contenu des items
  //   return items;
  // });

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
