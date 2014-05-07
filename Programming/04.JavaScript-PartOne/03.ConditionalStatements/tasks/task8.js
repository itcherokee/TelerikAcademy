// Task 8:  Write a script that converts a number in the range [0...999] 
//          to a text corresponding to its English pronunciation. 
//          Examples:   0 -> 'Zero'; 273 -> 'Two hundred seventy three'; 
//                      400 -> 'Four hundred'; 501 -> 'Five hundred and one'; 
//                      711 -> 'Seven hundred and eleven'.

var taskEight = function () {
    "use strict";
    var brake = "<br />";
    var numberNames = ["zero", "one", "two", "three", "four", "five", "six",
            "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen",
            "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen",
            "twenty", "thirty", "forty", "fifty", "eighty", "hundred", "ty"];

    var runMe = function () {
        var output = brake;
        var number = parseInt(prompt("Enter a number [0..999] to translate it to English"), 10);
        if (!isNaN(number) && number >= 0 && number <= 999) {
            output += "Number " + number + " in English is: ";

            // Separate hundreds/tens/units
            var hundreds = Math.floor(number / 100);
            var tens = Math.floor((number / 10) % 10);
            var units = Math.floor(number % 10);
            var translation = "";

            // Checks for zero in order obey further calculations
            if (number === 0) {
                translation += (numberNames[units]);
            } else {

                // Assigns hundreds
                if (hundreds > 0) {
                    translation += numberNames[hundreds] + " " + numberNames[25];
                    if ((tens !== 0) || (units !== 0)) {
                        translation += " and ";
                    }
                }

                // Assigns tens
                if (tens !== 0) {
                    switch (tens) {
                        case 1:
                            translation += numberNames[tens + 9 + units];
                            break;
                        case 2:
                            translation += numberNames[20];
                            break;
                        case 3:
                            translation += numberNames[21];
                            break;
                        case 4:
                            translation += numberNames[22];
                            break;
                        case 5:
                            translation += numberNames[23];
                            break;
                        case 6:
                            translation += numberNames[tens] + numberNames[26];
                            break;
                        case 7:
                            translation += numberNames[tens] + numberNames[26];
                            break;
                        case 8:
                            translation += numberNames[24];
                            break;
                        case 9:
                            translation += numberNames[tens] + numberNames[26];
                            break;
                    }
                }

                // Assigns units
                if (units !== 0) {
                    if ((tens !== 0) && (units !== 0)) {
                        translation += " ";
                    }

                    if (units !== 0 && tens !== 1) {
                        translation += numberNames[units];
                    }
                }
            }

            // Capitalize first letter as required by task
            output += translation.charAt(0).toUpperCase() + translation.slice(1);
        } else {
            output = "Invalid input detected (not an integer or out of range)!";
        }

        return output;
    };

    return runMe();
};