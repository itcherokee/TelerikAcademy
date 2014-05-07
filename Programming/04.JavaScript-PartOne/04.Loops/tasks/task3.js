// Task 3:  Write a script that finds the max and min number from a sequence of numbers.

var taskThree = function () {
    "use strict";
    var brake = "<br />";

    function error() {
        return "Invalid input detected (not a number)!";
    }

    var runMe = function () {
        var output = brake;
        var max, min;
        var input = prompt("Enter numbers separated by SPACE").split(" ");
        var firstNum = parseFloat(input[0]);
        if (!isNaN(firstNum)) {
            max = firstNum;
            min = max;
        } else {
            return error();
        }

        var index;
        var len = input.length;
        for (index = 0; index < len; index++) {
            var number = parseFloat(input[index]);
            if (!isNaN(number)) {
                if (min > number) {
                    min = number;
                }

                if (max < number) {
                    max = number;
                }
            } else {
                return error();
            }
        }

        max = "Max number is: " + max;
        min = "Min number is: " + min;
        output += max + brake + min;
        return output;
    };

    return runMe();
};