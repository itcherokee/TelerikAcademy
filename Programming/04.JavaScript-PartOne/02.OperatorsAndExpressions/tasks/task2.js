// Task 2:  Write a boolean expression that checks for given integer if it can 
//          be divided (without remainder) by 7 and 5 in the same time.

var taskTwo = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var number = parseInt(prompt("Enter first number"), 10);
        if (!isNaN(number)) {
            if ((number % 7) === 0 && (number % 5) === 0) {
                output += number + " can be divided by 5 and 7 at the same time!";
            } else {
                output += number + " can NOT be divided by 5 and 7 at the same time!";
            }
        } else {
            output = "Invalid input detected (not a number)!";
        }

        return output;
    };

    return runMe();
};