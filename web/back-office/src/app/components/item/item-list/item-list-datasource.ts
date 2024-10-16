import { ItemRarity, ItemType } from '../../../api';

export interface ItemListItem {
  description: string;
  id: string;
  name: string;
  price: number;
  rarity: ItemRarity;
  type: ItemType;
}
