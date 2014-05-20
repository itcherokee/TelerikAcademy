// Task 1:  Write a JavaScript function reverses string and returns it. 
//          Example: "sample" -> "elpmas".

var taskOne = function () {
    "use strict";
    var brake = "<br />";

    String.prototype.reverse = function () {
        var reversed = '';
        for (var index = this.length - 1; index >= 0; index -= 1) {
            reversed += this.charAt(index);
        }

        return reversed;
    };

    var runMe = function () {
        var output = brake + "Entered string is: ";
        var word = prompt("Enter a string");
        output += word + brake + "Reversed string is: " + word.reverse();
        return output;
    };

    return runMe();
};