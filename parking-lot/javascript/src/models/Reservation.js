const crypto = require('crypto')
import { ReservationStatus } from '../enums/ReservationStatus';

class Reservation{
    constructor(lotId, levelId, spotId, vehicleId, endTime, reservationTime){
        this.reservationId = crypto.randomUUID();
        this.lotId = lotId;
        this.levelId = levelId;
        this.spotId = spotId;
        this.vehicleId = vehicleId;
        this.startTime = new Date();
        this.endTime = endTime;
        this.status = ReservationStatus.ACTIVE;
    }

    toString(){
        return `ReservationId: ${this.reservationId}, Spot: ${this.spotId}, Status: ${this.status}, Start Time: ${this.startTime}, End Time: ${this.endTime}`
    }
}

module.exports = Reservation;