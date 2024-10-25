import { Component, Input } from '@angular/core';

@Component({
  selector: 'lib-item-container',
  standalone: true,
  imports: [],
  templateUrl: './item-container.component.html',
  styleUrl: './item-container.component.scss'
})
export class ItemContainerComponent {
  // Input pour le nom de l'objet
  @Input() itemName = '';

  // Input pour la description de l'objet
  @Input() itemDescription = '';

  // Input pour personnaliser le texte du bouton (buy, upgrade, craft, etc.)
  @Input() buttonText = 'Buy';

  // Méthode pour réagir au clic du bouton (ici, on log l'action)
  onButtonClick() {
    console.log(`${this.buttonText} action triggered for ${this.itemName}`);
  }
}
