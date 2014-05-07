// Task 4:  Sort 3 real values in descending order using nested if statements.

var taskFour = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var firstNumber = parseFloat(prompt("Enter first number"));
        output += "Initial numbers: " + firstNumber;
        var secondNumber = parseFloat(prompt("Enter second number"));
        output += ", " + secondNumber;
        var thirdNumber = parseFloat(prompt("Enter third number"));
        output += ", " + thirdNumber + brake + "Sorted numbers: ";
        if (!isNaN(firstNumber) && !isNaN(secondNumber) && !isNaN(thirdNumber)) {
            if (firstNumber > secondNumber) {
                if (firstNumber > thirdNumber) {
                    output += firstNumber + ", ";
                    if (secondNumber > thirdNumber) {
                        output += secondNumber + ", " + thirdNumber;
                    } else {
                        output += thirdNumber + ", " + secondNumber;
                    }
                }
                else {
                    output += thirdNumber + ", " +
                            firstNumber + ", " + secondNumber;
                }
            }
            else if (secondNumber > thirdNumber) {
                output += secondNumber + ", ";
                if (firstNumber > thirdNumber) {
                    output += firstNumber + ", " + thirdNumber;
                }
                else {
                    output += thirdNumber + ", " + firstNumber;
                }
            }
            else {
                output += thirdNumber + ", " + secondNumber + ", " + firstNumber;
            }
        } else {
            output = "Invalid input detected (not an integer)!";
        }

        return output;
    };

    return runMe();
};