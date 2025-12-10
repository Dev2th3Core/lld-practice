const crypto = require('crypto');

class ParkingLevel{
    constructor(){
        this.levelId = crypto.randomUUID();
        this.spots = [];
        this.availableSpots = new Map();
    }

    toString() {
        return `Level ${this.levelId}, Spots: ${this.spots.length}`;
    }
}

module.exports = ParkingLevel;