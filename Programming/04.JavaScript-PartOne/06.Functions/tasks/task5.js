// Task 5:  Write a function that counts how many times given number 
//			appears in given array. Write a test function to check 
//			if the function is working correctly.

var taskFive = function () {
    "use strict";
    var brake = "<br />";

    function countNumber(array, number) {
        var counter = 0;
        for (var element in array) {
            if (array[element] === number) {
                counter++;
            }
        }

        return counter;
    }

    var runMe = function () {
        var output = brake;
        var enteredSequence = prompt("Enter sequence splited by comma (,)").split(/(?:,| )+/);
        output += "Elements: " + enteredSequence + brake;
        var len = enteredSequence.length,
            input = [],
            index = 0;
        
        // convert to numbers the input
        for (index; index < len; index++) {
            var element = parseInt(enteredSequence[index], 10);
            if (!isNaN(element)) {
                input.push(element);
            } else {
                return "Invalid input detected (not a number)";
            }
        }

        var number = parseInt(prompt("Which number to count"), 10);
        if (!isNaN(number)) {
            output += "Number " + number + " count: " + countNumber(input, number);
        }

        return output;
    };

    return runMe();
};