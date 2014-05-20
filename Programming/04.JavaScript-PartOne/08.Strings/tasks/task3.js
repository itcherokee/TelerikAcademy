// Task 3:  Write a JavaScript function that finds how many times a substring 
//          is contained in a given text (perform case insensitive search).

var taskThree = function () {
    "use strict";
    var brake = "<br />";

    String.prototype.countSubString = function (substringToSearch) {
        var source = this.toLowerCase(),
            target = substringToSearch.toLowerCase(),
            sourceLength = source.length,
            targetLength = target.length,
            counter = 0;

        if (targetLength === 0 || sourceLength === 0 || sourceLength < targetLength) {
            return counter;
        }

        var position = 0;
        while (position < sourceLength - targetLength + 1) {
            var index = source.indexOf(target, position);
            if (index !== -1) {
                counter += 1;
                position += index - position + targetLength;
            } else {
                position += 1;
            }
        }

        return counter;
    };

    var runMe = function () {
        var output = "Initial data has been hardcoded in order to simplify your task:" + brake + brake;
        var text = "We are living in an yellow submarine. We don't have anything else. " +
            "Inside the submarine is very tight. So we are drinking all the day. We will " +
            "move out of it in 5 days.";
        var substringToSearch = "in";
        output += "Text: " + brake + text + brake;
        output += brake + "Searched substring appears " + text.countSubString(substringToSearch) + " times.";
        return output;
    };

    return runMe();
};