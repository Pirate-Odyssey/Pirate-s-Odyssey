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
import { CrewMemberResponse } from './crew-member-response';


export interface ShipResponse { 
    id: string;
    name: string;
    minSeat: number;
    maxSeat: number;
    speed: number;
    health: number;
    crewMembers: Array<CrewMemberResponse>;
}

