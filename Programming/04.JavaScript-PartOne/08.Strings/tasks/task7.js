// Task 7:  Write a script that parses an URL address given in the format: 
//          [protocol]://[server]/[resource] and extracts from it the 
//          [protocol], [server] and [resource] elements. Return the elements 
//          in a JSON object.

var taskSeven = function () {
    "use strict";
    var brake = "<br />";

    function convertToJson(source) {
        // copy the protocol into JSON
        var target = "{protocol: \"" + source.slice(0, source.indexOf(':')) + "\", ";
        var startIndex = source.indexOf("://") + 3;
        
        // find start of the resource 
        var endIndex = source.indexOf('/', startIndex);
        if (endIndex > 0) {
            target += "server: \"" + source.slice(startIndex, endIndex) + "\", ";
            target += "resource: \"" + source.slice(endIndex, source.length) + "\"}";
        } else {
            
            // there is no resource & we copy into JSON only the server
            target += "server: \"" + source.slice(startIndex, source.length) + "\"}";
        }
        
        return target;
    }

    var runMe = function () {
        var output = "Initial data has been hardcoded in order to simplify your task:" + brake + brake,
            text = "http://www.devbg.org/forum/index.php";
        output += "Original URL: " + brake + text + brake + brake;
        output += "Parsed as JSON: " + brake + convertToJson(text) + brake;

        return output;
    };

    return runMe();
};