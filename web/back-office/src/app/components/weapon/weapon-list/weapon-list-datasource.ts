import { ItemRarity } from '../../../api';

export interface WeaponListItem {
  description: string;
  id: string;
  name: string;
  price: number;
  rarity: ItemRarity;
  damage: number;
  speed: number;
  twoHanded: boolean;
}
