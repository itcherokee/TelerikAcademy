function solve() {
    var module = (function () {
        var validators,
            player,
            playlist,
            playable,
            audio,
            video;

        validators = {
            validateParameter: function (value) {
                if ( value === undefined) {
                    throw new Error('Invalid Parameter')
                }
            }, validateNumber: function (value) {
               // validators.validateParameter(value);
                if (typeof (value) !== 'number') {
                    throw new Error('Not a Number');
                }
            },
            validateInteger: function (value) {
               // validators.validateParameter(value);
                if (isNaN(value) || (value | 0) !== value) {
                    throw new Error('Not an Integer');
                }
            },
            validateId: function (id) {
                //validators.validateParameter(id);
               // validators.validateNumber(id);
                if (id <= 0) {
                    throw new Error('Id is not valid');
                }
            },
            validateString: function (value) {
                //validators.validateParameter(value);
                if (typeof(value) !== 'string' || value.length < 3 || value.length > 25) {
                    throw new Error('Invalid string')
                }
            }
        };

        player = (function () {
            var player = Object.create({}),
                generatedId = 0;

            Object.defineProperties(player, {
                init: {
                    value: function (name) {
                        this.name = name;
                        this.id = ++generatedId;
                        this._playlists = [];

                        return this;
                    }
                },
                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        validators.validateString(value);

                        this._name = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                addPlaylist: {
                    value: function (playlistToAdd) {
                      //  validators.validateParameter(playlistToAdd);
                        if (playlistToAdd.id && playlistToAdd.name) {
                            playlistToAdd.id = +playlistToAdd.id;
                            this._playlists.push(playlistToAdd);
                        } else {
                            throw new Error('Invalid playlist provided');
                        }

                        return this;
                    },
                    enumerable: true
                },
                getPlaylistById: {
                    value: function (id) {
                        id =+id;
                        validators.validateId(id);
                        var foundedPlaylist = this._playlists.filter(function (playlist) {
                            return playlist.id === id;
                        });

                        if (foundedPlaylist.length > 0) {
                            return foundedPlaylist[0];
                        }

                        return null;
                    },
                    enumerable: true
                },
                removePlaylist: { // id & playlist
                    value: function (value) {
                        var foundedPlaylist,
                            playlistId;

                      //  validators.validateParameter(value);
                        if (value.id && value.name && typeof(value.id) === 'number') {
                            playlistId = +value.id;
                        } else if (typeof(value) === 'number') {
                            playlistId = +value;
                        } else {
                            throw new Error('Invalid playlist provided');
                        }

                        validators.validateId(playlistId);
                        foundedPlaylist = this.getPlaylistById(playlistId);
                        if (foundedPlaylist === null) {
                            throw new Error('Non existing playlist.')
                        }

                        this._playlists.splice(this._playlists.indexOf(foundedPlaylist), 1);

                        return this;
                    },
                    enumerable: true
                },
                listPlaylists: {
                    value: function (page, size) {
                        validators.validateInteger(page);
                        validators.validateInteger(size);

                        if (page * size > this._playlists.length || page < 0 || size <= 0) {
                            throw new Error('Invalid parameters provided.');
                        }

                        return this._playlists.slice(0)
                            .sort(function (a, b) {
                                if (a.name < b.name) {
                                    return -1
                                } else if (a.name > b.name) {
                                    return 1
                                }

                                if (a.id < b.id) {
                                    return -1
                                } else if (a.id > b.id) {
                                    return 1
                                }

                                return 0;
                            })
                            .splice(page * size, size);
                    },
                    enumerable: true
                },
                contains: {
                    value: function (playableObj, playlistObj) {
                        var foundedPlaylist = [],
                            foundPlayable;
                        if (playableObj.id && playableObj.author && playableObj.title && playlistObj.id && playlistObj.name) {
                            foundedPlaylist = this._playlists.filter(function (playlist) {
                                return playlist.id === playlistObj.id;
                            });
                            if (foundedPlaylist.length === 0) {
                                throw new Error('contains - No playlist found');
                            }

                            foundPlayable = foundedPlaylist[0].listPlaylables(0, Number.MAX_VALUE)
                                .getPlayableById(playableObj.id);

                            return foundPlayable !== null;
                        }

                        throw new Error('contains - Invalid playable or playlist provided');
                    },
                    enumerable: true
                },
                search: {
                    value: function (pattern) {
                        return [];
                    },
                    enumerable: true
                }
            });
            return player;
        })();

        playlist = (function () {
            var playlist = Object.create({}),
                generatedId = 0;

            Object.defineProperties(playlist, {
                init: {
                    value: function (name) {
                        this.id = ++generatedId;
                        this.name = name;
                        this._playlist = [];

                        return this;
                    }
                },
                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        validators.validateString(value);

                        this._name = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                addPlayable: {
                    value: function (value) {
                        validators.validateParameter(value);
                        if (value.id === undefined) {
                            throw new Error('Not a playable Object.');
                        }

                        value.id = +value.id;
                        validators.validateId(value.id);

                        this._playlist.push(value);

                        return this;
                    },
                    enumerable: true
                },
                getPlayableById: {
                    value: function (id) {
                        id = +id;
                        validators.validateId(id);
                        var foundedPlayable = this._playlist.filter(function (playable) {
                            return playable.id === id;
                        });

                        if (foundedPlayable.length > 0) {
                            return foundedPlayable[0];
                        } else {
                            return null;
                        }
                    },
                    enumerable: true
                },
                removePlayable: { // id & playable
                    value: function (value) {
                        //function validateId (id) {
                        //    this.validateIfUndefined(id, 'Object id');
                        //    if (typeof id !== 'number') {
                        //        id = id.id;
                        //    }
                        //
                        //    this.validateIfUndefined(id, 'Object must have id');
                        //    return id;
                        //}
                        //
                        //function indexOfElementWithIdInCollection(collection, id) {
                        //    var i, len;
                        //    for (i = 0, len = collection.length; i < len; i++) {
                        //        if (collection[i].id == id) {
                        //            return i;
                        //        }
                        //    }
                        //
                        //    return -1;
                        //}
                        //
                        ////Removes a playable from this playlist, and the playable must have an id equal to the provided id
                        ////Enables chaining
                        ////Throws an error, if a playable with the provided id is not contained in the playlist
                        //
                        //id = validateId(id);
                        //
                        //var foundIndex = indexOfElementWithIdInCollection(this._playables, id);
                        //if (foundIndex < 0) {
                        //    throw new Error('Playable with id ' + id + ' was not found in playlist');
                        //}
                        //
                        //this._playables.splice(foundIndex, 1);


                        var foundedPlayable,
                            playableId;
                    //
                        validators.validateParameter(value);
                        if (value.id && value.author && value.title) {
                            playableId = +value.id;
                        } else if (typeof(value) === 'number'){
                            playableId = +value;
                        }

                        validators.validateId(playableId);
                        foundedPlayable = this.getPlayableById(playableId);
                        if (foundedPlayable === null) {
                            throw new Error('Non existing playable.')
                        }

                        this._playlist.splice(this._playlist.indexOf(foundedPlayable), 1);

                        return this;
                    },
                    enumerable: true
                },
                listPlaylables: {
                    value: function (page, size) {
                        page = page || 0;
                        size = size || Number.MAX_NUMBER;
                        if (page*size > this._playables.length || page < 0 || size <= 0){
                            throw new Error('listPlayables - invalid size/page');
                        }

                        return this
                            ._playables
                            .slice()
                            .sort(function (a,b) {
                                if (a.title === b.title){
                                    return a.id - b.id;
                                }
                                return a.title.localeCompare(b.title);
                            })
                            .splice(page * size, size);
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                }
            });
            return playlist;
        })();

        playable = (function () {
            var playable = Object.create({}),
                generatedId = 0;

            Object.defineProperties(playable, {
                init: {
                    value: function (title, author) {
                        this.id = ++generatedId;
                        this.title = title;
                        this.author = author;

                        return this;
                    }
                },
                title: {
                    get: function () {
                        return this._title;
                    },
                    set: function (value) {
                        validators.validateString(value);

                        this._title = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                author: {
                    get: function () {
                        return this._author;
                    },
                    set: function (value) {
                        validators.validateString(value);

                        this._author = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                play: {
                    value: function () {
                        return this.id + '. ' + this.title + ' - ' + this.author;
                    },
                    enumerable: true,
                    configurable: true
                }
            });
            return playable;
        })();

        audio = (function (parent) {
            var audio = Object.create(parent);
            Object.defineProperties(audio, {
                init: {
                    value: function (title, author, length) {
                        parent.init.call(this, title, author);
                        this.length = length;

                        return this;
                    }
                },
                length: {
                    get: function () {
                        return this._length;
                    },
                    set: function (value) {
                        if (typeof (value) !== 'number' || value <= 0) {
                            throw new Error('Invalid length');
                        }

                        this._length = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                play: {
                    value: function () {
                        return parent.play.call(this) + ' - ' + this.length;
                    },
                    enumerable: true,
                    configurable: true
                }
            });
            return audio;
        })(playable);

        video = (function (parent) {
            var video = Object.create(parent);
            Object.defineProperties(video, {
                init: {
                    value: function (title, author, imdbRating) {
                        parent.init.call(this, title, author);
                        this.imdbRating = imdbRating;

                        return this;
                    }
                },
                imdbRating: {
                    get: function () {
                        return this._imdbRating;
                    },
                    set: function (value) {
                        if (typeof(value) !== 'number' || value < 1 || value > 5) {
                            throw new Error('Invalid imdbRating');
                        }

                        this._imdbRating = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                play: {
                    value: function () {
                        return parent.play.call(this) + ' - ' + this.imdbRating;
                    },
                    enumerable: true,
                    configurable: true
                }
            });
            return video;
        })(playable);

        return {
            getPlayer: function (name) {
                return Object.create(player).init(name);
            },
            getPlaylist: function (name) {
                return Object.create(playlist).init(name);
            },
            getAudio: function (title, author, length) {
                return Object.create(audio).init(title, author, length);
            },
            getVideo: function (title, author, imdbRating) {
                return Object.create(video).init(title, author, imdbRating);
            }
        }
    })();

    return module;
}

//module.exports = solve;

