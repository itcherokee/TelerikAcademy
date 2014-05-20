// Task 3:  Refactor the following examples to produce code with 
//          well-named identifiers in JavaScript.

function onButtonClick(event) {
    var currentWindow = window;
    var browserName = currentWindow.navigator.appCodeName;
    var isMozilla = (browserName === "Mozilla");
    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}
