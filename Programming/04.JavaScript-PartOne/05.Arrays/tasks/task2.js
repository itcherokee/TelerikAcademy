// Task 2:  Write a script that compares two char arrays 
//			lexicographically (letter by letter).
// Rules:
// - empty arrays -> no match possible 
// - one array is empty -> winner (nothing is before anything)
// - one array is shorter, but identical with first part of the other -> shorter wins
// - one array is shorter, but identical with middle or end part of the longer, if longer first char is smaller -> longer wins; else shorter wins
// - arrays are identical -> total equality, both wins
// - arrays are different in one or more elements (could be equal or not in length) -> the one with first smaller element wins
// 
// Constraints:
// - arrays should not be sorted within algorithm
// - space is not considered as a char (at least in provided code) and will be removed from input

var taskTwo = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var arrayOne = prompt("Enter first sequence of chars").split("");
        output += "Array One: " + arrayOne + brake;
        var arrayTwo = prompt("Enter first sequence of chars").split("");
        output += "Array Two: " + arrayTwo + brake;
        var arrOneLength = arrayOne.length;
        var arrTwoLength = arrayTwo.length;
        var areEqualLength = arrOneLength === arrTwoLength;
        var shorterArray = arrOneLength < arrTwoLength ? arrayOne : arrayTwo;
        if (arrOneLength !== 0 && arrTwoLength !== 0) {
            // Compare elements by using ASCII code of each one; 
            // if difference, select winner and exit the program
            var index = 0;
            var shorterArrLen = shorterArray.length;
            for (index; index < shorterArrLen; index++) {
                if (arrayOne[index] < arrayTwo[index]) {
                    output += "First array wins!";
                    return output;
                }

                if (arrayOne[index] > arrayTwo[index]) {
                    output += "Second array wins!";
                    return output;
                }
            }

            // both arrays are identical - check length to select winner
            if (areEqualLength) {
                output += "Both char arrays are winners!";
            } else if (arrOneLength < arrTwoLength) {
                output += "First char array wins!";
            } else {
                output += "Second char array wins!";
            }
        } else {
            // both or one of the arrays are empty 
            if (areEqualLength) {
                output += "Both arrays are empty, so there is no match possible!";
            } else if (arrOneLength === 0) {
                output += "First array is empty, so it is the winner!";
            } else {
                output += "Second array is empty, so it is the winner!";
            }
        }

        return output;
    };

    return runMe();
};