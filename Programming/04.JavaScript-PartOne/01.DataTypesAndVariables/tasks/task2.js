// Task 2: Create a string variable with quoted text in it. For example: 'How you doin'?', Joey said.

var taskTwo = function () {
    "use strict";

    // Quoted string variable
    var text = "\"How you doin'?\", Joey said, after \"shot\" the rabbit.";

    var runMe = function () {
        var output;
        output = text + "<br />";
        return output;
    };

    return runMe();
};