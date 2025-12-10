const { Car, Bike, Van } = require('./models/Vehicle');
const VehicleType = require('./enums/VehicleType');
const User = require('./models/User');

console.log('--- Parking Lot System Initialization ---');
console.log('--- Creating and Displaying Vehicles ---\n');

try {

    
    // Create an instance of a Car using the new Car class
    const car = new Car('CA-987-XYZ');
    console.log('Created a Car:');
    console.log(car);
    
    const user1 = new User('John Doe', [car]);
    console.log(user1.name);
    console.log(user1.vehicles);


    // Create an instance of a Bike using the new Bike class
    const bike = new Bike('NY-123-ABC');
    console.log('\nCreated a Bike:');
    console.log(bike);

    // Create an instance of a Van using the new Van class
    const van = new Van('TX-VAN-456');
    console.log('\nCreated a Van:');
    console.log(van);
} catch (error) {
    console.error('An error occurred during vehicle creation:', error.message);
}

console.log('\n--- Vehicle Creation Demo Finished ---');
