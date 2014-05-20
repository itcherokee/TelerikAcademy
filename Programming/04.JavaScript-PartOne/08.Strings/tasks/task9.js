// Task 9:  Write a function for extracting all email addresses from given text. 
//          All substrings that match the format <identifier>@<host>…<domain> 
//          should be recognized as emails. Return the emails as array of strings.

var taskNine = function () {
    "use strict";
    var brake = "<br />";

    function extractEmails(source) {
        // using "gi" at the end of the regular expression, generates an array of 
        // all e-mails matches and also makes it case insensitive
        return source.match(/([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+)/gi);
    }

    var runMe = function () {
        var output = brake;
        var text = prompt("Enter some text with e-mails in it:");
        output += "Extracted e-mails:" + brake;
        output += extractEmails(text);

        return output;
    };

    return runMe();
};