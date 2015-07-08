function solve() {
    var module = (function () {
        var validators,
            player,
            playlist,
            playable,
            audio,
            video
            ;

        validators = {
            validateParameter: function (value) {
                if (value === null || value === undefined) {
                    throw new Error("Invalid parameter.")
                }
            },
            validateInteger: function (value) {
                validators.validateParameter(value);
                if (isNaN(value) || (value | 0) !== value) {
                    throw new Error('Not an Integer');
                }
            },
            validateId: function (id) {
                validators.validateParameter(id);
                validators.validateInteger(id);
                if (id <= 0) {
                    throw new Error('Id is not valid');
                }
            },
            validateString: function (value) {
                validators.validateParameter(value);
                if (typeof(value) !== 'string' || (value.length < 3 || value > 25)) {
                    throw new Error('Invalid string')
                }
            }
        };

        player = (function () {
            var player = Object.create({});
            Object.defineProperties(player, {
                init: {
                    value: function (name) {
                        this.name = name;

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
                        return;
                    },
                    enumerable: true
                },
                getPlaylistById: {
                    value: function (id) {
                        return;
                    },
                    enumerable: true
                },
                removePlaylist: { // id & playlist
                    value: function (value) {
                        return;
                    },
                    enumerable: true
                },
                listPlaylists: {
                    value: function (page, size) {
                        return;
                    },
                    enumerable: true
                },
                contains: {
                    value: function (playable, playlist) {
                        return;
                    },
                    enumerable: true
                },
                search: {
                    value: function (pattern) {
                        return;
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
                        this._id = ++generatedId;
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
                        validators.validateString(value);

                        this._name = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                addPlayable: {
                    value: function (value) {
                        if (!(playable.isPrototypeOf(value))) {
                            throw new Error('Not a valid playable provided.');
                        }

                        this._playlist.push(value);

                        return this;
                    },
                    enumerable: true
                },
                getPlayableById: {
                    value: function (id) {
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
                        var foundedPlayable,
                            foundedPlayableIndex,
                            playableId;

                        validators.validateParameter(value);
                        if (playable.isPrototypeOf(value)) { // playable
                            playableId = value.id;
                        } else {
                            playableId = value;
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
                        return;
                    },
                    enumerable: true
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
                        this._id = ++generatedId;
                        this.title = title;
                        this.author = author;

                        return this;
                    }
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
                    enumerable: true
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
                        validators.validateInteger(value);
                        if (value < 0) {
                            throw new Error('Invalid length');
                        }

                        this._length = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                play: {
                    value: function () {
                        return parent.toString.call(this) + ' - ' + this.length;
                    },
                    enumerable: true
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
                        validators.validateInteger(value);
                        if (value < 1 || value > 5) {
                            throw new Error('Invalid imdbRating');
                        }

                        this._imdbRating = value;
                    },
                    enumerable: true,
                    configurable: true
                },
                play: {
                    value: function () {
                        return parent.toString.call(this) + ' - ' + this.imdbRating;
                    },
                    enumerable: true
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

    //return module;

    // ----------------------------------------

    var playlist = module.getPlaylist('pepo');
    var audio = module.getAudio('audio','author', 1);
    playlist.addPlayable(audio);


    console.log(playlist.getPlayableById(1));
    playlist.removePlayable(audio);
    console.log(playlist.getPlayableById(1));

}

solve();
//module.exports = solve;

