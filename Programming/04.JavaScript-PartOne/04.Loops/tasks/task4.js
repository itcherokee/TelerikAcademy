// Task 4:  Write a script that finds the lexicographically smallest and 
//          largest property in document, window and navigator objects.

var taskFour = function () {
    "use strict";
    var brake = "<br />";

    var runMe = function () {
        var output = brake;
        var entities = [document, window, navigator];
        var entity, len = entities.length;
        for (entity = 0; entity < len; entity++) {
            var properties = [];
            for (var property in entities[entity]) {
                properties.push(property);
            }

            properties.sort();
            output += entities[entity] + ":" + brake;
            output += "Min property: " + properties[0] + brake + "Max property: " + properties[properties.length - 1] + brake;
            properties.length = 0;
        }

        return output;
    };

    return runMe();
};