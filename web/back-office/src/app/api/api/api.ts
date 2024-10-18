export * from './equipment.service';
import { EquipmentService } from './equipment.service';
export * from './item.service';
import { ItemService } from './item.service';
export * from './ship.service';
import { ShipService } from './ship.service';
export * from './weapon.service';
import { WeaponService } from './weapon.service';
export const APIS = [EquipmentService, ItemService, ShipService, WeaponService];
