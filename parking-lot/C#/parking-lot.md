# Parking Lot System - Low Level Design Documentation

## 1. Object-Oriented Design Principles Used

### 1.1 Encapsulation
- Private fields with public properties (e.g., `_name` and `_address` in `ParkingLot` class)
- Data validation in setters (e.g., checking for null/empty strings)
- Classes are well-encapsulated with clear responsibilities

### 1.2 Abstraction
- Interface definition (`IVehicleFactory`)
- Service layer abstractions (`ParkingLotService`, `VehicleService`)
- Clear separation of concerns between different components

### 1.3 Inheritance
- Vehicle hierarchy (Base `Vehicle` class with specific implementations like `Car`, `Bike`, `Van`)

### 1.4 Polymorphism
- Vehicle creation through factory pattern
- Different vehicle types handling through common interface

## 2. Design Patterns

### 2.1 Factory Pattern
- `IVehicleFactory` interface
- `VehicleFactory` implementation
- Used for creating different types of vehicles (Car, Bike, Van)
- Encapsulates object creation logic

### 2.2 Singleton Pattern (implied in services)
- Services maintain single instances of resources
- Centralized management of parking lots and vehicles

## 3. Concurrency Handling

### 3.1 Thread-Safe Collections
- `ConcurrentDictionary` used in `ParkingLevel` for managing available spots
- Ensures thread-safe operations when multiple users try to park simultaneously
- Prevents race conditions in spot allocation

## 4. Exception Handling

### 4.1 Validation Exceptions
- Input validation for parking lot name and address
- Proper exception throwing with meaningful messages
- Custom exception handling for:
  - Invalid vehicle types
  - Not found scenarios (lots, levels, spots)
  - Invalid input parameters

### 4.2 Business Logic Exceptions
- Spot availability checks
- Vehicle type compatibility validation
- Resource not found scenarios

## 5. Core Components

### 5.1 Models
1. `ParkingLot`
   - Represents the main facility
   - Contains levels and entrances
   - Unique identification through GUID

2. `ParkingLevel`
   - Represents a floor in the parking lot
   - Manages spots through thread-safe collections
   - Tracks available and occupied spots

3. `ParkingSpot`
   - Individual parking spaces
   - Type-specific (CAR, BIKE, VAN)
   - Status tracking (Available/Occupied)

### 5.2 Services

1. `ParkingLotService`
   - Core business logic for parking operations
   - Spot management and allocation
   - Status monitoring and reporting
   - Key functionalities:
     - Adding new parking lots
     - Managing levels and spots
     - Finding available spots
     - Status display

## 6. Enumerations

1. `VehicleType`
   - CAR
   - BIKE
   - VAN

2. `SpotStatus`
   - Available
   - Occupied

3. `ReservationStatus`
   - Active
   - Completed
   - Cancelled

## 7. Best Practices Implemented

1. SOLID Principles
   - Single Responsibility Principle (each class has a specific purpose)
   - Open/Closed Principle (new vehicle types can be added without modifying existing code)
   - Interface Segregation (clean interfaces)
   - Dependency Inversion (using interfaces for vehicle creation)

2. Code Documentation
   - XML documentation for classes and methods
   - Clear method descriptions
   - Parameter documentation
   - Exception documentation

3. Error Handling
   - Proper validation of inputs
   - Meaningful error messages
   - Exception propagation
   - Null checking

4. Immutability
   - Use of required properties
   - Readonly collections where appropriate
   - Thread-safe data structures

## 8. Extensibility Points

1. New Vehicle Types
   - Add new vehicle type to enum
   - Implement new vehicle class
   - Update factory

2. New Parking Strategies
   - Can implement different allocation strategies
   - Can add new spot types

3. Payment Integration
   - Structure allows for adding payment processing
   - Can extend reservation system
