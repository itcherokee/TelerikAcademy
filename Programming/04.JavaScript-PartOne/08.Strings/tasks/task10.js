// Task 10: Write a program that extracts from a given 
//          text all palindromes, e.g. "ABBA", "lamal", "exe".

var taskTen = function () {
    "use strict";
    var brake = "<br />";

    function isPalindromeCheck(word) {
        var isPalindrome = true;
        for (var index = 0; index < word.length; index++) {
            if (index >= word.length - 1 - index) {
                // if reached the word center -> exit loop and return current status of palindrome variable
                break;
            }

            if (word[index] !== word[word.length - 1 - index]) {
                isPalindrome = false;
                break;
            }
        }

        return isPalindrome;
    }

    String.prototype.findPalindromes = function findPalindroms() {
        var words = this.split(/\W+/);
        var result = [];
        for (var i = 0; i < words.length; i++) {
            if (words[i].length > 1) {
                if (isPalindromeCheck(words[i])) {
                    result.push(words[i]);
                }
            }
        }

        return result;
    };

    var runMe = function () {
        var output = brake;
        var text = prompt("Enter a text with palindromes inside to be extracted");
        output += "Palindromes in text are: " + brake;
        output += text.findPalindromes().join();

        return output;
    };

    return runMe();
};