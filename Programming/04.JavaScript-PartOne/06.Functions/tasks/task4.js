// Task 4:  Write a function to count the number of divs on the web page.

var taskFour = function () {
    "use strict";
    var brake = "<br />";

    function countDiv() {
        var divs = document.getElementsByTagName('div');
        return divs.length;
    }

    var runMe = function () {
        var output = brake + "Number of div's on that page is: ";
        output += countDiv();
        return output;
    };

    return runMe();
};