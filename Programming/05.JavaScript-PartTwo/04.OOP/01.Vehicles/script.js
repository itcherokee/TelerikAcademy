Function.prototype.inherit = function (parent) {
    this.prototype = new parent();
    this.prototype.constructor = parent;
}

function PropulsionUnit() {
}

function Weel(radius) {
    this.radius = radius;
    PropulsionUnit.apply(this, arguments);
}

Weel.inherit(PropulsionUnit);
Wheel.prototype.Accelerate = function () {
    var acceleration = 2 * Math.PI * this.radius;
    return acceleration;
}

function PropellingNozzle(power, afterburnerSwitch) {
    this.power = power;
    this.afterburnerSwitch = afterburnerSwitch;
    PropulsionUnit.apply(this, arguments);
}

PropellingNozzle.inherit(PropulsionUnit);
PropellingNozzle.prototype.Accelerate = function () {
    var accelaration;
    if (this.afterburnerSwitch) {
        accelaration = 2 * this.power;
    }
    else {
        accelaration = this.power;
    }

    return acceleration;
}

var spinDirectionEnum = {
    clockwise: true,
    counterClockwise: false
}

function Propeller(finNumber, spinDirection) {
    this.finNumber = finNumber;
    this.spinDirection = spinDirection;
    PropulsionUnit.apply(this, arguments);
}

Propeller.inherit(PropulsionUnit);
Propeller.prototype.Accelerate = function () {
    var acceleration;
    if (this.spinDirection) {
        acceleration = this.finNumber;
    }
    else {
        acceleration = -this.finNumber;
    }

    return acceleration;
}

function Vehicle(speed, propulsionUnits) {
    this.speed = speed;
    this.propulsionUnits = propulsionUnits;
}

Vehicle.prototype.acceleration = function () {
    var index = 0;
    for (index = 0; index < this.propulsionUnits.length; index++) {
        this.speed += this.propulsionUnits[index].Accelerate();
    }
}

function LandVehicle(speed, wheels) {
    Vehicle.apply(this, arguments);
}

LandVehicle.inherit(Vehicle);

function AirVehicle(speed, propellingNozzle) {
    Vehicle.apply(this, arguments);
}

AirVehicle.inherit(Vehicle);

AirVehicle.prototype.switchAfterburnerON = function () {
    this.propulsionUnits[0].afterburnerSwitch = true;
}

AirVehicle.prototype.switchAfterburnerOFF = function () {
    this.propulsionUnits[0].afterburnerSwitch = false;
}

function WaterVehicle(speed, propeller) {
    Vehicle.apply(this, arguments);
}

WaterVehicle.inherit(Vehicle);

AirVehicle.prototype.switchSpin = function () {
    this.propulsionUnits[0].spinDirection = !this.propulsionUnits[0].spinDirection;
}

function AmphibiousVehicle(speed, wheels, propeller) {
    this.wheels = wheels;
    this.propeller = propeller;
    Vehicle.apply(this, arguments);
}

AmphibiousVehicle.inherit(Vehicle);

// switch between two propulsion units not implemented