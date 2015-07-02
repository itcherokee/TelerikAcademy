function solve() {
    // -------------------------- Helper functions --------------------------
    function isString(str) {
        return typeof str == "string" ||
            (typeof str == "object" && str.constructor === String);
    }

    function isEmptyObject(obj) {
        for (var prop in obj) {
            if (obj.hasOwnProperty(prop)) {
                return false;
            }
        }

        return true;
    }

    function isValidType(type) {
        return type.length &&
            isString(type) &&
            /^[A-Z\d]+$/i.test(type);
    }

    function isValidAttribute(attribute) {
        return attribute.length &&
            isString(attribute) &&
            /^[A-Z\d\-]+$/i.test(attribute);
    }

    function parseHTML() {
        var output = '<' + this.type,
            keys = [],
            index,
            key,
            len;

        if (!isEmptyObject(this.attributes)) {
            for (key in this.attributes) {
                if (this.attributes.hasOwnProperty(key)) {
                    keys.push(key);
                }
            }

            keys.sort();
            len = keys.length;
            for (index = 0; index < len; index++) {
                output += ' ' +
                    keys[index] +
                    '="' +
                    this.attributes[keys[index]] +
                    '"';
            }
        }

        output += '>';

        if (this.children.length > 0) {
            len = this.children.length;
            for (index = 0; index < len; index++) {
                if (isString(this.children[index])) {
                    output += this.children[index];
                } else {
                    output += this.children[index].innerHTML;
                }
            }
        } else if (this.content) {
            output += this.content;
        }

        output += '</' + this.type + '>';

        return output;
    }

    // **********************************************************************

    var domElement = (function() {
        var domElement = {
            // Defining properties
            get type() {
                return this._type;
            },
            set type(value) {
                this._type = value;
            },
            get content() {
                return this._content;
            },
            set content(value) {
                this._content = value;
            },
            get attributes() {
                return this._attributes;
            },
            set attributes(value) {
                this._attributes = value;
            },
            get children() {
                return this._children;
            },
            set children(value) {
                this._children = value;
            },
            get parent() {
                return this._parent;
            },
            set parent(value) {
                this._parent = value;
            },
            // Defining methods
            init: function(type) {
                if (!isValidType(type)) {
                    throw new Error('Invalid type!');
                }

                // Declaring properties
                this.type = type;
                this.parent;
                this.content;
                this.attributes = {};
                this.children = [];
                this.innerHTML;

                return this;
            },
            appendChild: function(child) {
                child.parent = this;
                this.children.push(child);

                return this;
            },
            addAttribute: function(name, value) {
                if (!isValidAttribute(name)) {
                    throw new Error('Invalid attribute!');
                }

                this.attributes[name] = value;

                return this;
            },
            removeAttribute: function(attribute) {
                if (!(isValidAttribute(attribute) && this.attributes[attribute])) {
                    throw new Error('Invalid attribute!');
                }

                delete this.attributes[attribute];

                return this;
            },
            get innerHTML() {
                return parseHTML.call(this);
            }
        };
        return domElement;
    }());
    return domElement;



    var meta = domElement.init('meta')
        .addAttribute('charset', 'utf-8');

}

module.exports = solve;