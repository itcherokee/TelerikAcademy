// Task 3:  Write an expression that calculates rectangle’s area 
//          by given width and height.

var taskThree = function () {
    "use strict";

    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var width = parseInt(prompt("Enter rectangle's Width"), 10);
        var height = parseInt(prompt("Enter rectangle's Height"), 10);
        if (!isNaN(width) && !isNaN(height)) {
            if ((width * height) <= Number.MAX_VALUE) {
                output += "Rectangle's Width  = " + width + " cm" + brake;
                output += "Rectangle's Height = " + height + " cm" + brake;
                output += "Rectangle's Area   = " + width * height + " cm&sup2";
            } else {
                output = "Calculated area is too big as number to be shown!";
            }
        } else {
            output = "Invalid input detected (not an integer)!";
        }

        return output;
    };

    return runMe();
};