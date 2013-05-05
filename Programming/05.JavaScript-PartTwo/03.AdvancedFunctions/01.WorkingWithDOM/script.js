
var wrapper = (function () {

    function addElement(parent, element) {
        var parentElement = document.querySelector(selector);
        var newElement = document.createElement(element);
        parentElement.appendChild(newElement);
    }

    function removeElement(element) {
        var elementToRemove = document.querySelector(element);
        elementToRemove.parentNode.removeChild(elementToRemove);
    }

    function eventAttach(element, eventType, eventHandler) {
        document.querySelector(selector).addEventListener(eventType, eventHandler, false);
    }

    function getElements(selector) {
        return document.querySelectorAll(selector);
    }

    return {
        addElement: addElement,
        removeElement: removeElement,
        eventAttach: eventAttach,
        getElements: getElements
        }
})();

