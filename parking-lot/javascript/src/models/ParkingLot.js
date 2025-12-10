const crypto = require('crypto');

class ParkingLot{
    constructor(name, address){
        if (!name || !name.trim()) {
            throw new Error('Parking lot name cannot be empty.');
        }
        if (!address || !address.trim()) {
            throw new Error('Parking lot address cannot be empty.');
        }
        this.lotId = crypto.randomUUID();
        this.name = name;
        this.address = address;
        this.levels = [];
        this.entrances = [];
    }

    /**
     * Returns a string representation of the parking lot.
     * @returns {string}
     */
    toString() {
        return `LotId: ${this.lotId}, Name: ${this.name}, Address: ${this.address}, Levels: ${this.levels.length}`;
    }
}

module.exports = ParkingLot;