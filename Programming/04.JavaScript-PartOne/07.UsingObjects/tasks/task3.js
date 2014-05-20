// Task 3:  Write a function that makes a deep copy of an object:
//          - The function should work for both primitive and reference types.

var taskThree = function () {
    "use strict";
    var brake = "<br />";

    function deepCopy(source) {
        var target;
        if (typeof source !== "object" || source === null) {
            target = source;
        } else if (source instanceof Date) {
            target = new Date();
            target.setTime(source.getTime());
        } else {
            target = source.constructor();
            if (source instanceof Array) {
                for (var index = 0; index < source.length; index += 1) {
                    target[index] = deepCopy(source[index]);
                }
            } else if (source instanceof Object) {
                for (var member in source) {
                    if (source.hasOwnProperty(member))
                        target[member] = deepCopy(source[member]);
                }
            }
        }

        return target;
    }

    var runMe = function () {
        var output = brake;
        output += "Initial data has been hardcoded in order to simplify your task:" + brake;
        var testSource = {
            number: 3,
            string: "alabala",
            array: new Array(2012, [12, 12], undefined),
            date: new Date(),
            nul: null,
            func: function () {
                this.number = 5;
            },
            toString: function () {
                return JSON.stringify(this);
                //return "{number: " + this.number + ", string: " + this.string + ", array: " + this.array +
                //        ", func :" + this.func + ", toString: " + this.toString + "}";
            }
        };

        var testTarget = deepCopy(testSource);
        output += "Original: " + brake + testSource + brake;
        output += brake + "Now let's made a deep copy (no difference): " + brake + testTarget + brake;
        testTarget.array = [1, 2];
        output += brake + "Let's change array values of the copied obj to [1,2]..." + brake;
        output += brake + "Finally the Original: " + brake + testSource + brake;
        output += brake + "New (changed array values): " + brake + testTarget + brake;
        return output;
    };

    return runMe();
};