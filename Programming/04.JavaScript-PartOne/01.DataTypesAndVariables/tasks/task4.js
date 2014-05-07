// Task 4: Create null, undefined variables and try typeof on them.

var taskFour = function () {
    "use strict";

    // undefined variable
    var undefinedVariable = undefined;

    // null variable
    var nullVariable = null;

    // NaN variable
    var nanVariable = NaN;

    // Infinity variable
    var infinityVariable = Infinity;

    // -Infinity variable
    var mInfinitiVariable = -Infinity;

    var runMe = function () {
        var output;
        output = "typeof(undefinedVariable) =  " + typeof (undefinedVariable) + "<br />";
        output += "typeof(nullVariable) = " + typeof (nullVariable) + "<br />";
        output += "typeof(nanVariable) =  " + typeof (nanVariable) + "<br />";
        output += "typeof(infinityVariable) = " + typeof (infinityVariable) + "<br />";
        output += "typeof(mInfinitiVariable) =  " + typeof (mInfinitiVariable) + "<br />";
        return output;
    };

    return runMe();
};