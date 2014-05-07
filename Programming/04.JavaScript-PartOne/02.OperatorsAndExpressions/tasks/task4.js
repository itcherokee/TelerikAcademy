// Task 4:  Write an expression that checks for given integer if its 
//          third digit (right-to-left) is 7. E. g. 1732 -> true.

var taskFour = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var number = parseFloat(prompt("Enter first number"));
        if (!isNaN(number)) {
            var result = (Math.floor(number / 100) % 10) !== 7 ? "NOT " : "";
            output += number +" - third digit (right-to-left) is " + result + 7;
        } else {
            output = "Invalid input detected (not an integer)!";
        }

        return output;
    };

    return runMe();
};