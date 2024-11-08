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
import { CrewResponse } from './crew-response';
import { ShipResponse } from './ship-response';


export interface CrewMemberResponse { 
    id: string;
    name: string;
    crewId?: string | null;
    shipId?: string | null;
    crew?: CrewResponse;
    ship?: ShipResponse;
}

