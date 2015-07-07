function processVehicleParkCommands(commands) {
    'use strict';

    var Models = (function () {
        var terrainType = {
                all: 'all',
                road: 'road'
            },
            vehicleType = {
                bike: 'Bike',
                truck: 'Truck',
                limo: 'Limo'
            };

        var Employee = (function () {
            var employee = {};
            Object.defineProperties(employee, {
                init: {
                    value: function (name, position, grade) {
                        this.name = name;
                        this.position = position;
                        this.grade = grade;

                        return this;
                    },
                    enumerable: true,
                    configurable: true
                },
                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (name) {
                        if (name === undefined || name === "") {
                            throw new Error("Name cannot be empty or undefined.");
                        }
                        this._name = name;
                    },
                    enumerable: true,
                    configurable: false
                },
                position: {
                    get: function () {
                        return this._position;
                    },
                    set: function (position) {
                        if (position === undefined || position === "") {
                            throw new Error("Position cannot be empty or undefined.");
                        }
                        this._position = position;
                    },
                    enumerable: true,
                    configurable: false
                },
                grade: {
                    get: function () {
                        return this._grade;
                    },
                    set: function (grade) {
                        if (grade === undefined || isNaN(grade) || grade < 0) {
                            throw new Error("Grade cannot be negative.");
                        }
                        this._grade = grade;
                    },
                    enumerable: true,
                    configurable: false
                },
                type: {
                    value: 'Employee'
                },
                toString: {
                    value: function () {
                        return " ---> " + this.name + ",position=" + this.position;
                    },
                    enumerable: true,
                    configurable: true
                }
            });

            return employee;
        })();

        var Vehicle = (function () {
            var vehicle = {};
            Object.defineProperties(vehicle, {
                init: {
                    value: function (type, brand, age, terrain, wheels) {
                        this.type = type;
                        this.brand = brand;
                        this.age = age;
                        this.terrain = terrain;
                        this.wheels = wheels;

                        return this;
                    },
                    enumerable: true,
                    configurable: true
                },
                brand: {
                    get: function () {
                        return this._brand;
                    },
                    set: function (brand) {
                        if (brand === undefined || brand === "") {
                            throw new Error("Brand cannot be empty or undefined.");
                        }

                        this._brand = brand;
                    },
                    enumerable: true,
                    configurable: false
                },
                age: {
                    get: function () {
                        return this._age;
                    },
                    set: function (age) {
                        if (age === undefined || isNaN(age) || age < 0) {
                            throw new Error("Age cannot be negative.");
                        }

                        this._age = age;
                    },
                    enumerable: true,
                    configurable: false
                },
                terrain: {
                    get: function () {
                        return this._terrain;
                    },
                    set: function (terrain) {
                        if (terrain === undefined || !(terrain === terrainType.all || terrain === terrainType.road)) {
                            throw new Error("Terrain must be valid terrain type.");
                        }

                        this._terrain = terrain;
                    },
                    enumerable: true,
                    configurable: false
                },
                wheels: {
                    get: function () {
                        return this._wheels;
                    },
                    set: function (wheels) {
                        if (wheels === undefined || isNaN(wheels) || wheels < 0) {
                            throw new Error("Wheels cannot be negative.");
                        }

                        this._wheels = wheels;
                    },
                    enumerable: true,
                    configurable: false
                },
                type: {
                    get: function () {
                        return this._type;
                    },
                    set: function (type) {
                        this._type = type;
                    },
                    enumerable: true,
                    configurable: false
                },
                toString: {
                    value: function () {
                        return ' -> ' + this.type + ': brand=' + this.brand + ",age=" + this.age.toFixed(1) + ",terrainCoverage=" + this.terrain + ",numberOfWheels=" + this.wheels;
                    },
                    enumerable: true,
                    configurable: true
                }
            });

            return vehicle;
        })();

        var Bike = (function (parent) {
            var bike = Object.create(parent),
                numberOfWheels = 2;
            Object.defineProperties(bike, {
                init: {
                    value: function (brand, age, terrain, frameSize, numberOfShifts) {
                        parent.init.call(this, vehicleType.bike, brand, age, terrain, numberOfWheels);
                        this.frameSize = frameSize;
                        this.numberOfShifts = numberOfShifts || null;

                        return this;
                    },
                    enumerable: true,
                    configurable: true
                },
                frameSize: {
                    get: function () {
                        return this._frameSize;
                    },
                    set: function (frameSize) {
                        if (frameSize === undefined || isNaN(frameSize) || frameSize < 0) {
                            throw new Error("Frame size cannot be negative.");
                        }

                        this._frameSize = frameSize;
                    },
                    enumerable: true,
                    configurable: false
                },
                numberOfShifts: {
                    get: function () {
                        return this._numberOfShifts;
                    },
                    set: function (numberOfShifts) {
                        if (numberOfShifts === undefined || numberOfShifts === '') {
                            throw new Error("Number of shifts cannot be empty string.");
                        }

                        this._numberOfShifts = numberOfShifts;
                    },
                    enumerable: true,
                    configurable: false
                },
                toString: {
                    value: function () {
                        var output = '',
                            shifts;

                        output += parent.toString.call(this) + ",frameSize=" + this.frameSize;
                        if (this.numberOfShifts !== null) {
                            output += ',numberOfShifts=' + this.numberOfShifts;
                        }

                        return output;
                    },
                    enumerable: true,
                    configurable: true
                }
            });

            return bike;
        })(Vehicle);

        var Automobile = (function (parent) {
            var automobile = Object.create(parent);
            Object.defineProperties(automobile, {
                init: {
                    value: function (type, brand, age, terrain, wheels, consumption, typeOfFuel) {
                        parent.init.call(this, type, brand, age, terrain, wheels);
                        this.consumption = consumption;
                        this.typeOfFuel = typeOfFuel;

                        return this;
                    },
                    enumerable: true,
                    configurable: true
                },
                consumption: {
                    get: function () {
                        return this._consumption;
                    },
                    set: function (consumption) {
                        if (consumption === undefined || isNaN(consumption) || consumption < 0) {
                            throw new Error("Frame size cannot be negative.");
                        }

                        this._consumption = consumption;
                    },
                    enumerable: true,
                    configurable: false,
                },
                typeOfFuel: {
                    get: function () {
                        return this._typeOfFuel;
                    },
                    set: function (typeOfFuel) {
                        if (typeOfFuel === undefined || typeOfFuel === '') {
                            throw new Error("Type of fuel cannot be empty string.");
                        }

                        this._typeOfFuel = typeOfFuel;
                    },
                    enumerable: true,
                    configurable: false,
                },
                toString: {
                    value: function () {
                        return parent.toString.call(this) + ',consumption=[' + this.consumption + 'l/100km ' + this.typeOfFuel + ']';
                    },
                    enumerable: true,
                    configurable: true
                }
            });

            return automobile;
        })(Vehicle);

        var Truck = (function (parent) {
            var truck = Object.create(parent),
                terrainCoverage = terrainType.all,
                NUMBER_OF_WHEELS = 4;

            Object.defineProperties(truck, {
                init: {
                    value: function (brand, age, terrain, consumption, typeOfFuel, numberOfDoors) {
                        parent.init.call(this, vehicleType.truck, brand, age, terrain || terrainCoverage, NUMBER_OF_WHEELS, consumption, typeOfFuel);
                        this.numberOfDoors = numberOfDoors;

                        return this;
                    },
                    enumerable: true,
                    configurable: true
                },
                numberOfDoors: {
                    get: function () {
                        return this._numberOfDoors;
                    },
                    set: function (numberOfDoors) {
                        if (numberOfDoors === undefined || isNaN(numberOfDoors) || numberOfDoors < 0) {
                            throw new Error("Number of doors cannot be negative.");
                        }

                        this._numberOfDoors = numberOfDoors;
                    },
                    enumerable: true,
                    configurable: false,
                },
                toString: {
                    value: function () {
                        return parent.toString.call(this) + ',numberOfDoors=' + this.numberOfDoors;
                    },
                    enumerable: true,
                    configurable: true
                }
            });

            return truck;
        })(Automobile);

        var Limo = (function (parent) {
            var limo = Object.create(parent),
                TERRAIN_COVERAGE = terrainType.road;

            Object.defineProperties(limo, {
                init: {
                    value: function (brand, age, wheels, consumption, typeOfFuel) {
                        parent.init.call(this, vehicleType.limo, brand, age, TERRAIN_COVERAGE, wheels, consumption, typeOfFuel);

                        return this;
                    },
                    enumerable: true,
                    configurable: true
                },
                appendEmployee: {
                    value: function (employee) {
                        if (employee === null || employee === undefined) {
                            throw new Error('Valid employee must be provided');
                        }

                        this.employees = employee;
                    },
                    enumerable: true,
                    configurable: false
                },
                detachEmployee: {
                    value: function (employee) {
                        var employee = this.employees.filter(function (emp) {
                            return emp.name === employee.name;
                        });

                        if (employee.length === 0) {
                            throw new Error('No such employee in the list of drivers');
                        }

                        this._employees.splice(this.employees.indexOf(employee), 1);
                    },
                    enumerable: true,
                    configurable: false
                },
                employees: {
                    get: function () {
                        if (this._employees === undefined) {
                            this._employees = [];
                        }

                        return this._employees.slice(0);
                    },
                    set: function (value) {
                        if (this._employees === undefined) {
                            this._employees = [];
                        }

                        this._employees.push(value);
                    },
                    enumerable: true,
                    configurable: true
                },
                toString: {
                    value: function () {
                        var output = parent.toString.call(this) + '\n --> Employees, allowed to drive:',
                            i, len;
                        if (this.employees.length === 0) {
                            output += ' ---'
                        } else {
                            for (i = 0, len = this.employees.length; i < len; i += 1) {
                                output += '\n' + this.employees[i].toString();
                            }
                        }

                        return output;
                    },
                    enumerable: true,
                    configurable: true
                }
            });

            return limo;
        })(Automobile);

        return {
            Employee: Employee,
            Bike: Bike,
            Truck: Truck,
            Limo: Limo
        }
    }());

    var ParkManager = (function () {
        var _vehicles;
        var _employees;

        function init() {
            _vehicles = [];
            _employees = [];
        }

        var CommandProcessor = (function () {

            function processInsertCommand(command) {
                var object;

                switch (command["type"]) {
                    case "bike":
                        object = Object.create(Models.Bike).init(
                            command["brand"],
                            parseFloat(command["age"]),
                            command["terrain-coverage"],
                            parseFloat(command["frame-size"]),
                            command["number-of-shifts"]);
                        _vehicles.push(object);
                        break;
                    case "truck":
                        object = Object.create(Models.Truck).init(
                            command["brand"],
                            parseFloat(command["age"]),
                            command["terrain-coverage"],
                            parseFloat(command["consumption"]),
                            command["type-of-fuel"],
                            parseFloat(command["number-of-doors"]));
                        _vehicles.push(object);
                        break;
                    case "limo":
                        object = Object.create(Models.Limo).init(
                            command["brand"],
                            parseFloat(command["age"]),
                            parseFloat(command["number-of-wheels"]),
                            parseFloat(command["consumption"]),
                            command["type-of-fuel"]);
                        _vehicles.push(object);
                        break;
                    case "employee":
                        object = Object.create(Models.Employee).init(command["name"], command["position"], parseFloat(command["grade"]));
                        _employees.push(object);
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
                    case "employee":
                        object = getEmployeeByName(command["name"]);
                        _vehicles.forEach(function (t) {
                            if (t.type.toLowerCase() === 'limo' && t.employees.indexOf(object) !== -1) {
                                t.detachEmployee(object);
                            }
                        });
                        index = _employees.indexOf(object);
                        _employees.splice(index, 1);
                        break;
                    case "bike":
                    case "truck":
                    case "limo":
                        object = getVehicleByBrandAndType(command["brand"], command["type"]);
                        index = _vehicles.indexOf(object);
                        _vehicles.splice(index, 1);
                        break;
                    default:
                        throw new Error("Unknown type.");
                }

                return object.type + " deleted.";
            }

            function processListCommand(command) {
                return formatOutputList(_vehicles);
            }

            function processListEmployees(command) {
                var filteredEmployees;
                if (command !== 'all') {
                    filteredEmployees = _employees.filter(function (emp) {
                        return emp.grade >= command
                    })
                } else {
                    filteredEmployees = _employees.splice(0);
                }

                filteredEmployees.sort(function (a, b) {
                    return a.name > b.name;
                });

                return formatOutputList(filteredEmployees);
            }

            function processAppendEmployeeCommand(command) {
                var employee = getEmployeeByName(command["name"]);
                var limos = getLimosByBrand(command["brand"]);

                for (var i = 0; i < limos.length; i++) {
                    limos[i].appendEmployee(employee);
                }
                return "Added employee to possible Limos.";
            }

            function processDetachEmployeeCommand(command) {
                var employee = getEmployeeByName(command["name"]);
                var limos = getLimosByBrand(command["brand"]);

                for (var i = 0; i < limos.length; i++) {
                    limos[i].detachEmployee(employee);
                }

                return "Removed employee from possible Limos.";
            }

            // Functions below are not revealed

            function getVehicleByBrandAndType(brand, type) {
                for (var i = 0; i < _vehicles.length; i++) {
                    if (_vehicles[i].type.toLowerCase() === type &&
                        _vehicles[i].brand === brand) {
                        return _vehicles[i];
                    }
                }
                throw new Error("No Limo with such brand exists.");
            }

            function getLimosByBrand(brand) {
                var currentVehicles = [];
                for (var i = 0; i < _vehicles.length; i++) {
                    if (_vehicles[i].type.toLowerCase() === 'limo' &&
                        _vehicles[i].brand === brand) {
                        currentVehicles.push(_vehicles[i]);
                    }
                }
                if (currentVehicles.length > 0) {
                    return currentVehicles;
                }
                throw new Error("No Limo with such brand exists.");
            }

            function getEmployeeByName(name) {

                for (var i = 0; i < _employees.length; i++) {
                    if (_employees[i].name === name) {
                        return _employees[i];
                    }
                }
                throw new Error("No Employee with such name exists.");
            }

            function formatOutputList(output) {
                var queryString = "List Output:\n";

                if (output.length > 0) {
                    queryString += output.join("\n");
                } else {
                    queryString = "No results.";
                }

                return queryString;
            }

            return {
                processInsertCommand: processInsertCommand,
                processDeleteCommand: processDeleteCommand,
                processListCommand: processListCommand,
                processListEmployees: processListEmployees,
                processAppendEmployeeCommand: processAppendEmployeeCommand,
                processDetachEmployeeCommand: processDetachEmployeeCommand
            }
        }());

        var Command = (function () {
            function Command(cmdLine) {
                this._cmdArgs = processCommand(cmdLine);
            }

            function processCommand(cmdLine) {
                var parameters = [],
                    matches = [],
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
                case "append-employee":
                    output = CommandProcessor.processAppendEmployeeCommand(commandArgs);
                    break;
                case "detach-employee":
                    output = CommandProcessor.processDetachEmployeeCommand(commandArgs);
                    break;
                case "list":
                    output = CommandProcessor.processListCommand(commandArgs);
                    break;
                case "list-employees":
                    output = CommandProcessor.processListEmployees(commandArgs);
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

    var output = "";
    ParkManager.init();

    commands.forEach(function (cmd) {
        var result;
        if (cmd != "") {
            try {
                result = ParkManager.executeCommands(cmd) + "\n";
            } catch (e) {
                result = "Invalid command." + "\n";
                //result = e.message + "\n";
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
            console.log(processVehicleParkCommands(arr));
        });
    }
})();