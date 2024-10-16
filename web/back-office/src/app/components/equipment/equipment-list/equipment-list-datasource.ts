import { EquipmentType, ItemRarity } from '../../../api';

export interface EquipmentListItem {
  description: string;
  id: string;
  name: string;
  price: number;
  rarity: ItemRarity;
  armor: number;
  equipmentType: EquipmentType;
}
