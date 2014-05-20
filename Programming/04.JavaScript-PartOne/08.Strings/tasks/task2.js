// Task 2:  Write a JavaScript function to check if in a given expression the brackets are put correctly.
//          - Example of correct expression: ((a+b)/5-d).
//          - Example of incorrect expression: )(a+b)).

var taskTwo = function () {
    "use strict";
    var brake = "<br />";

    function hasCorrectBrackets(source) {

        if (!source || source.indexOf("(") === -1 && source.indexOf(")") === -1) {
            return undefined;
        } else if ((source.indexOf("(") === -1 && source.indexOf(")") !== -1) ||
                (source.indexOf("(") !== -1 && source.indexOf(")") === -1) ||
                (source.indexOf("(") > source.indexOf(")"))) {
            return false;
        } else {
            var index = 0,
                len = source.length,
                brackets = [];
            for (index; index < len; index++) {
                if (source[index] === "(") {
                    brackets.push("(");
                } else if (source[index] === ")") {
                    if (brackets.length) {
                        brackets.pop();
                    } else {
                        // there is a closing bracket without corresponding opening one.
                        return false;
                    }
                }
            }

            if (brackets.length) {
                return false;
            } else {
                return true;
            }

        }
    }

    var runMe = function () {
        var output = brake + "The expression brackets are: ";
        var expression = prompt("Enter an expression with brackets in it");
        switch (hasCorrectBrackets(expression)) {
            case true:
                output += "OK";
                break;
            case false:
                output += "Wrong!";
                break;
            default:
                output += "There were no brackets!";
                break;
        }

        return output;
    };

    return runMe();
};