// Task 3:  _ClickON_TheButton in JavaScript.
//          Refactor the following examples to produce code with well-named identifiers in JavaScript.

function onButtonClick(event, args) {
    var currentWindow = window,
        browserName = currentWindow.navigator.appCodeName,
        isMozilla = (browserName === "Mozilla");

    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}
