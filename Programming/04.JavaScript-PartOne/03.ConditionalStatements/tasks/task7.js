// Task 7:  Write a script that finds the greatest of given 5 variables.

var taskSeven = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake + "Greatest number in [ ";
        var greatestNumber = Number.MIN_VALUE;
        var index;
        for (index = 1; index <= 5; index++) {
            var number = parseFloat(prompt("Enter number " + index));
            if (!isNaN(number)) {
                output += number + " ";
                if (number > greatestNumber) {
                    greatestNumber = number;
                }
            } else {
                output = "Invalid input detected (not a number)!";
                return output;
            }
        }

        output += "] is: " + greatestNumber;
        return output;
    };

    return runMe();
};