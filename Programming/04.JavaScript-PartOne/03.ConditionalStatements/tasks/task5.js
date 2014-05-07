// Task 5:  Write script that asks for a digit and depending on the input 
//          shows the name of that digit (in English) using a switch statement.

var taskFive = function () {
    "use strict";

    var runMe = function () {
        var output;
        var digit = parseInt(prompt("Enter a digit [0..9]"), 10);
        if (!isNaN(digit)) {
            output = digit + " - ";
            switch (digit) {
                case 0:
                    output += "zero";
                    break;
                case 1:
                    output += "one";
                    break;
                case 2:
                    output += "two";
                    break;
                case 3:
                    output += "three";
                    break;
                case 4:
                    output += "four";
                    break;
                case 5:
                    output += "five";
                    break;
                case 6:
                    output += "six";
                    break;
                case 7:
                    output += "seven";
                    break;
                case 8:
                    output += "eight";
                    break;
                case 9:
                    output += "nine";
                    break;
                default:
                    output = "Entered number out of requested bounadry!";
                    break;
            }
        } else {
            output = "Invalid input detected (not an integer)!";
        }

        return output;
    };

    return runMe();
};