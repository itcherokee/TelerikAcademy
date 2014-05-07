// Task 3:  Write a script that finds the biggest of three integers 
//          using nested if statements.

var taskThree = function () {
    "use strict";

    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var firstNumber = parseInt(prompt("Enter first integer"), 10);
        output += "First: " + firstNumber + brake;
        var secondNumber = parseInt(prompt("Enter second integer"), 10);
        output += "Second: " + secondNumber + brake;
        var thirdNumber = parseInt(prompt("Enter third integer"), 10);
        output += "Third: " + thirdNumber + brake;
        if (!isNaN(firstNumber) && !isNaN(secondNumber) && !isNaN(thirdNumber)) {
            if ((firstNumber === secondNumber) || (firstNumber === thirdNumber) ||
                    (secondNumber === thirdNumber)) {
                output = "There are numbers with equal value. Please reenter all.";
            } else {
                var biggestNumber;
                if (firstNumber > secondNumber) {
                    if (firstNumber > thirdNumber) {
                        biggestNumber = firstNumber;
                    } else {
                        biggestNumber = thirdNumber;
                    }
                } else if (secondNumber > thirdNumber) {
                    biggestNumber = secondNumber;
                } else {
                    biggestNumber = thirdNumber;
                }

                output += brake + "The biggest number of entered ones is: " + biggestNumber;
            }
        } else {
            output = "Invalid input detected (not an integer)!";
        }

        return output;
    };

    return runMe();
};