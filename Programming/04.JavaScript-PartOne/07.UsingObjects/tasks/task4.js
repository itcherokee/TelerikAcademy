// Task 4:  Write a function that checks if a given object contains a given property.

var taskFour = function () {
    "use strict";
    var brake = "<br />";

    function hasProperty(obj, property) {
        var result = false;
        for (var item in obj) {
            if (item === property) {
                result = true;
            }
        }

        return result;
    }

    var runMe = function () {
        var output = brake + "Initial data has been hardcoded in order to simplify your task:" + brake + brake + "Object with existing properties:" + brake;
        var testSource = { nomerche: 3, stringche: "alabala", obektche: { name: "obektchence" } };
        output += JSON.stringify(testSource) + brake;
        output += brake + "Let's do a check for some properties do they exist..." + brake;
        output += "- Property 'nomerche' exist: " + hasProperty(testSource, "nomerche") + brake;
        output += "- Property 'data' exist: " + hasProperty(testSource, "data") + brake;
        output += "- Property 'arrayche' exist: " + hasProperty(testSource, "arrayche") + brake;
        output += "- Property 'obektche' exist: " + hasProperty(testSource, "obektche") + brake;
        return output;
    };

    return runMe();
};