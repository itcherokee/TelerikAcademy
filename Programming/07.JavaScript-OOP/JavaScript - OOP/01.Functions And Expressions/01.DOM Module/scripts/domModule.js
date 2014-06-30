var domModule = (function () {

    var buffer = {},
//        bufferLimit = 100,
        parentNode,
        childNode,
        elements;

    function appendChild(element, selector) {
        parentNode = document.querySelector(selector);
        parentNode.appendChild(element);
    }

    function removeChild(parent, child) {
        parentNode = document.querySelector(parent);
        childNode = parentNode.querySelector(child);
        parentNode.removeChild(childNode);
    }

    function addHandler(elementsSelector, event, functionToExecute) {
        elements = document.querySelectorAll(elementsSelector);
        var index,
            len = elements.length;
        for (index = 0; index < len; index+=1) {
            var element = elements[index];
            element.addEventListener(event, functionToExecute);
        }
    }

    function appendToBuffer(selector, childNode) {
        var limit = 100;
        buffer[selector] = buffer[selector] || [];
//        if (!buffer[selector]) {
//            buffer[selector] = [];
//        }

        if (childNode) {
            buffer[selector].push(childNode);

            if (buffer[selector].length >= limit) {
                var fragment = document.createDocumentFragment();
                var index,
                    len = buffer[selector].length;
                for (index = 0; index < len; index+=1) {
                    var element = buffer[selector][index];
                    fragment.appendChild(element);
                }

                var container = document.querySelector(selector);
                container.appendChild(fragment);
                buffer[selector] = [];
            }
        }
    }

    function getElement(container) {
        return document.querySelector(container);
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
        getElement: getElement
    }

})();

