// Task 2:  Write a script that prints all the numbers from 1 to N, 
//          that are not divisible by 3 and 7 at the same time.

var taskTwo = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var number = parseInt(prompt("Enter upper border N"), 10);
        if (!isNaN(number) && number >= 1) {
            var index;
            for (index = 1; index <= number; index++) {
                if (index % 21 !== 0) {
                    output += index + " ";
                } 
            }
        } else {
            output = "Invalid input detected (not an integer or out of range)!";
        }

        return output;
    };

    return runMe();
};