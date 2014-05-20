// Task 3:  Write a function that finds all the occurrences of word in a text: 
//			- The search can case sensitive or case insensitive; 
//			- Use function overloading.

var taskThree = function () {
    "use strict";
    var brake = "<br />";

    function count(arr, word) {
        var counter = 0;
        for (var element in arr) {
            if (arr[element] === word) {
                counter++;
            }
        }

        return counter;
    }

    function countWord(array, wrd, caseInsensite) {
        var result = 0,
            word = wrd;
        switch (arguments.length) {
            case 2: result = count(array, wrd); break;
            case 3:
                if (caseInsensite) {
                    word = (wrd + "").toLowerCase();
                    for (var item in array) {
                        array[item] = (array[item] + "").toLowerCase();
                    }
                }

                result = count(array, word);
                break;
        }

        return result;
    }

    var runMe = function () {
        var output = brake;
        var text = prompt("Enter some text").split(/(?:,| )+/);
        var word = prompt("Enter word to count");
        var caseSensitive = confirm("Use case sensitive");
        output += "Text: " + text.join(" ") + brake;
        output += "Word count is: ";
        if (caseSensitive) {
            output += countWord(text, word);
        } else {
            output += countWord(text, word, true);
        }

        return output;
    };

    return runMe();
};