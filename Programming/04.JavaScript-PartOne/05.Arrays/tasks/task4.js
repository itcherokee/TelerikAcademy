// Task 4:  Write a script that finds the maximal increasing sequence in an array. 
//			Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

var taskFour = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var enteredSequence = prompt("Enter sequence splited by comma (,)").split(/(?:,| )+/);
        output += "Elements: " + enteredSequence + brake;
        var len = enteredSequence.length;
        var input = [];
        var index = 0;
        // convert to numbers the input
        for (index; index < len; index++) {
            var element = parseInt(enteredSequence[index], 10);
            if (!isNaN(element)) {
                input.push(element);
            } else {
                return "Invalid input detected (not a number)";
            }
        }

        if (len > 1) {
            var maxCount = 0;
            var maxStartSeq = 0;
            var startSeq = 0;
            var currentElement = input[0];
            var currentCount = 1;
            for (index = 1; index < len; index++) {
                var next = input[index];
                if (currentElement === next - 1) {
                    currentElement = next;
                    currentCount++;
                } else {
                    if (maxCount < currentCount) {
                        maxStartSeq = startSeq;
                        maxCount = currentCount;
                    }

                    currentElement = input[index];
                    currentCount = 1;
                    startSeq = index;
                }

                // check if last element in loop
                if (index === len - 1 && maxCount < currentCount) {
                    maxStartSeq = startSeq;
                    maxCount = currentCount;
                }
            }

            // prepare output
            output += "Max increasing sequence: {";
            for (index = 0; index < maxCount; index++) {
                output += input[maxStartSeq + index];
                if (index < maxCount - 1) {
                    output += ", ";
                } else {
                    output += "}";
                }
            }
        } else {
            output += "You need to enter at least two elements.";
        }

        return output;
    };

    return runMe();
};