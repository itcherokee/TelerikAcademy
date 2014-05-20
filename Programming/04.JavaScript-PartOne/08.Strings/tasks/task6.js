// Task 6:  Write a function that extracts the content of a html page given as text.
//          The function should return anything that is in a tag, without the tags

var taskSix = function () {
    "use strict";
    var brake = "<br />";

    String.prototype.htmlEscape = function () {
        var escapedStr = String(this).replace(/&/g, '&amp;');
        escapedStr = escapedStr.replace(/</g, '&lt;');
        escapedStr = escapedStr.replace(/>/g, '&gt;');
        escapedStr = escapedStr.replace(/"/g, '&quot;');
        escapedStr = escapedStr.replace(/'/g, "&#39");
        return escapedStr;
    };

    function extractText(source) {
        var result = "";
        var previousChar = "";
        var inString = false;
        for (var index = 1; index < source.length; index++) {

            // take index-1 character and check is it an opening "<" or closing ">" of tag
            previousChar = source.charAt(index - 1);
            if (previousChar === '>' && source[index] !== '<') {

                // we are in text, not in tag
                inString = true;
            } else if (source[index] === '<' && inString) {

                // we are in tag, not in text
                inString = false;
            }

            if (inString) {

                // if we are in text, copy the char to result string
                result += source[index];
            }
        }

        return result;
    }

    var runMe = function () {
        var output = "Initial data has been hardcoded in order to simplify your task:" + brake + brake,
            text = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>";
        output += "Original text: " + brake + text.htmlEscape() + brake + brake;
        output += "Changed text: " + brake + extractText(text) + brake;

        return output;
    };

    return runMe();
};