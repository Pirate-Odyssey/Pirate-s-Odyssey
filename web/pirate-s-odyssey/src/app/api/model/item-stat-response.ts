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
import { ItemResponse } from './item-response';
import { Stats } from './stats';


export interface ItemStatResponse { 
    id: string;
    stats: Stats;
    value: number;
    itemId: string;
    item?: ItemResponse;
}
export namespace ItemStatResponse {
}

