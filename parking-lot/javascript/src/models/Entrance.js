const crypto = require('crypto');

class Entrance{
    constructor(name, x, y, z){
        this.entranceId = crypto.randomUUID();
        this.name = name;
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

module.exports = Entrance;