/* Task Description */
/*
 * Create an object domElement, that has the following properties and methods:
 * use prototypal inheritance, without function constructors
 * method init() that gets the domElement type
 * i.e. `Object.create(domElement).init('div')`
 * property type that is the type of the domElement
 * a valid type is any non-empty string that contains only Latin letters and digits
 * property innerHTML of type string
 * gets the domElement, parsed as valid HTML
 * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
 * property content of type string
 * sets the content of the element
 * works only if there are no children
 * property attributes
 * each attribute has name and value
 * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
 * property children
 * each child is a domElement or a string
 * property parent
 * parent is a domElement
 * method appendChild(domElement / string)
 * appends to the end of children list
 * method addAttribute(name, value)
 * throw Error if type is not valid
 * // method removeAttribute(attribute)
 */


/* Example

 var meta = Object.create(domElement)
 .init('meta')
 .addAttribute('charset', 'utf-8');

 var head = Object.create(domElement)
 .init('head')
 .appendChild(meta)

 var div = Object.create(domElement)
 .init('div')
 .addAttribute('style', 'font-size: 42px');

 div.content = 'Hello, world!';

 var body = Object.create(domElement)
 .init('body')
 .appendChild(div)
 .addAttribute('id', 'cuki')
 .addAttribute('bgcolor', '#012345');

 var root = Object.create(domElement)
 .init('html')
 .appendChild(head)
 .appendChild(body);

 console.log(root.innerHTML);
 Outputs:
 <html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
 */


function solve() {
    var domElement = (function () {
        var TYPE_NAME_REGEX = /^[a-zA-Z]+[a-zA-Z0-9]*$/g,
            ATTR_NAME_REGEX = /^[a-zA-Z]+[a-zA-Z0-9\-]*[a-zA-Z0-9]*$/g;

        function isValidParameter(parameter) {
            return this[parameter] === null || typeof(this[parameter]) === 'undefined';
        }

        function isValidString(parameter, regExPattern) {
            return typeof (parameter) === 'string' && parameter.match(regExPattern);
        }

        function isDomElement(parameter) {
            return typeof(parameter) === 'object' && 'appendChild' in parameter;
        }

        function searchForAttribute(name) {
            var foundAttribute = this.attributes.filter(function (element) {
                if (element.name === name) {
                    return true;
                }

                return foundAttribute[0] || null
            });
        }

        function printHtml() {
            var i, len, attr = '', output = '';

            if (this.attributes.length > 0) {
                this.attributes.sort(function (a, b) {
                    if (a.name > b.name) {
                        return 1;
                    }
                    if (a.name < b.name) {
                        return -1;
                    }
                    return 0;
                });
                for (i = 0, len = this.attributes.length; i < len; i += 1) {
                    attr += this.attributes[i].name + '="' + this.attributes[i].value + '"';
                    if (i < len - 1) {
                        attr += ' ';
                    }
                }
            }

            if (this.children.length === 0) {
                output = '<' + this.type + (attr !== '' ? ' ' + attr : '') + '>'
                    + (this.content !== undefined ? this.content : '') + '</' + this.type + '>';
            } else {
                output += '<' + this.type + (attr !== '' ? ' ' + attr : '') + '>';
                for (i = 0, len = this.children.length; i < len; i += 1) {
                    if (typeof (this.children[i]) === 'string') {
                        output += this.children[i];
                    } else {
                        output += this.children[i].innerHTML;
                    }
                }

                output += '</' + this.type + '>';
            }

            return output;
        }

        function removeAttribute(attribute) {
            var elementIndex = -1;
            if (this.attributes.length > 0) {
                this.attributes.filter(function (element, index) {
                    if (element.name === attribute) {
                        elementIndex = index;
                    }
                });

                if (elementIndex > -1) {
                    this.attributes.splice(elementIndex, 1);
                } else {
                    throw new Error('Attribute not found');
                }
            } else {
                throw new Error('No any attributes specified for the current Element');
            }
        }

        var domElement = {
            init: function (type) {
                this.type = type;
                this._attributes = [];
                this._children = [];
                return this;
            },
            appendChild: function (child) {
                this.children = child;
                return this;
            },
            addAttribute: function (name, value) {
                this.attributes = {name: name, value: value};
                return this;
            },
            removeAttribute: function (attribute) {
                removeAttribute.call(this, attribute);
                return this;
            },
            innerHTML: function() {
                return printHtml.call(this);
            }
        };

        Object.defineProperties(domElement, {
            type: {
                get: function () {
                    return this._type;
                },
                set: function (value) {
                    if (!isValidParameter(value) || !isValidString(value, TYPE_NAME_REGEX)) {
                        throw new Error('Invalid DOM Type element specified.')
                    }

                    this._type = value;
                },
                configurable: false,
                enumerable: false
            },
            content: {
                get: function () {
                    return this._content;
                },
                set: function (value) {
                    if (!isValidParameter(value) || typeof (value) !== 'string') {
                        throw new Error('Invalid value for content specified.');
                    } else if (this._children && this.children.length === 0) {
                        this._content = value;
                    }
                },
                configurable: false,
                enumerable: false
            },
            attributes: {
                get: function () {
                    return this._attributes;
                },
                set: function (attribute) {
                    var existingAttribute;

                    if (!isValidParameter(attribute.name) || !isValidParameter(attribute.value)
                        || !isValidString(value, ATTR_NAME_REGEX)) {
                        throw new Error('Invalid name/value for attribute has been specified.')
                    }

                    existingAttribute = searchForAttribute.call(this, attribute);
                    if (existingAttribute !== null) {
                        existingAttribute.value = attribute.value;
                    } else {
                        this._attributes.push(attribute);
                    }
                },
                configurable: false,
                enumerable: false
            },
            children: {
                get: function () {
                    return this._children;
                },
                set: function (child) {
                    if (isValidParameter(child)) {
                        if (isDomElement(child) || typeof(child) === 'string') {
                            child.parent = this;
                            this._children.push(child);
                        } else {
                            throw new Error('Invalid child element has been provided.');
                        }
                    } else {
                        throw new Error('Not a valid domElement provided as a child of current one.');
                    }
                },
                configurable: false,
                enumerable: false
            },
            parent: {
                get: function () {
                    return this._parent;
                },
                set: function (element) {
                    if (isDomElement(element)) {
                        this._parent = element;
                    } else {
                        throw new Error('Invalid parent specified for a current element.');
                    }
                },
                configurable: false,
                enumerable: false
            }
        });

        return domElement;
    }());

    return domElement;
}

module.exports = solve;
