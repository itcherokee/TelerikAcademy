function solve() {
    var module = (function () {
        var item,
            book,
            media,
            catalog,
            bookCatalog,
            mediaCatalog;

        item = (function () {
            var itemId = 0,
                item = Object.create({});

            Object.defineProperties(item, {
                init: {
                    value: function (name, description) {
                        this.description = description;
                        this.name = name;
                        this._id = ++itemId;

                        return this;
                    },
                    enumerable: true,
                    configurable: false
                },
                id: {
                    get: function () {
                        return this._id;
                    },
                    enumerable: true,
                    configurable: true
                },
                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        if (typeof(value) !== 'string' || value.length < 2 || value.length > 40) {
                            throw new Error('Invalid name provided.');
                        }

                        this._name = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                description: {
                    get: function () {
                        return this._description;
                    },
                    set: function (value) {
                        if (typeof(value) !== 'string' || value.length < 1) {
                            throw new Error('Invalid description provided.');
                        }

                        this._description = value;
                    },
                    enumerable: true,
                    configurable: true
                }
            });
            return item;
        }());

        book = (function (parent) {
            var book = Object.create(parent);
            Object.defineProperties(book, {
                init: {
                    value: function (name, isbn, genre, description) {
                        parent.init.call(this, name, description);
                        this.isbn = isbn;
                        this.genre = genre;

                        return this;
                    },
                    enumerable: true,
                    configurable: false
                },
                isbn: {
                    get: function () {
                        return this._isbn;
                    },
                    set: function (value) {
                        if (typeof (value) !== 'string' || !(/[0-9]/g.test(value))
                            || (value.length !== 10 && value.length !== 13)) {
                            throw new Error('Invalid isbn provided.');
                        }

                        this._isbn = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                genre: {
                    get: function () {
                        return this._genre;
                    },
                    set: function (value) {
                        if (typeof(value) !== 'string' || value.length < 2 || value.length > 20) {
                            throw new Error('Invalid genre provided.');
                        }

                        this._genre = value;
                    },
                    enumerable: true,
                    configurable: true
                }
            });
            return book;
        }(item));

        media = (function (parent) {
            var media = Object.create(parent);
            Object.defineProperties(media, {
                init: {
                    value: function (name, rating, duration, description) {
                        parent.init.call(this, name, description);
                        this.rating = rating;
                        this.duration = duration;


                        return this;
                    },
                    enumerable: true,
                    configurable: false
                },
                duration: {
                    get: function () {
                        return this._duration;
                    },
                    set: function (value) {
                        if (typeof(value) !== 'number' || value <= 0) {
                            throw new Error('Invalid duration provided.');
                        }

                        this._duration = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                rating: {
                    get: function () {
                        return this._rating;
                    },
                    set: function (value) {
                        if (typeof(value) !== 'number' || value < 1 || value > 5) {
                            throw new Error('Invalid rating provided.');
                        }

                        this._rating = value;
                    },
                    enumerable: true,
                    configurable: true
                }
            });
            return media;
        }(item));

        catalog = (function () {
            var catalogId = 0,
                findFilterHelper,
                catalog = Object.create({});

            findFilterHelper = function (value) {
                return function (item) {
                    var id = item.id;
                    var name = item.name.toLowerCase();
                    if (!value.id || id == value.id) {
                        if (!value.name || name == value.name.toLowerCase()) {
                            return true;
                        }
                    }
                    return false;
                };
            };

            Object.defineProperties(catalog, {
                init: {
                    value: function (name) {
                        this._id = ++catalogId;
                        this.name = name;
                        this._items = [];
                        this._findFilter = findFilterHelper;

                        return this;
                    },
                    enumerable: true,
                    configurable: false
                },
                id: {
                    get: function () {
                        return this._id;
                    }
                },
                items: {
                    get: function () {
                        return this._items;
                    },
                    set: function (value) {
                        this._items = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        if (typeof(value) !== 'string' || value.length < 2 || value.length > 40) {
                            throw new Error('Invalid name provided.');
                        }

                        this._name = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                add: {
                    value: function (values) {
                        var arrOfItems,
                            i, len;

                        if (Array.isArray(arguments[0])) {
                            arrOfItems = arguments[0];
                        } else {
                            arrOfItems = Array.prototype.slice.call(arguments);
                        }

                        if (arrOfItems.length === 0) {
                            throw new Error('ValidateArrayOfItems - Empty array or no items provided.');
                        }

                        arrOfItems.forEach(function (item) {
                            if (item === undefined || item.id === undefined
                                || item.name === undefined || item.description === undefined) {
                                throw new Error('ValidateArrayOfItems - non valid item-like object provided')
                            }
                        });

                        for (i = 0, len = arrOfItems.length; i < len; i += 1) {
                            this._items.push(arrOfItems[i]);
                        }

                        return this;
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                find: {
                    value: function (value) {
                        var i, len, foundItems = [];

                        if (typeof (value) === 'object') { //&& (value.id || value.name)) {
                            foundItems = this.items.filter(this._findFilter(value));
                            return foundItems;

                        } else if (typeof(value) === 'number') {
                            for (i = 0, len = this.items.length; i < len; i += 1) {
                                if (this.items[i].id === value) {
                                    return this.items[i];
                                }
                            }
                            return null;
                        }

                        throw new Error('find - No argument provided or invalid ones')
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                search: {
                    value: function (pattern) {
                        var result = [],
                            i, len,
                            item,
                            patternLower;

                        if (typeof(pattern) !== 'string' || pattern.length < 1) {
                            throw new Error("search - Invalid pattern");
                        }

                        patternLower = pattern.toLowerCase();
                        for (i = 0, len = this.items.length; i < len; i += 1) {
                            item = this.items[i];
                            if (item.name.toLowerCase().indexOf(patternLower) > -1 || item.description.toLowerCase().indexOf(patternLower) > -1) {
                                result.push(item);
                            }
                        }
                        return result;
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                }
            });
            return catalog;
        }());

        bookCatalog = (function (parent) {
            var bookCatalog,
                findFilterHelper;

            findFilterHelper = function (value) {
                return function (item) {
                    var id = item.id;
                    var name = item.name.toLowerCase();
                    var gen = item.genre.toLowerCase();
                    if (!value.id || id === value.id) {
                        if (!value.name || name === value.name.toLowerCase()) {
                            if (!value.genre || gen === value.genre.toLowerCase()) {
                                return true;
                            }
                        }
                    }
                    return false;
                };
            };

            bookCatalog = Object.create(parent);
            Object.defineProperties(bookCatalog, {
                init: {
                    value: function (name) {
                        parent.init.call(this, name);
                        this._findFilter = findFilterHelper;

                        return this;
                    },
                    enumerable: true,
                    configurable: false
                },
                add: {
                    value: function (values) {

                        var arrOfItems;

                        if (Array.isArray(arguments[0])) {
                            arrOfItems = arguments[0];
                        } else {
                            arrOfItems = Array.prototype.slice.call(arguments);
                        }

                        arrOfItems.forEach(function (item) {
                            if (item.isbn === undefined || item.genre === undefined) {
                                throw new Error('ValidateArrayOfItems - non valid book-like object provided')
                            }
                        });

                        parent.add.apply(this, arrOfItems);

                        return this;
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                getGenres: {
                    value: function () {

                        var uniqueGenresInLowerCase = [],
                            uniqueGenresItems = {},
                            i, j, len;

                        for (j = 0, len = this.items.length; j < len; j += 1) {
                            uniqueGenresItems[this.items[j].genre] = '';
                        }

                        uniqueGenresItems = Object.keys(uniqueGenresItems);

                        for (i = 0, len = uniqueGenresItems.length; i < len; i += 1) {
                            uniqueGenresInLowerCase.push(uniqueGenresItems[i].toLowerCase());
                        }

                        return uniqueGenresInLowerCase;
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                find: {
                    value: function (value) {
                        return parent.find.call(this, value);
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                }
            });
            return bookCatalog;
        }(catalog));

        mediaCatalog = (function (parent) {
            var mediaCatalog,
                findFilterHelper;

            findFilterHelper = function (value) {
                return function (item) {
                    var id = item.id;
                    var name = item.name.toLowerCase();
                    var ret = item.rating;
                    var dur = item.duration;
                    if (!value.id || id === value.id) {
                        if (!value.name || name === value.name.toLowerCase()) {
                            if (!value.rating || ret === value.rating) {
                                if (!value.duration || dur === value.duration) {
                                    return true;
                                }
                            }
                        }
                    }
                    return false;
                };
            };

            mediaCatalog = Object.create(parent);
            Object.defineProperties(mediaCatalog, {
                init: {
                    value: function (name) {
                        parent.init.call(this, name);
                        this._findFilter = findFilterHelper;

                        return this;
                    },
                    enumerable: true,
                    configurable: false
                },
                add: {
                    value: function (values) {
                        var arrOfItems;

                        if (Array.isArray(arguments[0])) {
                            arrOfItems = arguments[0];
                        } else {
                            arrOfItems = Array.prototype.slice.call(arguments);
                        }

                        arrOfItems.forEach(function (item) {
                            if (item.duration === undefined || item.rating === undefined) {
                                throw new Error('ValidateArrayOfItems - non valid book-like object provided')
                            }
                        });

                        parent.add.apply(this, arrOfItems);

                        return this;
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                find: {
                    value: function (value) {
                        return parent.find.call(this, value);
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                getTop: {
                    value: function (count) {
                        if (typeof(count) !== 'number' || count < 1) {
                            throw new Error();
                        }
                        return this.items.slice(0)
                            .sort(function (a, b) {
                                return a.rating - b.rating;
                            })
                            .slice(0, count)
                            .map(function (element) {
                                return {id: element.id, name: element.name}
                            });
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                getSortedByDuration: {
                    value: function () {
                        return this.items.slice(0)
                            .sort(function (a, b) {
                                if (a.duration === b.duration) {
                                    return a.id - b.id
                                }

                                return (a.duration - b.duration) * -1;
                            });
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                }

            });
            return mediaCatalog;
        }(catalog));

        return {
            getBook: function (name, isbn, genre, description) {
                return Object.create(book).init(name, isbn, genre, description);
            },
            getMedia: function (name, rating, duration, description) {
                return Object.create(media).init(name, rating, duration, description);
            },
            getBookCatalog: function (name) {
                return Object.create(bookCatalog).init(name);
            },
            getMediaCatalog: function (name) {
                return Object.create(mediaCatalog).init(name);
            }
        };
    }());

    return module;
}