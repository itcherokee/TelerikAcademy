// Task 3: Try typeof on all variables you created.

var taskThree = function () {
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
        output = "typeof(intNumber) =  " + typeof (intNumber) + "<br />";
        output += "typeof(floatNumber) = " + typeof (floatNumber) + "<br />";
        output += "typeof(text) = " + typeof (text) + "<br />";
        output += "typeof(bool) = " + typeof (bool) + "<br />";
        output += "typeof(func) = " + typeof (func) + "<br />";
        output += "typeof(obj) = " + typeof (obj) + "<br />";
        return output;
    };

    return runMe();
};