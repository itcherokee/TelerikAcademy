// Task 6:  Write a function that groups an array of persons by age, first or last name. 
//          The function must return an associative array, with keys - the groups, 
//          and values - arrays with persons in this groups.
//          - Use function overloading (i.e. just one function)

var taskSix = function () {
    "use strict";
    var brake = "<br />";

    function Person(firstName, lastName, age) {
        if (this === window) {
            return new Person(firstName, lastName, age);
        }

        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    function ListOfPersons() {
        if (this === window) {
            return new ListOfPersons(arguments);
        }

        var args = Array.prototype.slice.call(arguments, 0);
        this.list = [];
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

        this.orderBy = function (property) {
            var result = {};
            for (var i = 0 ; i < this.list.length; i += 1) {
                if (!result[this.list[i][property]]) {
                    result[this.list[i][property]] = [];
                }

                result[this.list[i][property]].push(this.list[i]);
            }

            return result;
        };

        if (args) {
            this.addRange(args);
        }
    }

    var runMe = function () {
        var output = "Initial data has been hardcoded in order to simplify your task:" + brake + "Initial person objects:" + brake + brake;
        var persons = new ListOfPersons(new Person('Gosho', 'Petrov', 81), new Person('Gosho', 'Lyolyov', 12), new Person('Bay', 'Lyolyov', 81));
        output += persons.toString();
        var result = [persons.orderBy('firstName'), persons.orderBy('lastName'), persons.orderBy('age')];
        for (var sortIndex = 0; sortIndex < result.length; sortIndex++) {
            output += brake + 'Sorted by ' + (sortIndex === 0 ? 'firstName' : sortIndex === 1 ? 'lastName' : 'age') + ':' + brake;
            for (var orderIndex in result[sortIndex]) {
                output += orderIndex + ':' + brake;
                for (var memberIndex = 0; memberIndex < result[sortIndex][orderIndex].length; memberIndex++) {
                    output += " - " + JSON.stringify(result[sortIndex][orderIndex][memberIndex]) + brake;
                }
            }
        }

        return output;
    };

    return runMe();
};
