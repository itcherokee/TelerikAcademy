// Task 8:  Write an expression that calculates trapezoid's area 
//          by given sides a and b and height h.

var taskEight = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var aBase = parseFloat(prompt("Enter 'a' (bottom base)"));
        var bBase = parseFloat(prompt("Enter 'b' (top base)"));
        var height = parseFloat(prompt("Enter 'h' (height)"));
        if (!isNaN(aBase) && !isNaN(bBase) && !isNaN(height)) {
            output += '"a" - base = ' + aBase + "cm" + brake;
            output += '"b" - base = ' + bBase + "cm" + brake;
            output += '"h" - height = ' + height + "cm" + brake;
            output += "Trapezoid area = " + 
			(((aBase + bBase) / 2) * height) + "cm&sup2";
        } else {
            output = "Invalid input detected (not an integer or out of range)!";
        }

        return output;
    };

    return runMe();
};