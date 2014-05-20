// Task 2:  Write a function that reverses the digits of given 
//			decimal number. Example: 256 -> 652.

var taskTwo = function () {
    "use strict";
    var brake = "<br />";

    function reverse(digit) {
        var work = digit.toString(),
            result = "",
            len = work.length,
            index = len - 1;

        for (index; index >= 0; index--) {
            result += work[index];
        }

        return parseInt(result, 10);
    }

    var runMe = function () {
        var output = brake;
        var number = parseInt(prompt("Enter number to reverse"), 10);
        if (!isNaN(number)) {
            output += reverse(number);
        } else {
            output = "Invalid input detected (not a number)!";
        }

        return output;
    };

    return runMe();
};