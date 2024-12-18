export * from './crew.service';
import { CrewService } from './crew.service';
export * from './crew-member.service';
import { CrewMemberService } from './crew-member.service';
export * from './equipment.service';
import { EquipmentService } from './equipment.service';
export * from './item.service';
import { ItemService } from './item.service';
export * from './item-stat.service';
import { ItemStatService } from './item-stat.service';
export * from './ship.service';
import { ShipService } from './ship.service';
export * from './weapon.service';
import { WeaponService } from './weapon.service';
export const APIS = [CrewService, CrewMemberService, EquipmentService, ItemService, ItemStatService, ShipService, WeaponService];
