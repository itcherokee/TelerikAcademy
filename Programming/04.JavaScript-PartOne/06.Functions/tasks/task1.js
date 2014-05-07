// Task 1:  Write a function that returns the last digit of given integer 
//			as an English word. Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine"

var taskOne = function () {
    "use strict";
    var brake = "<br />";

    function translate(digit) {
        var result = "";
        switch (digit) {
            case 0:
                result = "zero";
                break;
            case 1:
                result = "one";
                break;
            case 2:
                result = "two";
                break;
            case 3:
                result = "three";
                break;
            case 4:
                result = "four";
                break;
            case 5:
                result = "five";
                break;
            case 6:
                result = "six";
                break;
            case 7:
                result = "seven";
                break;
            case 8:
                result = "eight";
                break;
            case 9:
                result = "nine";
                break;
            default:
                result = "Entered number out of requested bounadry!";
                break;
        }

        return result;
    }

    var runMe = function () {
        var output = brake + "Last digit is: ";
        var number = parseInt(prompt("Enter an integer"), 10);
        if (!isNaN(number)) {
            output += translate(number % 10);
        } else {
            output = "Invalid input detected (not an integer)!";
        }

        return output;
    };

    return runMe();
};