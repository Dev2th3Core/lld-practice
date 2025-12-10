const crypto = require('crypto');
const VehicleType = require('../enums/VehicleType');

class  Vehicle {
    constructor(vehicleType, licensePlate) {
        this.vehicleId = crypto.randomUUID();
        this.vehicleType = vehicleType;
        this.licensePlate = licensePlate;
    }
}

class Car extends Vehicle {
    constructor(licensePlate) {
        super( VehicleType.CAR , licensePlate);
    }
}

class Bike extends Vehicle {
    constructor(licensePlate) {
        super(VehicleType.BIKE, licensePlate);
    }
}

class Van extends Vehicle {
    constructor(licensePlate) {
        super(VehicleType.VAN, licensePlate);
    }
}

module.exports = {
    Vehicle,
    Car,
    Bike,
    Van
}