
var domWorker = (function () {
    var elArray = [];
    var nodesArray = [];
    var countBuff = 0;

    function addElement(parent, element) {
        var parentElement = document.querySelector(selector);
        var newElement = document.createElement(element);
        parentElement.appendChild(newElement);
    }

    function removeElement(element) {
        var elementToRemove = document.querySelector(element);
        elementToRemove.parentNode.removeChild(elementToRemove);
    }

    function eventAttach(selector, eventType, eventHandler) {
        document.querySelector(selector).addEventListener(eventType, eventHandler, false);
    }

    //eventAttach("p", 'click', function () {
    //    alert('Clicked');
    //})



    function appendToBuffer(selector, element, count, text) {
        elArray.push(document.querySelector(selector));

        for (var c = countBuff; c < count + countBuff; c++) {
            nodesArray.push(document.createElement(element));
            nodesArray[c].innerHTML = text;
        }

        countBuff += count;

        if (countBuff >= 100) {
            for (var i = 0; i < elArray.length; i++) {
                for (var c = 0; c < nodesArray.length; c++) {
                    elArray[i].appendChild(nodesArray[c]);
                }
            }
        }
    }
    //appendToBuffer("div", "p", 10, "This 10 p buffer");
    //appendToBuffer("div", "p", 90, "This 90 p buffer");

    return {
        appendToBuffer: appendToBuffer,
        addElementToPerrent: addElementToPerrent,
        removeElement: removeElement,
        eventAttach: eventAttach,
        getElement: function (selector) {
            return document.querySelector(selector);
        },
        getElements: function (selector) {
            return document.querySelectorAll(selector);
        }
    };
})();

domWorker.addElementToPerrent("div", "p", "This is new !");
domWorker.eventAttach("p", 'click', function () {
    alert('Clicked');
})
domWorker.appendToBuffer("div", "p", 10, "This 10 p buffer");
domWorker.appendToBuffer("div", "p", 90, "This 90 p buffer");