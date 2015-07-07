function processTrainingCenterCommands(commands) {

    'use strict';

    var trainingcenter = (function () {
        var minDate = new Date(2000, 0, 1), //new Date(Date.parse(dateStr.replace(/-/g, ' '))  15-Nov-2014
            maxDate = new Date(2020, 11, 31);

        var TrainingCenterEngine = (function () {

            var _trainers;
            var _uniqueTrainerUsernames;
            var _trainings;

            function initialize() {
                _trainers = [];
                _uniqueTrainerUsernames = {};
                _trainings = [];
            }

            function executeCommand(command) {
                var cmdParts = command.split(' ');
                var cmdName = cmdParts[0];
                var cmdArgs = cmdParts.splice(1);
                switch (cmdName) {
                    case 'create':
                        return executeCreateCommand(cmdArgs);
                    case 'list':
                        return executeListCommand();
                    case 'delete':
                        return executeDeleteCommand(cmdArgs);
                    default:
                        throw new Error('Unknown command: ' + cmdName);
                }
            }

            function executeCreateCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var createArgs = cmdArgs.splice(1).join(' ');
                var objectData = JSON.parse(createArgs);
                var trainer;
                switch (objectType) {
                    case 'Trainer':
                        trainer = Object.create(trainingcenter.Trainer).init(objectData.username, objectData.firstName,
                            objectData.lastName, objectData.email);
                        addTrainer(trainer);
                        break;
                    case 'Course':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var course = Object.create(trainingcenter.Course).init(objectData.name, objectData.description, trainer,
                            parseDate(objectData.startDate), objectData.duration);
                        addTraining(course);
                        break;
                    case 'Seminar':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var seminar = Object.create(trainingcenter.Seminar).init(objectData.name, objectData.description,
                            trainer, parseDate(objectData.date));
                        addTraining(seminar);
                        break;
                    case 'RemoteCourse':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var remoteCourse = Object.create(trainingcenter.RemoteCourse).init(objectData.name, objectData.description,
                            trainer, parseDate(objectData.startDate), objectData.duration, objectData.location);
                        addTraining(remoteCourse);
                        break;
                    default:
                        throw new Error('Unknown object to create: ' + objectType);
                }
                return objectType + ' created.';
            }

            function findTrainerByUsername(username) {
                if (!username) {
                    return undefined;
                }
                for (var i = 0; i < _trainers.length; i++) {
                    if (_trainers[i].username == username) {
                        return _trainers[i];
                    }
                }
                throw new Error("Trainer not found: " + username);
            }

            function addTrainer(trainer) {
                if (_uniqueTrainerUsernames[trainer.username]) {
                    throw new Error('Duplicated trainer: ' + trainer.username);
                }
                _uniqueTrainerUsernames[trainer.username] = true;
                _trainers.push(trainer);
            }

            function addTraining(training) {
                _trainings.push(training);
            }

            function executeListCommand() {
                var result = '';
                if (_trainers.length > 0) {
                    result += 'Trainers:\n' + ' * ' + _trainers.join('\n * ') + '\n';
                } else {
                    result += 'No trainers\n';
                }

                if (_trainings.length > 0) {
                    result += 'Trainings:\n' + ' * ' + _trainings.join('\n * ') + '\n';
                } else {
                    result += 'No trainings\n';
                }

                return result.trim();
            }

            function executeDeleteCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var deleteArgs = cmdArgs.splice(1).join(' ');
                switch (objectType) {
                    case 'Trainer':
                        var trainer = _trainers.filter(function (trein) {
                            return trein.username === deleteArgs;
                        });

                        if (trainer.length === 0) {
                            throw new Error('Not possible to delete non existing trainer.');
                        }

                        delete _uniqueTrainerUsernames[deleteArgs];
                        _trainers.splice(_trainers.indexOf(trainer[0]));

                        _trainings.forEach(function (element) {
                            if (element.trainer && element.trainer.username === deleteArgs) {
                                element.trainer = null;
                            }
                        });

                        break;
                    default:
                        throw new Error('Unknown object to delete: ' + objectType);
                }
                return objectType + ' deleted.';
            }

            return {
                initialize: initialize,
                executeCommand: executeCommand
            };
        }());

        function isValidParameter(param) {
            return param !== null && param !== undefined;
        }

        function isString(param) {
            return typeof(param) === 'string';
        }

        function isValidNonEmptyString(param) {
            return isString(param) && param !== '';
        }

        function isValidDate(param) {
            return isValidParameter(param) && minDate <= param && maxDate >= param;
        }

        function isValidEmail(param) {
            return param.indexOf('@') !== -1;
        }

        function isValidIntegerInRange(param) {
            var min = 1,
                max = 99;
            return isValidParameter(param) && !isNaN(param) && isFinite(param) && param === (param | 0)
                && param >= min && param <= max;
        }

        var Trainer = (function () {
            var trainer = {};
            Object.defineProperties(trainer, {
                init: {
                    value: function (username, firstName, lastName, email) {
                        this.username = username;
                        this.firstName = firstName;
                        this.lastName = lastName;
                        this.email = email;

                        return this;
                    }
                },
                email: {
                    get: function () {
                        return this._email;
                    },
                    set: function (value) {
                        if (value === null || value === undefined) {
                            this._email = null;
                        } else if (isValidNonEmptyString(value) && isValidEmail(value)) {
                            this._email = value;
                        } else {
                            throw new Error('Invalid email specified.');
                        }
                    },
                    enumerable: true,
                    configurable: true
                },
                firstName: {
                    get: function () {
                        return this._firstName;
                    },
                    set: function (value) {
                        if (value === null || value === undefined) {
                            this._firstName = null;
                        } else if (isValidNonEmptyString(value)) {
                            this._firstName = value;
                        } else {
                            throw new Error('Invalid firstName specified.');
                        }
                    },
                    enumerable: true,
                    configurable: true
                },
                username: {
                    get: function () {
                        return this._username;
                    },
                    set: function (value) {
                        if (!isValidNonEmptyString(value)) {
                            throw new Error('Invalid username specified.');
                        }

                        this._username = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                lastName: {
                    get: function () {
                        return this._lastName;
                    },
                    set: function (value) {
                        if (!isValidNonEmptyString(value)) {
                            throw new Error('Invalid lastName specified.');
                        }

                        this._lastName = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                toString: {
                    value: function () {
                        var output = 'Trainer[username=' + this.username;
                        output += (this.firstName !== null ? ';first-name=' + this.firstName : '');
                        output += ';last-name=' + this.lastName;
                        output += (this.email !== null ? ';email=' + this.email : '');

                        return output + ']';
                    },
                    enumerable: true
                }
            });

            return trainer;
        }());

        var Training = (function () {
            var training = {};
            Object.defineProperties(training, {
                init: {
                    value: function (name, description, trainer, startDate, duration) {
                        this.name = name;
                        this.description = description;
                        this.trainer = trainer;
                        this.startDate = startDate;
                        this.duration = duration;

                        return this;
                    }
                },
                toString: {
                    value: function () {
                        var output = 'name=' + this.name;
                        output += this.description !== null ? ';description=' + this.description : '';
                        output += this.trainer !== null ? ';trainer=' + this.trainer.toString() : '';
                        output += ';start-date=' + formatDate(this.startDate);
                        output += this.duration !== null ? ';duration=' + this.duration : '';

                        return output;
                    },
                    enumerable: true
                },
                duration: {
                    get: function () {
                        return this._duration;
                    },
                    set: function (value) {
                        if (value === null || value === undefined) {
                            this._duration = null;
                        } else if (isValidIntegerInRange(value)) {
                            this._duration = value;
                        } else {
                            throw new Error('Invalid duration specified.');
                        }
                    },
                    enumerable: true,
                    configurable: true
                },
                startDate: {
                    get: function () {
                        return this._startDate;
                    },
                    set: function (value) {
                        if (!isValidDate(value)) {
                            throw new Error('Invalid startDate specified.');
                        }

                        this._startDate = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                trainer: {
                    get: function () {
                        return this._trainer;
                    },
                    set: function (value) {
                        if (value === null || value === undefined) {
                            this._trainer = null;
                        } else if (trainingcenter.Trainer.isPrototypeOf(value)) {
                            this._trainer = value;
                        } else {
                            throw new Error('Invalid trainer specified.');
                        }
                    },
                    enumerable: true,
                    configurable: true
                },
                description: {
                    get: function () {
                        return this._description;
                    },
                    set: function (value) {
                        if (value === null || value === undefined) {
                            this._description = null;
                        } else if (isValidNonEmptyString(value)) {
                            this._description = value;
                        } else {
                            throw new Error('Invalid description specified.');
                        }
                    },
                    enumerable: true,
                    configurable: true
                },
                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        if (!isValidNonEmptyString(value)) {
                            throw new Error('Invalid name specified.');
                        }

                        this._name = value;
                    },
                    enumerable: true,
                    configurable: true
                }
            });

            return training;
        }());

        var Course = (function (parent) {
            var course = Object.create(parent);
            Object.defineProperties(course, {
                init: {

                    value: function (name, description, trainer, startDate, duration) {
                        parent.init.call(this, name, description, trainer, startDate, duration);

                        return this;
                    }
                },
                type: {
                    value: 'Course',
                    enumerable: true,
                    writable: false
                },
                toString: {
                    value: function () {
                        return this.type + '[' + parent.toString.call(this) + ']';
                    },
                    enumerable: true
                }
            });

            return course;
        }(Training));

        var Seminar = (function (parent) {
            var seminar = Object.create(parent),
                DURATION = 1;
            Object.defineProperties(seminar, {
                init: {
                    value: function (name, description, trainer, startDate) {
                        parent.init.call(this, name, description, trainer, startDate, DURATION);

                        return this;
                    }
                },
                type: {
                    value: 'Seminar',
                    enumerable: true,
                    writable: false
                },
                toString: {
                    value: function () {
                        var output = parent.toString.call(this),
                            newOutput = output.substring(0, output.indexOf(';duration'));

                        return this.type + '[' + newOutput + ']';
                    },
                    enumerable: true
                }
            });

            return seminar;
        }(Training));

        var RemoteCourse = (function (parent) {
            var remoteCourse = Object.create(parent);
            Object.defineProperties(remoteCourse, {
                init: {
                    value: function (name, description, trainer, startDate, duration, location) {
                        parent.init.call(this, name, description, trainer, startDate, duration);
                        this.location = location;

                        return this;
                    }
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
                type: {
                    value: 'RemoteCourse',
                    enumerable: true,
                    writable: false
                },
                toString: {
                    value: function () {
                        var output = parent.toString.call(this),
                            newOutput = output.substring(0, output.lastIndexOf(']'));
                        newOutput += ';location=' + this.location + ']';

                        return newOutput;
                    },
                    enumerable: true
                }
            });

            return remoteCourse;
        }(Course));


        var trainingcenter = {
            Trainer: Trainer,
            Course: Course,
            Seminar: Seminar,
            RemoteCourse: RemoteCourse,
            engine: {
                TrainingCenterEngine: TrainingCenterEngine
            }
        };

        return trainingcenter;
    })();


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


    // Process the input commands and return the results
    var results = '';
    trainingcenter.engine.TrainingCenterEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != '') {
            try {
                var cmdResult = trainingcenter.engine.TrainingCenterEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                //console.log(err.stack);
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
            console.log(processTrainingCenterCommands(arr));
        });
    }
})();
