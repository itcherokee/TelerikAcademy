// Task 2:  Write a script that shows the sign (+ or -) of the product of three
//          real numbers without calculating it. Use a sequence of if statements.

var taskTwo = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var firstNumber = parseFloat(prompt("Enter first number"));
        var secondNumber = parseFloat(prompt("Enter second number"));
        var thirdNumber = parseFloat(prompt("Enter third number"));
        if (!isNaN(firstNumber) && !isNaN(secondNumber) && !isNaN(thirdNumber)) {
            var counter = 0;
            if (!(firstNumber && secondNumber && thirdNumber)) {
                counter = -1;
            } else {

                if (firstNumber < 0) {
                    counter++;
                }

                if (secondNumber < 0) {
                    counter++;
                }

                if (thirdNumber < 0) {
                    counter++;
                }
            }

            switch (counter) {
                case 0:
                case 2:
                    output += "Product sign will be positive.";
                    break;
                case 1:
                case 3:
                    output += "Product sign will be negative.";
                    break;
                default:
                    output += "Product will be zero (no sign applicable).";
                    break;
            }
        } else {
            output = "Invalid input detected (not a number)!";
        }

        output += "<br />Here is the proof: " +
            firstNumber + " x " + secondNumber + " x " + thirdNumber + " = " + firstNumber * secondNumber * thirdNumber;
        return output;
    };

    return runMe();
};