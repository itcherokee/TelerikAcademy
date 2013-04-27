
"use strict";

function randomColor() {
    return "#" + (Math.floor(Math.random() * 16777215).toString(16));
}

function initializeDiv() {
    var divElement = document.createElement("div");
    var divWidth = Math.floor(Math.random() * 80) + 20;
    var divHeight = Math.floor(Math.random() * 80) + 20;
    divElement.style.backgroundColor = randomColor();
    divElement.style.color = randomColor();
    divElement.style.position = "absolute";
    divElement.style.left = Math.floor(Math.random() * 99) + "%";
    divElement.style.top = Math.floor(Math.random() * 99) + "%";
    divElement.style.height = divHeight + "px";
    divElement.style.width = divWidth + "px";
    divElement.style.textAlign = "center";
    divElement.style.borderColor = randomColor();
    divElement.style.borderWidth = Math.floor(Math.random() * 20) + 1 + "px";
    divElement.style.borderRadius = Math.floor(Math.random() * 25) + 1 + "px";
    divElement.style.borderStyle = "solid";
    divElement.innerHTML = "<strong>div</strong>";
    return divElement;
}

function createDiv() {
    var contentDiv = document.getElementById("wrapper");

    while (contentDiv.firstChild) {
        contentDiv.removeChild(contentDiv.firstChild);
    }

    for (var index = 0; index < 5; index++) {
        document.body.appendChild(initializeDiv());
    }
}
