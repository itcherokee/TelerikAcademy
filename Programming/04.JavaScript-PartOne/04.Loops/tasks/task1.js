// Task 1:  Write a script that prints all the numbers from 1 to N.

var taskOne = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake,
            number = parseInt(prompt("Enter upper border N"), 10);
        if (!isNaN(number) && number >= 1) {
            var index;
            for (index = 1; index <= number; index++) {
                output += index + " ";
            }
        } else {
            output = "Invalid input detected (not an integer or out of range)!";
        }

        return output;
    };

    return runMe();
};