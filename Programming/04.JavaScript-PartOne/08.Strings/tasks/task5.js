// Task 5:  Write a function that replaces non breaking white-spaces in a text with &nbsp;

var taskFive = function () {
    "use strict";
    var brake = "<br />";

    function replaceWhitespace(source) {
        var whitespaceIndex = 0;
        var position = 0;
        var target = "";
        while (true) {
            whitespaceIndex = source.indexOf(" ", position);
            if (whitespaceIndex < 0) {
                // if no more whitespaces, exit the loop and return the new (target) string
                break;
            }

            // copy the text from previous white space to newly found into new string (target)
            target += source.slice(position, whitespaceIndex) + "&amp;nbsp;";
            position = whitespaceIndex + 1;
        }

        // if we did not reach the end of the source string, copy the rest 
        // of text (after last whitespace) into new string (target)
        if (position < source.length) {
            target += source.slice(position, source.length);
        }
        return target;
    }

    var runMe = function () {
        var output = "Original text:" + brake;
        var text = prompt("Enter some text with spaces");
        output += text + brake;
        output += brake + "Modified text:" + brake;
        output += replaceWhitespace(text) + brake;

        return output;
    };

    return runMe();
};