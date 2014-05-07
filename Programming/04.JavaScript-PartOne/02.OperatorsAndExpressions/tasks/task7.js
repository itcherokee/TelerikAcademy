// Task 7:  Write an expression that checks if given positive integer
//          number n (n ≤ 100) is prime. E.g. 37 is prime.

var taskSeven = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var number = parseInt(prompt("Enter positive number "));
        if (!isNaN(number) && number > 1 && number <= 100) {
            var upperBorder = Math.sqrt(number);
            if (number >= 2 && number <= 7) {
                output += "The number you have entered is a prime number!";
            } else {
                // skip divisors which are even
                if ((number % 2) !== 0) {
                    for (var i = 3; i <= upperBorder; i++) {
                        if ((number % i) === 0) {
                            output += number + " is NOT a prime number!";
                            break;
                        } else {
                            output += number + " is a prime number!";
                            break;
                        }
                    }
                } else {
                    output += number + " is NOT a prime number!";
                }
            }
        } else {
            output = "Invalid input detected (not a number)!";
            return output;
        }

        return output;
    };

    return runMe();
};