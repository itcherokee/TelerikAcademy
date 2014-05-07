// Task 1:  Write a script that allocates array of 20 integers and 
//			initializes each element by its index multiplied by 5. 
//			Print the obtained array on the console

var taskOne = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var numbers = new Array(20);
        var index, len = numbers.length;
        for (index = 0; index < len; index++) {
            numbers[index] = index * 5;
        }

        output += "Array: " + brake + numbers;
        return output;
    };

    return runMe();
};