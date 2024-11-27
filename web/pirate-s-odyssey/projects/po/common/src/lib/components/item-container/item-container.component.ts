import { Component, input } from '@angular/core';

@Component({
  selector: 'poc-item-container',
  standalone: true,
  templateUrl: './item-container.component.html',
  styleUrl: './item-container.component.scss'
})
export class ItemContainerComponent {
  /**
   * input of a string, no default value, required
   *
   * @memberof ItemContainerComponent
   */
  itemName = input<string>();

  /**
   * input of a description, no default value
   *
   * @memberof ItemContainerComponent
   */
  itemDescription = input<string>();

  /**
   * input of a number, no default value
   *
   * @memberof ItemContainerComponent
   */
  itemPrice = input<number>();

  /**
   * input of a string, no default value
   *
   * @memberof ItemContainerComponent
   */
  itemRarity = input<string>();

  /**
   * input of a string, no default value, required
   *
   * @memberof ItemContainerComponent
   */
  buttonText = input<string>();

  // Méthode pour réagir au clic du bouton (ici, on log l'action)
  onButtonClick(): void {
    console.log(`${this.buttonText()} action triggered for ${this.itemName()}`);
  }
}
