/**
 * Pirate\'s Odyssey - API
 * Swagger for Pirate\'s Odyssey API
 *
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { ItemRarity } from './item-rarity';


export interface AddWeaponRequest { 
    damage?: number;
    speed?: string;
    twoHanded?: boolean;
    name?: string | null;
    description?: string | null;
    rarity?: ItemRarity;
    price?: number;
}
export namespace AddWeaponRequest {
}

