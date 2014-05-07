// Task 3:  Write a script that finds the maximal sequence of 
//			equal elements in an array.	
//			Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.

var taskThree = function () {
    "use strict";

    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var input = prompt("Enter sequence").split(/(?:,| )+/);
        output += "Elements: " + input + brake;
        var currentCount = 1;
        var maxElement = input[0];
        var maxCount = 1;
        var currentElement = input[0];
        var next;
        var index = 1;
        var len = input.length;
        for (index; index < len; index++) {
            next = input[index];
            if (currentElement === next) {
                currentCount++;
            } else {
                if (maxCount < currentCount) {
                    maxElement = currentElement;
                    maxCount = currentCount;
                }

                currentElement = input[index];
                currentCount = 1;
            }
            
            // check if last element in loop
            if (index === len - 1) {
                if (maxCount < currentCount) {
                    maxElement = currentElement;
                    maxCount = currentCount;
                }
            }
        }

        output += "Max sequence: {";
        for (index = 0; index < maxCount; index++) {
            output += maxElement;
            if (index < maxCount - 1) {
                output += ", ";
            } else {
                output += "}";
            }
        }

        return output;
    };

    return runMe();
};