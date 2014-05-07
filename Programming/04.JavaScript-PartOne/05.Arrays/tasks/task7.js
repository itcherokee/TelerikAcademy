// Task 7:  Write a program that finds the index of given element in 
//			a sorted array of integers by using the binary search 
//			algorithm (find it in Wikipedia).

var taskSeven = function () {
    "use strict";
    var brake = "<br />";

    function binarySearch(input, search) {
        var notFound = -1;
        var left = 0;
        var right = input.length - 1;
        var isKeyFound = false;
        var middle = notFound;
        while (left <= right) {
            middle = Math.floor((left + right) / 2);
            if (input[middle] === search) {
                isKeyFound = true;
                break;
            } else {
                if (input[middle] > search) {
                    right = middle - 1;
                } else {
                    left = middle + 1;
                }
            }
        }

        if (isKeyFound) {
            return middle;
        } else {
            return notFound;
        }
    }

    var runMe = function () {
        var output = brake;
        var enteredSequence = prompt("Enter array of numbers splited by comma (,)").split(/(?:,| )+/);
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

        var elementToSearch = parseInt(prompt("Enter element to search"), 10);
        numbers.sort();
        output += "Sorted: " + numbers + brake;
        index = binarySearch(numbers, elementToSearch);
        if (index !== -1) {
            output += "Searched element (" + elementToSearch + ") is at index " + index;
        } else {
            output += "Element '" + elementToSearch + "' is not found";
        }

        return output;
    };

    return runMe();
};