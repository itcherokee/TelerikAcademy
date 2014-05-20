// Task 11: Write a function that formats a string using placeholders.
//          The function should work with up to 30 placeholders and all types.

var taskEleven = function () {
    "use strict";
    var brake = "<br />";

    function formatString(source) {
        // checks the provided arguments and extracts one (first) as it is the string to be modified
        var argsNumber = arguments.length - 1,
            target = "",
            position = 0,
            index = 0,
            replacement = false;
        while (true) {
            index = source.indexOf("{", position++);
            if (index < 0) {

                // there is no placeholders, but in order to copy the noraml text we define a fake replacement
                replacement = true;
                break;
            }

            var argIndex,
                oldValue;
            if (argsNumber < 10) {
                if (source.charAt(index + 2) === "}") {

                    // it is a single number placeholder and we are replacing it with corresponding 
                    // value from arguments array by adding it to current target string
                    argIndex = parseInt(source.charAt(index + 1)) + 1;
                    oldValue = arguments[argIndex];
                    target += source.slice(--position, index) + oldValue;
                    position = index + 3;
                    if (arguments[argIndex] === undefined) {
                        replacement = true;
                    }
                }
            } else {
                if (source[index + 3] === "}") {

                    // it is a double number placeholder and we are replacing it with corresponding 
                    // value from arguments array by adding it to current target string
                    argIndex = parseInt(source.slice(index + 1, index + 2)) + 1;
                    oldValue = arguments[argIndex];
                    target += source.slice(--position, index) + oldValue;
                    position = index + 4;
                    if (arguments[argIndex] === undefined) {
                        replacement = true;
                    }
                }
            }
        }

        // if there was a replacement copy the rest of the source string if any and paste it to target string
        if (--position < source.length && replacement) {
            target += source.slice(position);
        }

        return target;
    }

    var runMe = function () {
        var output = brake + "Test data are fixed, but function can hold any number of placeholders." + brake;
        var textWithPlaceholders = "{0}, {1}, {0} text {2}";
        output += "Text with placeholders: " + textWithPlaceholders + brake + brake;
        output += "Result: " + formatString(textWithPlaceholders, 1, "Pesho", "Gosho");

        return output;
    };

    return runMe();
};