// Task 9:  Write an expression that checks for given point (x, y) if it is
//          within the circle K( (1,1), 3) and out of the rectangle 
//          R(top=1, left=-1, width=6, height=2).

var taskNine = function () {
    "use strict";
    var brake = "<br />";
    var circle = [[1, 1], 3];
    var rect = [[-1, 1], [5, -1]];

    var runMe = function () {
        var output = brake;
        var coordX = parseFloat(prompt("Enter point coordinate X "));
        var coordY = parseFloat(prompt("Enter point coordinate Y "));
        if (!isNaN(coordX) && !isNaN(coordY)) {
            // check point position against Circle
            var checkCircle = (((coordX - circle[0][0]) * (coordX - circle[0][0])) +
                    ((coordY - circle[0][1]) * (coordY - circle[0][1]))) <= (circle[1] * circle[1]);

            // ccheck point position against Rectangle
            var checkRectangle = (coordX < rect[0][0]) || (coordX > rect[1][0]) ||
                (coordY > rect[0][1]) || (coordY < rect[1][1]);
            var result = checkCircle && checkRectangle ? "" : "NOT ";
            output += "2D-Point is " + result + "within a circle and outside rectangle";
        } else {
            output = "Invalid input detected (not an integer or out of range)!";
        }

        return output;
    };

    return runMe();
};