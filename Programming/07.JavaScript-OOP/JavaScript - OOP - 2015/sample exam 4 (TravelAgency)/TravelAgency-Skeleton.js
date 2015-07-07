function processTravelAgencyCommands(commands) {
    'use strict';

    var Models = (function () {
        var travelTypes = {
            excursion: 'Excursion',
            cruise: 'Cruise',
            vacation: 'Vacation',
            destination: 'Destination'
        };

        function isValidParameter(param) {
            return param !== null && param !== undefined;
        }

        function isString(param) {
            return typeof(param) === 'string';
        }

        function isValidNonEmptyString(param) {
            return isValidParameter(param) && isString(param) && param !== '';
        }

        function isValidPrice(param) {
            return isValidParameter(param) && !isNaN(param) && param >= 0;
        }

        var Destination = (function () {
            var destination = {};
            Object.defineProperties(destination, {
                init: {
                    value: function (location, landmark) {
                        this.location = location;
                        this.landmark = landmark;

                        return this;
                    }
                },
                location: {
                    get: function () {
                        return this._location;
                    },
                    set: function (location) {
                        if (location === undefined || location === "") {
                            throw new Error("Location cannot be empty or undefined.");
                        }
                        this._location = location;
                    },
                    enumerable: true
                },
                landmark: {
                    get: function () {
                        return this._landmark;
                    },
                    set: function (landmark) {
                        if (landmark === undefined || landmark == "") {
                            throw new Error("Landmark cannot be empty or undefined.");
                        }
                        this._landmark = landmark;
                    },
                    enumerable: true
                },
                type: {
                    value: travelTypes.destination,
                    enumerable: true,
                    writable: false
                },
                toString: {
                    value: function () {
                        return this.type + ": " +
                            "location=" + this.location +
                            ",landmark=" + this.landmark;
                    },
                    enumerable: true
                }
            });

            return destination;
        }());

        var Travel = (function () {
            var travel = {};
            Object.defineProperties(travel, {
                init: {
                    value: function (name, startDate, endDate, price) {
                        this.name = name;
                        this.startDate = startDate;
                        this.endDate = endDate;
                        this.price = price;

                        return this;
                    },
                    enumerable: true
                },
                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        if (!isValidNonEmptyString(value)) {
                            throw new Error('Name should be valid non empty string');
                        }

                        this._name = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                startDate: {
                    get: function () {
                        return this._startDate;
                    },
                    set: function (value) {
                        this._startDate = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                endDate: {
                    get: function () {
                        return this._endDate;
                    },
                    set: function (value) {
                        this._endDate = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                price: {
                    get: function () {
                        return this._price;
                    },
                    set: function (value) {
                        if (!isValidPrice(value)) {
                            throw new Error('Invalid price specified.');
                        }

                        this._price = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                toString: {
                    value: function () {
                        return ': name=' + this.name + ',start-date=' + formatDate(this.startDate)
                            + ',end-date=' + formatDate(this.endDate) + ',price=' + this.price.toFixed(2);
                    },
                    enumerable: true
                }
            });

            return travel;
        }());

        var Excursion = (function (parent) {
            var excursion = Object.create(parent);
            Object.defineProperties(excursion, {
                init: {
                    value: function (name, startDate, endDate, price, transport) {
                        parent.init.call(this, name, startDate, endDate, price);
                        this.transport = transport;

                        return this;
                    }
                },
                type: {
                    value: travelTypes.excursion,
                    enumerable: true,
                    writable: false
                },
                _destinations: {
                    value: [],
                    enumerable: false
                },
                destinations: {
                    get: function () {
                        return this._destinations.slice(0);
                    },
                    enumerable: true,
                    configurable: true
                },
                transport: {
                    get: function () {
                        return this._transport;
                    },
                    set: function (value) {
                        if (!isValidNonEmptyString(value)) {
                            throw new Error('Transport must be a valid non empty string');
                        }

                        this._transport = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                addDestination: {
                    value: function (destination) {
                        if (!Destination.isPrototypeOf(destination)) {
                            throw new Error('Invalid destination specified.')
                        }

                        this._destinations.push(destination);
                    },
                    enumerable: true
                },
                removeDestination: {
                    value: function (destination) {
                        var filteredDestination;
                        if (!Destination.isPrototypeOf(destination)) {
                            throw new Error('Invalid destination specified.')
                        }

                        filteredDestination = this._destinations.filter(function (dest) {
                            return dest.location === destination.location && dest.landmark === destination.landmark;
                        });

                        if (filteredDestination.length === 0) {
                            throw new Error('No such destination exists in this excursion.')
                        }

                        this._destinations.splice(this._destinations.indexOf(filteredDestination, 1));
                    },
                    enumerable: true
                },
                toString: {
                    value: function () {
                        var output = ' * ' + this.type + parent.toString.call(this) + ',transport=' + this.transport
                            + '\n ** Destinations: ';

                        if (this.destinations.length > 0) {
                            output += this.destinations.join(';');
                        } else {
                            output += '-';
                        }

                        return output;
                    },
                    enumerable: true
                }
            });

            return excursion;
        }(Travel));

        var Cruise = (function (parent) {
            var cruise = Object.create(parent),
                TRANSPORT = 'cruise liner';
            Object.defineProperties(cruise, {
                init: {
                    value: function (name, startDate, endDate, price, startDock) {
                        parent.init.call(this, name, startDate, endDate, price, TRANSPORT);
                        this.startDock = startDock || null;

                        return this;
                    }
                },
                type: {
                    value: travelTypes.cruise,
                    enumerable: true,
                    writable: false
                },
                startDock: {
                    get: function () {
                        return this._startDock;
                    },
                    set: function (value) {
                        if (value !== null && !isValidNonEmptyString(value)) {
                            throw new Error('Invalid start dock provided.');
                        }

                        this._startDock = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                toString: {
                    value: function () {
                        var output = parent.toString.call(this),
                            newOutput,
                            indexOfDestinations = output.indexOf('\n *');

                        if (this.startDock) {
                            newOutput = output.substring(0, indexOfDestinations);
                            newOutput += ',startDock=' + this.startDock;
                            newOutput += output.substring(indexOfDestinations);

                            return newOutput;
                        }

                        return output;
                    },
                    enumerable: true
                }
            });

            return cruise;
        }(Excursion));

        var Vacation = (function (parent) {
            var vacation = Object.create(parent);

            Object.defineProperties(vacation, {
                init: {
                    value: function (name, startDate, endDate, price, location, accommodation) {
                        parent.init.call(this, name, startDate, endDate, price);
                        this.location = location;
                        this.accommodation = accommodation || null;

                        return this;
                    }
                },
                type: {
                    value: travelTypes.vacation,
                    enumerable: true,
                    writable: false
                },
                location: {
                    get: function () {
                        return this._location;
                    },
                    set: function (value) {
                        if (!isValidNonEmptyString(value)) {
                            throw new Error('Invalid location specified.');
                        }

                        this._location = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                accommodation: {
                    get: function () {
                        return this._accommodation;
                    },
                    set: function (value) {
                        if (value !== null && !isValidNonEmptyString(value)) {
                            throw new Error('Invalid accommodation specified.');
                        }

                        this._accommodation = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                toString: {
                    value: function () {
                        var output = ' * ' + this.type + parent.toString.call(this) + ',location=' + this.location;

                        if (this.accommodation !== null) {
                            output += ',accommodation=' + this.accommodation;
                        }

                        return output;
                    },
                    enumerable: true
                }
            });

            return vacation
        }(Travel));

        return {
            Destination: Destination,
            Excursion: Excursion,
            Vacation: Vacation,
            Cruise: Cruise
        }
    }());

    var TravellingManager = (function () {
        var _travels;
        var _destinations;

        function init() {
            _travels = [];
            _destinations = [];
        }

        var CommandProcessor = (function () {

            function processInsertCommand(command) {
                var object;

                switch (command["type"]) {
                    case "excursion":
                        object = Object.create(Models.Excursion).init(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["transport"]);
                        _travels.push(object);
                        break;
                    case "vacation":
                        object = Object.create(Models.Vacation).init(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["location"], command["accommodation"]);
                        _travels.push(object);
                        break;
                    case "cruise":
                        object = Object.create(Models.Cruise).init(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["start-dock"]);
                        _travels.push(object);
                        break;
                    case "destination":
                        object = Object.create(Models.Destination).init(command["location"], command["landmark"]);
                        _destinations.push(object);
                        break;
                    default:
                        throw new Error("Invalid type.");
                }

                return object.type + " created.";
            }

            function processDeleteCommand(command) {
                var object,
                    index;

                switch (command["type"]) {
                    case "destination":
                        object = getDestinationByLocationAndLandmark(command["location"], command["landmark"]);
                        _travels.forEach(function (t) {
                            if (Models.Excursion.isPrototypeOf(t) && t.destinations.indexOf(object) !== -1) {
                                t.removeDestination(object);
                            }
                        });
                        index = _destinations.indexOf(object);
                        _destinations.splice(index, 1);
                        break;
                    case "excursion":
                    case "vacation":
                    case "cruise":
                        object = getTravelByName(command["name"]);
                        index = _travels.indexOf(object);
                        _travels.splice(index, 1);
                        break;
                    default:
                        throw new Error("Unknown type.");
                }

                return object.type + " deleted.";
            }

            function processListCommand() {
                return formatTravelsQuery(_travels);
            }

            function processFilterTravelsCommand(command) {
                var filteredTravels;

                function filterBy(param, minPrice, maxPrice) {
                    return _travels.filter(function (travel) {
                        var typeResult;

                        if (param === 'all') {
                            typeResult = true;
                        } else {
                            typeResult = travel.type.toLowerCase() === param;
                        }

                        return typeResult && travel.price >= minPrice && travel.price <= maxPrice;
                    })
                }

                filteredTravels = filterBy(command.type, command['price-min'], command['price-max']);

                filteredTravels.sort(function (a, b) {
                    if (a.startDate === b.startDate) {
                        return a.name < b.name
                    } else {
                        return a.startDate - b.startDate
                    }
                });

                return formatTravelsQuery(filteredTravels);
            }

            function processAddDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(Models.Excursion.isPrototypeOf(travel))) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.addDestination(destination);

                return "Added destination to " + travel.name + ".";
            }

            function processRemoveDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(Models.Excursion.isPrototypeOf(travel))) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.removeDestination(destination);

                return "Removed destination from " + travel.name + ".";
            }


            function getTravelByName(name) {
                var i;

                for (i = 0; i < _travels.length; i++) {
                    if (_travels[i].name === name) {
                        return _travels[i];
                    }
                }
                throw new Error("No travel with such name exists.");
            }

            function getDestinationByLocationAndLandmark(location, landmark) {
                var i;

                for (i = 0; i < _destinations.length; i++) {
                    if (_destinations[i].location === location
                        && _destinations[i].landmark === landmark) {
                        return _destinations[i];
                    }
                }
                throw new Error("No destination with such location and landmark exists.");
            }

            function formatTravelsQuery(travelsQuery) {
                var queryString = "";

                if (travelsQuery.length > 0) {
                    queryString += travelsQuery.join("\n");
                } else {
                    queryString = "No results.";
                }

                return queryString;
            }

            return {
                processInsertCommand: processInsertCommand,
                processDeleteCommand: processDeleteCommand,
                processListCommand: processListCommand,
                processAddDestinationCommand: processAddDestinationCommand,
                processRemoveDestinationCommand: processRemoveDestinationCommand,
                processFilterTravelsCommand: processFilterTravelsCommand
            }
        }());

        var Command = (function () {
            function Command(cmdLine) {
                this._cmdArgs = processCommand(cmdLine);
            }

            function processCommand(cmdLine) {
                var parameters = [],
                    matches,
                    pattern = /(.+?)=(.+?)[;)]/g,
                    key,
                    value,
                    split;

                split = cmdLine.split("(");
                parameters["command"] = split[0];
                while ((matches = pattern.exec(split[1])) !== null) {
                    key = matches[1];
                    value = matches[2];
                    parameters[key] = value;
                }

                return parameters;
            }

            return Command;
        }());

        function executeCommands(cmds) {
            var commandArgs = new Command(cmds)._cmdArgs,
                action = commandArgs["command"],
                output;

            switch (action) {
                case "insert":
                    output = CommandProcessor.processInsertCommand(commandArgs);
                    break;
                case "delete":
                    output = CommandProcessor.processDeleteCommand(commandArgs);
                    break;
                case "add-destination":
                    output = CommandProcessor.processAddDestinationCommand(commandArgs);
                    break;
                case "remove-destination":
                    output = CommandProcessor.processRemoveDestinationCommand(commandArgs);
                    break;
                case "list":
                    output = CommandProcessor.processListCommand(commandArgs);
                    break;
                case "filter":
                    output = CommandProcessor.processFilterTravelsCommand(commandArgs);
                    break;
                default:
                    throw new Error("Unsupported command.");
            }

            return output;
        }

        return {
            init: init,
            executeCommands: executeCommands
        }
    }());

    var parseDate = function (dateStr) {
        if (!dateStr) {
            return undefined;
        }
        var date = new Date(Date.parse(dateStr.replace(/-/g, ' ')));
        var dateFormatted = formatDate(date);
        if (dateStr != dateFormatted) {
            throw new Error("Invalid date: " + dateStr);
        }
        return date;
    };

    var formatDate = function (date) {
        var day = date.getDate();
        var monthName = date.toString().split(' ')[1];
        var year = date.getFullYear();
        return day + '-' + monthName + '-' + year;
    };

    var output = "";
    TravellingManager.init();

    commands.forEach(function (cmd) {
        var result;
        if (cmd != "") {
            try {
                result = TravellingManager.executeCommands(cmd) + "\n";
            } catch (e) {
                result = "Invalid command." + "\n";
            }
            output += result;
        }
    });

    return output;
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
            console.log(processTravelAgencyCommands(arr));
        });
    }
})();