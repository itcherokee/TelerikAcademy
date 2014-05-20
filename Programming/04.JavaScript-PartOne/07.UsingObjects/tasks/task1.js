// Task 1:  Write functions for working with shapes in standard Planar coordinate system:
//          - Points are represented by coordinates P(X, Y)
//          - Lines are represented by two points, marking their beginning and ending
//          - L(P1(X1,Y1),P2(X2,Y2))
//          - Calculate the distance between two points
//          - Check if three segment lines can form a triangle.

var taskOne = function () {
    "use strict";
    var brake = "<br />";

    // define point object type
    function Point(x, y) {
        this.x = x;
        this.y = y;
    }

    // attach toString method of Point to it's prototype
    Point.prototype.toString = function () {
        return "x:" + this.x + ",y:" + this.y;
    };

    // define line object type
    function Line(pointOne, pointTwo) {
        this.start = pointOne;
        this.end = pointTwo;
    }

    // attach toString and length methods of Line to it's prototype
    Line.prototype.toString = function () {
        return "Line [start(" + this.start.toString() + ") - end(" + this.end.toString() + ")]";
    };

    Line.prototype.length = function () {
        return Math.sqrt(((this.end.x - this.start.x) * (this.end.x - this.start.x)) +
                ((this.end.y - this.start.y) * (this.end.y - this.start.y)));
    };

    // check can three lines form a triangle 
    function canFormTriangle(lineOne, lineTwo, lineThree) {
        var lineOneLength = lineOne.length(),
            lineTwoLength = lineTwo.length(),
            lineThreeLength = lineThree.length();
        if (lineOneLength + lineTwoLength > lineThreeLength && lineOneLength + lineThreeLength > lineTwoLength &&
                lineTwoLength + lineThreeLength > lineOneLength) {
            return true;
        } else {
            return false;
        }
    }

    var runMe = function () {
        var output = brake + "Initial data has been hardcoded in order to simplify your task:" + brake;

        // create lines & print on console (here you can change the coordinates of lines/points)
        var lineOne = new Line(new Point(1, 1), new Point(2, 2));
        var lineTwo = new Line(new Point(3, 4), new Point(3, 5));
        var lineThree = new Line(new Point(4, 5), new Point(2, 5));
        output += lineOne.toString() + brake + lineTwo.toString() + brake + lineThree.toString() + brake;

        // check does they can form triangle
        output += "Lets check can these lines form a triangle....." + brake;
        if (canFormTriangle(lineOne, lineTwo, lineThree)) {
            output += "These lines can form a triange.";
        } else {
            output += "These lines cannot form a triangle.";
        }

        return output;
    };

    return runMe();
};
