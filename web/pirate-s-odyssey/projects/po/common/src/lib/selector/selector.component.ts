import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'lib-selector',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './selector.component.html',
  styleUrl: './selector.component.scss'
})
export class SelectorComponent<T> {
  // Input générique pour passer la liste d'éléments
  @Input() options: T[] = [];

  // Input pour définir la propriété à utiliser comme clé si les options sont des objets
  @Input() displayKey: keyof T | null = null;

  // Input pour la valeur sélectionnée
  @Input() selectedValue: T | null = null;

  // Sortir l'événement lorsque l'utilisateur sélectionne un élément
  @Output() selectionChange = new EventEmitter<T>();

  // Méthode appelée lorsque l'utilisateur sélectionne un élément
  onSelect(option: T) {
    this.selectedValue = option;
    this.selectionChange.emit(option); // Émettre l'option sélectionnée
  }

  // Méthode pour afficher l'option selon la clé passée
  getDisplayText(option: T): string {
    if (!option) {
      return ''; // Return empty string if null or undefined
    }

    if (this.displayKey && typeof option === 'object') {
      return option[this.displayKey] as unknown as string;
    }

    return option as unknown as string; // Sinon, retourne l'option elle-même
  }
}
