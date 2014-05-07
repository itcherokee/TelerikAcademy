// Task 1:  Write an expression that checks if given integer is odd or even.

var taskOne = function () {
    "use strict";

    var runMe = function () {
        var output;
        var number = parseInt(prompt("Enter an integer"), 10);
        if (!isNaN(number)) {
            output = "Number " + number + " is " +
                ((number % 2) === 0 ? "EVEN" : "ODD");
        } else {
            output = "Invalid input detected (not an integer)!";
        }

        return output;
    };

    return runMe();
};