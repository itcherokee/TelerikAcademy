// Task 1:  Write an if statement that examines two integer variables and 
//          exchanges their values if the first one is greater than the second one.

var taskOne = function () {
    "use strict";

    var runMe = function () {
        var output, firstNumber, secondNumber;
        firstNumber = parseInt(prompt("Enter first integer"), 10);
        secondNumber = parseInt(prompt("Enter second integer"), 10);
        if (!isNaN(firstNumber) && !isNaN(secondNumber)) {
            output = "<br />Initial values:<br /> First = " + firstNumber +
                    "<br /> Second = " + secondNumber;
            var exchanged;
            if (firstNumber > secondNumber) {
                exchanged = "exchnaged";
                firstNumber = firstNumber ^ secondNumber;
                secondNumber = firstNumber ^ secondNumber;
                firstNumber = firstNumber ^ secondNumber;
            } else {
                exchanged = "no need to be exchanged";
            }

            output += "<br />After check (" + exchanged + "):<br /> First = " +
                    firstNumber + "<br /> Second = " + secondNumber;
        } else {
            output = "Invalid input detected (not an integer)!";
        }

        return output;
    };

    return runMe();
};