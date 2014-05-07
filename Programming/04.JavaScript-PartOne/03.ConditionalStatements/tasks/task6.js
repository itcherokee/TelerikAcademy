// Task 6:  Write a script that enters the coefficients a, b and c of 
//          a quadratic equation: a*x^2; + b*x + c = 0 and calculates 
//          and prints its real roots. Note that quadratic equations 
//          may have 0, 1 or 2 real roots.

var taskSix = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var coefficientA = parseFloat(prompt('Coefficient "a"'));
        output += 'Coefficient "a" = ' + coefficientA + brake;
        var coefficientB = parseFloat(prompt('Coefficient "b"'));
        output += 'Coefficient "b" = ' + coefficientB + brake;
        var coefficientC = parseFloat(prompt('Coefficient "c"'));
        output += 'Coefficient "c" = ' + coefficientC + brake;
        if (!isNaN(coefficientA) && !isNaN(coefficientB) && !isNaN(coefficientC)) {
            if ((coefficientA === 0) && (coefficientB === 0) && (coefficientC === 0)) {
                output = "You have entered only 0 for all coefficients and the result " +
                        "is NaN (not a number) or in other words, there is no solution!";
            } else {
                var roots;
                if (coefficientA === 0) {
                    output = 'For "a" was entered 0, so equation is linear and solution is: ' +
                            (-(coefficientC / coefficientB));
                } else {
                    var discriminant = (coefficientB * coefficientB) - (4 * coefficientA * coefficientC);
                    if (discriminant === 0) {
                        roots = -(coefficientB / (2 * coefficientA));
                        output += "The equation has only one real root: " + roots;
                    } else if (discriminant > 0) {
                        output += "The equation has 2 real roots:" + brake;
                        output += "Root 1: " + ((-coefficientB) + Math.sqrt(discriminant)) /
                                (2 * coefficientA) + brake;
                        output += "Root 2: " + ((-coefficientB) - Math.sqrt(discriminant)) /
                                (2 * coefficientA);
                    } else {
                        output = "The equation has no real roots!";
                    }
                }
            }
        } else {
            output = "Invalid input detected (not an integer)!";
        }

        return output;
    };

    return runMe();
};