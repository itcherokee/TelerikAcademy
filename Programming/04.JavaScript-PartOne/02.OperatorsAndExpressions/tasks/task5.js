// Task 5:  Write a boolean expression for finding if the bit 3 (counting from 0) 
//          of a given integer is 1 or 0.

var taskFive = function () {
    "use strict";
    var brake = "<br />";
    var mask = 0x08; // 3rd bit set

    var runMe = function () {
        var output = brake;
        var number = parseInt(prompt("Enter an integer"), 10);
        if (!isNaN(number)) {
            
            var checkedNumberMasked = number & mask;
            var bitResult = checkedNumberMasked >> 3;
            if (bitResult === 0) {
                output += "The bit at the 3rd position (counting from 0) is 0";
            } else {
                output += "The bit at the 3rd position (counting from 0) is 1";
            }
			
			output += brake + "Number as binary: " + number.toString(2);
        } else {
            output = "Invalid input detected (not an integer)!";
        }

        return output;
    };

    return runMe();
};