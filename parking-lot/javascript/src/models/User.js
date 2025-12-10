const crypto = require('crypto');
const { Vehicle } = require('./Vehicle');

/**
 * Represents a user of the parking lot system.
 */
class User{
    /**
     * Creates a new User instance.
     * @param {string} name - The name of the user.
     * @param {Vehicle[]} vehicles - The list of vehicles associated with the user.
     */
    constructor(name = '', vehicles = []) {
        /**
         * The unique identifier for the user.
         * @type {string}
         */
        this.userId = crypto.randomUUID();
        /**
         * The name of the user.
         * @type {string}
         */
        this.name = name;
        /**
         * The list of vehicles associated with the user.
         * @type {Vehicle[]}
         */
        this.vehicles = vehicles;
    }
}

module.exports = User;