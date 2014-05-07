// Task 1: Assign all the possible JavaScript literals to different variables.

var taskOne = function () {
    "use strict";

    // Integer type
    var intNumber = 1;

    // Floating type
    var floatNumber = 1.1;

    // String type
    var text = "I'm string";

    // Boolean type
    var bool = true;

    // Function type
    var func = function () {
        return "I do nothing!";
    };

    // Object type
    var obj = {
        name: "I'm Object",
        value: 0.1
    };

    var runMe = function () {
        var output;
        output = "Integer: intNumber = " + intNumber + "<br />";
        output += "Float: floatNumber = " + floatNumber + "<br />";
        output += "String: text = " + text + "<br />";
        output += "Boolean: bool = " + bool + "<br />";
        output += "Function: func = " + func + "<br />";
        output += "Object: obj = " + JSON.stringify(obj, null, 4) + "<br />";
        return output;
    };

    return runMe();
};