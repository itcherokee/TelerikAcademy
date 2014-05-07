// Task 6:  Write a program that finds the most frequent number in an array. 
//			Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times).

var taskSix = function () {
    "use strict";
    var brake = "<br />";

    function findMaxOfEquals(input) {
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

        // return result as a new object
        return { number: maxElement, times: maxCount };
    }

    var runMe = function () {
        var output = brake;
        var enteredSequence = prompt("Enter sequence splited by comma (,)").split(/(?:,| )+/);
        output += "Elements: " + enteredSequence + brake;
        var len = enteredSequence.length;
        var numbers = [];
        var index = 0;
        for (index; index < len; index++) {
            var element = parseInt(enteredSequence[index], 10);
            if (!isNaN(element)) {
                numbers.push(element);
            } else {
                return "Invalid input detected (not a number)";
            }
        }

        numbers.sort();
        var result = findMaxOfEquals(numbers);
        output += "Element '" + result.number + "' appeared (" + result.times + ") times";
        return output;
    };

    return runMe();
};