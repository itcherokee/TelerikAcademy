// Task 2:  Write a function that removes all elements with a given value:
//          - Attach it to the array type

var taskTwo = function () {
    "use strict";
    var brake = "<br />";

    Array.prototype.remove = function (element) {
        var index = 0;
        while (index < this.length) {
            if (this[index] === element) {
                this.splice(index, 1);
            } else {
                index += 1;
            }
        }
    };

    var runMe = function () {
        var output = brake;
        output += "Initial data has been hardcoded in order to simplify your task:" + brake;
        var elements = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, "1"];
        output += "Initial: " + elements + brake;
        output += brake + "Let's remove all 4s. ....... Done" + brake;
        elements.remove(4);
        output += "Result: " + elements + brake;
        output += brake + "Let's remove all 1s (number) now ..... Done" + brake;
        elements.remove(1);
        output += "Result: " + elements + "  (last '1' is string, not number)" + brake;
        return output;
    };

    return runMe();
};