// Task 7:  Write a function that returns the index of the first element 
//			in array that is bigger than its neighbors, or -1, if there’s 
//			no such element.Use the function from the previous exercise.

var taskSeven = function () {
    "use strict";
    var brake = "<br />";

    function isBigger(array, index) {
        var len = array.length;
        if ((len !== 1) && (index >= 0) && (index <= len - 1)) {
            if (index === 0) {
                return array[index] > array[index + 1] ? true : false;
            } else if (index === len - 1) {
                return array[index] > array[index - 1] ? true : false;
            } else {
                return ((array[index] > array[index + 1]) &&
                        (array[index] > array[index - 1])) ? true : false;
            }
        } else {
            return null;
        }
    }

    function firstBigger(arr) {
        if (arr.length !== 1) {
            var index = 0,
                len = arr.length;

            for (index; index < len; index++) {
                if (isBigger(arr, index)) {
                    return index;
                }
            }
        }

        return -1;
    }

    function enterData() {
        var enteredSequence = prompt("Enter sequence splited by comma (,)").split(/(?:,| )+/);
        var len = enteredSequence.length;
        var input = [];
        var index = 0;
        var isValid = true;
        // convert to numbers the input
        for (index; index < len; index++) {
            var element = parseInt(enteredSequence[index], 10);
            if (!isNaN(element)) {
                input.push(element);
            } else {
                isValid = false;
                break;
            }
        }

        if (!isValid) {
            input = [];
        }

        return { data: input, valid: isValid };
    }

    var runMe = function () {
        var output = brake;
        var numbers = enterData();
        if (numbers.valid) {
            output += "Array: " + numbers.data + brake;
            var index = firstBigger(numbers.data);
            output += "Index of first bigger element is: " + index +
                    " (number " + numbers.data[index] + ")";
        } else {
            output = "Invalid input detected (not a number)!";
            return output;
        }

        return output;
    };

    return runMe();
};