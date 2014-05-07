// Task 6:  Write a function that checks if the element at given position in 
//			given array of integers is bigger than its two neighbours (when such exist).

var taskSix = function () {
    "use strict";
    var brake = "<br />";

    function isBigger(array, index) {
        var len = array.length;
        if ((len !== 1) && (index >= 0) && (index <= len - 1)) {
            if (index === 0) {
                // first element in array
                return array[index] > array[index + 1] ? true : false;
            } else if (index === len - 1) {
                // last element in array
                return array[index] > array[index - 1] ? true : false;
            } else {
                // internal element in array
                return ((array[index] > array[index + 1]) && (array[index] > array[index - 1])) ? true : false;
            }
        } else {
            return null;
        }
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
        var index = parseInt(prompt("Enter element index to check"), 10);
        if (numbers.valid && !isNaN(index) && index >= 0 &&
                index < numbers.data.length) {
            output = "Array:" + numbers.data.join() + brake;
            if (isBigger(numbers.data, index)) {
                output += "Yes, the element '" + numbers.data[index] + "' is bigger than neighbours.";
            } else {
                output += "No,  the element '" + numbers.data[index] + "' is NOT bigger than neighbours.";
            }
        } else {
            output = "Invalid input detected (not a number)!";
            return output;
        }

        return output;
    };

    return runMe();
};