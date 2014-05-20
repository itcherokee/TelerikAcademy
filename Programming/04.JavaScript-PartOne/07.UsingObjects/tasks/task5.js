// Task 5:  Write a function that finds the youngest person in a given array 
//          of persons and prints his/hers full name.
//          - Each person have properties firstname, lastname and age

var taskFive = function () {
    "use strict";
    var brake = "<br />";

    function Person(firstName, lastName, age) {
        if (this === window) {
            return new Person(firstName, lastName, age);
        }

        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.getFullName = function () {
            return this.firstName + ' ' + this.lastName + ' (age: ' + this.age + ')';
        };
    }

    function ListOfPersons() {
        if (this === window) {
            return new ListOfPersons(arguments);
        }

        var args = Array.prototype.slice.call(arguments, 0);
        this.list = [];
        this.youngest = function () {
            var minAge = Number.MAX_VALUE,
                indexOfSmallest;

            function findYongest(person, index) {
                if (minAge > person.age) {
                    minAge = person.age;
                    indexOfSmallest = index;
                }
            }

            this.list.forEach(findYongest, this.list);
            return this.list[indexOfSmallest];
        };

        this.addRange = function () {
            for (var i = 0; i < args.length; i++) {
                this.list.push(args[i]);
            }
        };

        this.toString = function () {
            var output = '';
            for (var i = 0; i < this.list.length; i++) {
                output += JSON.stringify(this.list[i]) + brake;
            }

            return output;
        };

        if (args) {
            this.addRange(args);
        }
    }

    var runMe = function () {
        var output = brake + "Initial data has been hardcoded in order to simplify your task:" + brake + "Initial person objects:" + brake + brake;
        var persons = new ListOfPersons(new Person('Gosho', 'Petrov', 32), new Person('Lyolyo', 'Lyolyov', 12), new Person('Bay', 'Ivan', 81));
        output += persons.toString() + brake;
        output += "The yongest person is: " + brake;
        output += persons.youngest().getFullName() + brake;
        return output;
    };

    return runMe();
};