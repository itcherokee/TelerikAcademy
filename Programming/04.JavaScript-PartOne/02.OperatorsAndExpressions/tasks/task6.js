// Task 6:  Write an expression that checks if given print (x,  y) 
//          is within a circle K(O, 5).

var taskSix = function () {
    "use strict";
    var brake = "<br />";
    var radius = 5;

    var runMe = function () {
        var output = brake;
        var coordX = parseFloat(prompt('Enter coordinate X'));
        var coordY = parseFloat(prompt('Enter coordinate Y'));
        if (!isNaN(coordX) && !isNaN(coordY)) {
            var result = ((coordX * coordX) + (coordY * coordY)) > (radius * radius) ? "OUTSIDE" : "WITHIN";
            output += "Point with coordinates (" + coordX + "," + coordY +
                    ") is " + result + " circle [(0,0),5].";
        } else {
            output = "Invalid input detected (not a number)!";
        }

        return output;
    };

    return runMe();
};