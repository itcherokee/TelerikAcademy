function processEstatesAgencyCommands(commands) {

    'use strict';

    var estateType = {
            unknown: 'unknown',
            apartment: 'Apartment',
            office: 'Office',
            house: 'House',
            garage: 'Garage'
        },
        offerType = {
            unknown: 'unknown',
            rent: 'Rent',
            sale: 'Sale'
        },
        CONSTS = {
            MIN_AREA: 1,
            MAX_AREA: 10000,
            MIN_ROOMS: 0,
            MAX_ROOMS: 100,
            MIN_FLOORS: 1,
            MAX_FLOORS: 10,
            MIN_WIDTH: 1,
            MAX_WIDTH: 500,
            MIN_HEIGHT: 1,
            MAX_HEIGHT: 500
        };

    function validateNonEmptyString(value) {
        return typeof(value) === 'string' && value.length > 0;
    }

    function validateRange(minRange, maxRange, prop) {
        if (isNaN(minRange)) {
            throw new TypeError();
        }

        if (isNaN(maxRange)) {
            throw new TypeError();
        }

        if (isNaN(prop)) {
            throw new TypeError();
        }

        return (minRange <= prop && prop <= maxRange);
    }

    function validateBoolean(value) {
        return typeof(value) === 'boolean';
    }

    function validatePositiveInteger(value) {
        return !isNaN(value) && isFinite(value) && ((value | 0) === value) && value >= 0;
    }

    var estate = (function () {
        var estate = {};
        Object.defineProperties(estate, {
            name: {
                get: function () {
                    if (typeof (this._name) === 'undefined') {
                        throw new Error();
                    } else {
                        return this._name;
                    }
                },
                set: function (value) {
                    if (validateNonEmptyString(value)) {
                        this._name = value;
                    } else {
                        throw new Error();
                    }
                },
                enumerable: true,
                configurable: true
            },
            location: {
                get: function () {
                    if (typeof (this._location) === 'undefined') {
                        throw new Error();
                    } else {
                        return this._location;
                    }
                },
                set: function (value) {
                    if (validateNonEmptyString(value)) {
                        return this._location = value;
                    } else {
                        throw new Error();
                    }
                },
                enumerable: true,
                configurable: true
            },
            area: {
                get: function () {
                    if (typeof (this._area) === 'undefined') {
                        throw new Error();
                    } else {
                        return this._area;
                    }
                },
                set: function (value) {
                    if (validateRange(CONSTS.MIN_AREA, CONSTS.MAX_AREA, value)) {
                        this._area = value;
                    } else {
                        throw new Error();
                    }
                },
                enumerable: true,
                configurable: true
            },
            isFurnitured: {
                get: function () {
                    if (typeof (this._isFurnitured) === 'undefined') {
                        throw new Error();
                    } else {
                        return this._isFurnitured;
                    }
                },
                set: function (value) {
                    if (validateBoolean(value)) {
                        this._isFurnitured = value;
                    } else {
                        throw new Error();
                    }
                },
                enumerable: true,
                configurable: true
            },
            type: {
                value: estateType.unknown,
                writable: true,
                enumerable: true
            },
            init: {
                value: function (name, area, location, isFurnitured) {
                    this.name = name;
                    this.area = area;
                    this.location = location;
                    this.isFurnitured = isFurnitured;

                    return this;
                },
                enumerable: true,
                configurable: true
            },
            toString: {
                value: function () {
                    var output = this.type + ':';
                    output += ' Name = ' + this.name;
                    output += ', Area = ' + this.area;
                    output += ', Location = ' + this.location;
                    output += ', Furnitured = ' + (this.isFurnitured ? 'Yes' : 'No');

                    return output;
                },
                enumerable: true,
                configurable: true
            }
        });

        return estate;
    })();

    var buildingEstate = (function (parent) {
        var buildingEstate = Object.create(parent);
        Object.defineProperties(buildingEstate, {
            rooms: {
                get: function () {
                    if (typeof (this._rooms) === 'undefined') {
                        throw new Error();
                    } else {
                        return this._rooms;
                    }
                },
                set: function (value) {
                    if (validateRange(CONSTS.MIN_ROOMS, CONSTS.MAX_ROOMS, value)) {
                        this._rooms = value;
                    } else {
                        throw new Error();
                    }
                },
                enumerable: true,
                configurable: true,
            },
            hasElevator: {
                get: function () {
                    if (typeof (this._hasElevator) === 'undefined') {
                        throw new Error();
                    } else {
                        return this._hasElevator;
                    }
                },
                set: function (value) {
                    if (validateBoolean(value)) {
                        this._hasElevator = value;
                    } else {
                        throw new Error();
                    }
                },
                enumerable: true,
                configurable: true,
            },
            init: {
                value: function (name, area, location, isFurnitured, rooms, hasElevator) {
                    parent.init.call(this, name, area, location, isFurnitured);
                    this.rooms = rooms;
                    this.hasElevator = hasElevator;

                    return this;
                },
                enumerable: true,
                configurable: true
            },
            toString: {
                value: function () {
                    var output = parent.toString.call(this);
                    output += ', Rooms: ' + this.rooms;
                    output += ', Elevator: ' + (this.hasElevator ? 'Yes' : 'No');

                    return output;
                },
                enumerable: true,
                configurable: true
            }
        });

        return buildingEstate;
    })(estate);

    var apartment = (function (parent) {
        var apartment = Object.create(parent);
        Object.defineProperties(apartment, {
            init: {
                value: function (name, area, location, isFurnitured, rooms, hasElevator) {
                    parent.init.call(this, name, area, location, isFurnitured, rooms, hasElevator);

                    return this;
                },
                enumerable: true,
                configurable: true
            }
        });

        apartment.type = estateType.apartment;

        return apartment;
    })(buildingEstate);

    var office = (function (parent) {
        var office = Object.create(parent);
        Object.defineProperties(office, {
            init: {
                value: function (name, area, location, isFurnitured, rooms, hasElevator) {
                    parent.init.call(this, name, area, location, isFurnitured, rooms, hasElevator);

                    return this;
                },
                enumerable: true,
                configurable: true
            }
        });

        office.type = estateType.office;

        return office;
    })(buildingEstate);

    var house = (function (parent) {
        var house = Object.create(parent);
        Object.defineProperties(house, {
            floors: {
                get: function () {
                    if (typeof (this._floors) === 'undefined') {
                        throw new Error();
                    } else {
                        return this._floors;
                    }
                },
                set: function (value) {
                    if (validateRange(CONSTS.MIN_FLOORS, CONSTS.MAX_FLOORS, value)) {
                        this._floors = value;
                    } else {
                        throw new Error();
                    }
                },
                enumerable: true,
                configurable: false,
            },
            init: {
                value: function (name, area, location, isFurnitured, floors) {
                    parent.init.call(this, name, area, location, isFurnitured);
                    this.floors = floors;

                    return this;
                },
                enumerable: true,
                configurable: true
            },
            //  House: Name = houseSofia, Area = 120, Location = Sofia, Furnitured = Yes, Floors: 1
            toString: {
                value: function () {
                    var output = parent.toString.call(this);
                    output += ', Floors: ' + this.floors;

                    return output;
                },
                enumerable: true,
                configurable: true
            }
        });

        house.type = estateType.house;

        return house;
    })(estate);

    var garage = (function (parent) {
        var garage = Object.create(parent);
        Object.defineProperties(garage, {
            width: {
                get: function () {
                    if (typeof (this._width) === 'undefined') {
                        throw new Error();
                    } else {
                        return this._width;
                    }
                },
                set: function (value) {
                    if (validateRange(CONSTS.MIN_WIDTH, CONSTS.MAX_WIDTH, value)) {
                        this._width = value;
                    } else {
                        throw new Error();
                    }
                },
                enumerable: true,
                configurable: false,
            },
            height: {
                get: function () {
                    if (typeof (this._height) === 'undefined') {
                        throw new Error();
                    } else {
                        return this._height;
                    }
                },
                set: function (value) {
                    if (validateRange(CONSTS.MIN_HEIGHT, CONSTS.MAX_HEIGHT, value)) {
                        this._height = value;
                    } else {
                        throw new Error();
                    }
                },
                enumerable: true,
                configurable: false,
            },
            init: {
                value: function (name, area, location, isFurnitured, width, height) {
                    parent.init.call(this, name, area, location, isFurnitured);
                    this.width = width;
                    this.height = height;

                    return this;
                },
                enumerable: true,
                configurable: true,
            },
            //Garage: Name = garageLozenec, Area = 18, Location = Sofia, Furnitured = No, Width: 3, Height: 6
            toString: {
                value: function () {
                    var output = parent.toString.call(this);
                    output += ', Width: ' + this.width;
                    output += ', Height: ' + this.height;

                    return output;
                },
                enumerable: true,
                configurable: true
            }
        });

        garage.type = estateType.garage;

        return garage;
    })(estate);

    //•	Offer(estate: Estate, price: number) – abstract class holding an offer (used for sales offers and rent offers)
    var offer = (function () {
        var offer = {
            init: function (estate, price) {
                this.estate = estate;
                this.price = price;

                return this;
            },
            get type() {
                return this._type
            },
            set type(value) {
                this._type = value
            },
            get estate() {
                return this._estate;
            },
            set estate(value) {
                this._estate = value;
            },
            get price() {
                return this._price;
            },
            set price(value) {
                if (validatePositiveInteger(value)) {
                    this._price = value;
                } else {
                    throw Error();
                }
            },
            toString: function () {
                var output = this.type + ': Estate = ' + this.estate.name + ', Location = ' + this.estate.location
                    + ', Price = ' + this.price;
                return output;
            }
        };

        return offer;
    })();


    var rentOffer = (function (parent) {
        var rentOffer = Object.create(parent);
        Object.defineProperties(rentOffer, {
            init: {
                value: function (estate, price) {
                    parent.init.call(this, estate, price);
                    return this;
                }
            }
        });

        rentOffer.type = offerType.rent;

        return rentOffer;
    }(offer));

    var saleOffer = (function (parent) {
        var saleOffer = Object.create(parent);
        Object.defineProperties(saleOffer, {
            init: {
                value: function (estate, price) {
                    parent.init.call(this, estate, price);
                    return this;
                }
            }
        });

        saleOffer.type = offerType.sale;

        return saleOffer;
    }(offer));

    var EstatesEngine = (function () {
        var _estates;
        var _uniqueEstateNames;
        var _offers;

        function initialize() {
            _estates = [];
            _uniqueEstateNames = {};
            _offers = [];
        }

        function executeCommand(command) {
            var cmdParts = command.split(' ');
            var cmdName = cmdParts[0];
            var cmdArgs = cmdParts.splice(1);
            switch (cmdName) {
                case 'create':
                    return executeCreateCommand(cmdArgs);
                case 'status':
                    return executeStatusCommand();
                case 'find-sales-by-location':
                    return executeFindSalesByLocationCommand(cmdArgs[0]);
                case 'find-rents-by-location':
                    return executeFindRentsByLocationCommand(cmdArgs[0]);
                case 'find-rents-by-price ':
                    return executeFindRentsByPriceCommand(cmdArgs[0], cmdArgs[1]);
                default:
                    throw new Error('Unknown command: ' + cmdName);
            }
        }

        function executeCreateCommand(cmdArgs) {
            var objType = cmdArgs[0];
            switch (objType) {
                case 'Apartment':
                    var newApartment = Object.create(apartment);
                    newApartment.init(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3], parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                    addEstate(newApartment);
                    break;
                case 'Office':
                    var newOffice = Object.create(office).init(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                    addEstate(newOffice);
                    break;
                case 'House':
                    var newHouse = Object.create(house).init(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]));
                    addEstate(newHouse);
                    break;
                case 'Garage':
                    var newGarage = Object.create(garage).init(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), Number(cmdArgs[6]));
                    addEstate(newGarage);
                    break;
                case 'RentOffer':
                    var newEstate = findEstateByName(cmdArgs[1]);
                    var newRentOffer = Object.create(rentOffer).init(newEstate, Number(cmdArgs[2]));
                    addOffer(newRentOffer);
                    break;
                case 'SaleOffer':
                    newEstate = findEstateByName(cmdArgs[1]);
                    var newSaleOffer = Object.create(saleOffer).init(newEstate, Number(cmdArgs[2]));
                    addOffer(newSaleOffer);
                    break;
                default:
                    throw new Error('Unknown object to create: ' + objType);
            }
            return objType + ' created.';
        }

        function parseBoolean(value) {
            switch (value) {
                case "true":
                    return true;
                case "false":
                    return false;
                default:
                    throw new Error("Invalid boolean value: " + value);
            }
        }

        function findEstateByName(estateName) {
            for (var i = 0; i < _estates.length; i++) {
                if (_estates[i].name == estateName) {
                    return _estates[i];
                }
            }
            return undefined;
        }

        function addEstate(estate) {
            if (_uniqueEstateNames[estate.name]) {
                throw new Error('Duplicated estate name: ' + estate.name);
            }
            _uniqueEstateNames[estate.name] = true;
            _estates.push(estate);
        }

        function addOffer(offer) {
            _offers.push(offer);
        }

        function executeStatusCommand() {
            var result = '', i;
            if (_estates.length > 0) {
                result += 'Estates:\n';
                for (i = 0; i < _estates.length; i++) {
                    result += "  " + _estates[i].toString() + '\n';
                }
            } else {
                result += 'No estates\n';
            }

            if (_offers.length > 0) {
                result += 'Offers:\n';
                for (i = 0; i < _offers.length; i++) {
                    result += "  " + _offers[i].toString() + '\n';
                }
            } else {
                result += 'No offers\n';
            }

            return result.trim();
        }

        function executeFindSalesByLocationCommand(location) {
            if (!location) {
                throw new Error("Location cannot be empty.");
            }
            var selectedOffers = _offers.filter(function (offer) {
                return offer.estate.location === location &&
                    offer.type === offerType.sale;
            });
            selectedOffers.sort(function (a, b) {
                return a.estate.name.localeCompare(b.estate.name);
            });
            return formatQueryResults(selectedOffers);
        }

        function executeFindRentsByLocationCommand(location) {
            if (!location) {
                throw new Error("Location cannot be empty.");
            }
            var selectedRents = _offers.filter(function (offer) {
                return offer.estate.location === location &&
                    offer.type === offerType.rent;
            });
            selectedRents.sort(function (a, b) {
                return a.estate.name.localeCompare(b.estate.name);
            });
            return formatQueryResults(selectedRents);
        }

        function executeFindRentsByPriceCommand(minPrice, maxPrice) {
            //prints all rent offers within the specified price range (inclusively),
            // ordered by price and by name (as second criteria), in the format like in the sample below.
            // The parameters minPrice and maxPrice should be integers.
            if (minPrice > maxPrice) {
                throw new Error("Min price cannot be higher than Max price.");
            }
            var selectedRents = _offers.filter(function (offer) {
                return offer.price >= minPrice && offer.price <=maxPrice &&
                    offer.type === offerType.rent;
            });
            selectedRents.sort(function (a, b) {
                return a.estate.name.localeCompare(b.estate.name);
            });
            return formatQueryResults(selectedRents);
        }

        function formatQueryResults(offers) {
            var result = '';
            if (offers.length == 0) {
                result += 'No Results\n';
            } else {
                result += 'Query Results:\n';
                for (var i = 0; i < offers.length; i++) {
                    var offer = offers[i];
                    result += '  [Estate: ' + offer.estate.name +
                        ', Location: ' + offer.estate.location +
                        ', Price: ' + offer.price + ']\n';
                }
            }
            return result.trim();
        }

        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());


    // Process the input commands and return the results
    var results = '';
    EstatesEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != '') {
            try {
                var cmdResult = EstatesEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                //console.log(err);
                results += 'Invalid command.\n';
            }
        }
    });
    return results.trim();

}

// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

(function () {
    var arr = [];
    if (typeof (require) == 'function') {
        // We are in node.js --> read the console input and process it
        require('readline').createInterface({
            input: process.stdin,
            output: process.stdout
        }).on('line', function (line) {
            arr.push(line);
        }).on('close', function () {
            console.log(processEstatesAgencyCommands(arr));
        });
    }
})();
