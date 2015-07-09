function solve() {
    var module = (function () {
        var player,
            playlist,
            playable,
            audio,
            video;

        player = (function () {
            var playerId = 0,
                player = Object.create({});
            Object.defineProperties(player, {
                init: {
                    value: function (name) {
                        this._id = ++playerId;
                        this.name = name;
                        this._playlist = [];

                        return this;
                    }
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
                        if (typeof(value) !== 'string' || value.length < 3 || value.length > 25) {
                            throw new Error('Invalid name provided.');
                        }

                        this._name = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                addPlaylist: {
                    value: function (list) {
                        if (list === undefined || list.id === undefined) {
                            throw new Error('addPLaylist - not correct playlist specified')
                        }

                        this._playlist.push(list);

                        return this;
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                getPlaylistById: {
                    value: function (id) {
                        var foundedPlaylist = this._playlist.filter(function (element) {
                            return element.id === id;
                        });

                        if (foundedPlaylist.length > 0) {
                            return foundedPlaylist[0];
                        }

                        return null;
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                removePlaylist: {
                    value: function (value) {
                        if (typeof(value) !== 'number') {
                            value = value.id;
                            if (value === undefined) {
                                throw new Error('removePlaylist - playlist without id')
                            }
                        }

                        var foundedPlaylist = this.getPlaylistById(value);
                        if (foundedPlaylist === null) {
                            throw new Error('removePlaylist - not existing playlist');
                        }

                        this._playlist.splice(this._playlist.indexOf(foundedPlaylist), 1);

                        return this;
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                listPlaylists: {
                    value: function (page, size) {
                        page = page || 0;
                        size = size || Number.MAX_NUMBER;
                        if (page * size > this._playables.length || page < 0 || size <= 0) {
                            throw new Error('listPlaylists - invalid size/page');
                        }

                        return this._playlists
                            .slice()
                            .sort(function (a, b) {
                                if (a.name === b.name) {
                                    return a.id - b.id;
                                }
                                return a.name.localeCompare(b.name);
                            })
                            .splice(page * size, size);
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
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
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                search: {
                    value: function (pattern) {
                        return;
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                }

            });

            return player;
        })();

        playlist = (function () {
            var playlistId = 0,
                playlist = Object.create({});
            Object.defineProperties(playlist, {
                init: {
                    value: function (name) {
                        this._id = ++playlistId;
                        this.name = name;
                        this._playables = [];

                        return this;
                    },
                    enumerable: true,
                    configurable: false,
                    writable: false
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
                        if (typeof(value) !== 'string' || value.length < 3 || value.length > 25) {
                            throw new Error('Invalid name provided.');
                        }

                        this._name = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                addPlayable: {
                    value: function (playable) {
                        this._playables.push(playable);
                        return this;
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                getPlayableById: {
                    value: function (id) {
                        var foundedPlayable = this._playables.filter(function (element) {
                            return element.id === id;
                        });

                        if (foundedPlayable.length > 0) {
                            return foundedPlayable[0];
                        }

                        return null;
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                removePlayable: {
                    value: function (value) {
                        if (typeof(value) !== 'number') {
                            value = value.id;
                            if (value === undefined) {
                                throw new Error('removePlayable - object without id')
                            }
                        }

                        var foundedPlayable = this.getPlayableById(value);
                        if (foundedPlayable === null) {
                            throw new Error('removePlayble - not existing playable');
                        }

                        this._playables.splice(this._playables.indexOf(foundedPlayable), 1);

                        return this;
                    },
                    enumerable: true,
                    configurable: true,
                    writable: false
                },
                listPlayables: {
                    value: function (page, size) {
                        page = page || 0;
                        size = size || Number.MAX_NUMBER;
                        if (page * size > this._playables.length || page < 0 || size <= 0) {
                            throw new Error('listPlayables - invalid size/page');
                        }

                        return this
                            ._playables
                            .slice()
                            .sort(function (a, b) {
                                if (a.title === b.title) {
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
            var playableId = 0,
                playable = Object.create({});

            Object.defineProperties(playable, {
                init: {
                    value: function (title, author) {
                        this._id = ++playableId;
                        this.title = title;
                        this.author = author;

                        return this;
                    },
                    enumerable: true,
                    configurable: false,
                    writable: false
                },
                id: {
                    get: function () {
                        return this._id;
                    },
                    enumerable: true,
                    configurable: false
                },
                title: {
                    get: function () {
                        return this._title;
                    },
                    set: function (value) {
                        if (typeof(value) !== 'string' || value.length < 3 || value.length > 25) {
                            throw new Error('Invalid title provided.');
                        }

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
                        if (typeof(value) !== 'string' || value.length < 3 || value.length > 25) {
                            throw new Error('Invalid author provided.');
                        }

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
                    configurable: true,
                    writable: false
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
                    },
                    enumerable: true,
                    configurable: false,
                    writable: false

                },
                length: {
                    get: function () {
                        return this._length;
                    },
                    set: function (value) {
                        if (typeof(value) !== 'number' || value <= 0) {
                            throw new Error('Invalid length provided.');
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
                    configurable: true,
                    writable: false
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
                }, imdbRating: {
                    get: function () {
                        return this._imdbRating;
                    },
                    set: function (value) {
                        if (typeof(value) !== 'number' || value < 1 || value > 5) {
                            throw new Error('Invalid imdbRating provided.');
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
                    configurable: true,
                    writable: false
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

