const crypto = require('crypto');
import { SpotStatus } from '../enums/SpotStatus';

class ParkingSpot{
    constructor(spotType, levelId, x, y, z){
        this.spotId = crypto.randomUUID();
        this.spotType = spotType;
        this.spotStatus = SpotStatus.AVAILABLE;
        this.levelId = levelId;
        this.x = x;
        this.y = y;
        this.z = z;
    }

    toString(){
        return `SpotId: ${this.spotId}, Type: ${this.spotType}, Status: ${this.status}`;
    }
}

module.exports = ParkingSpot;