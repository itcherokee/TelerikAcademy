// Task 5:  Sorting an array means to arrange its elements in increasing order. 
//          Write a script to sort an array. Use the "selection sort" algorithm: 
//          Find the smallest element, move it at the first position, find 
//          the smallest from the rest, move it at the second position, etc. 

var taskFive = function () {
    "use strict";
    var brake = "<br />";
    var numbers = [45, 2, 67, 3, 6, 75, 0, 2, 42, 6, 73, 667, 8, 4, 2, 78, 3];

    var runMe = function () {
        var output = brake + "Initial array: " + numbers + brake;
        var indexOuter = 0;
        var len = numbers.length;
        for (indexOuter; indexOuter < len; indexOuter++) {
            var minimal = indexOuter;
            var indexInner = indexOuter + 1;
            for (indexInner; indexInner < len; indexInner++) {
                if (numbers[minimal] > numbers[indexInner]) {
                    minimal = indexInner;
                }
            }
            var temp = numbers[minimal];
            numbers[minimal] = numbers[indexOuter];
            numbers[indexOuter] = temp;
        }

        output += "Sorted array: " + numbers;
        return output;
    };

    return runMe();
};