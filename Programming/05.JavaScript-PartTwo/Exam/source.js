var controls = (function () {
    //var initialPicture;
    //var isInitialPictureSet = false;

    function zoomPic(source) {
        var zoomedPictureHolder = document.getElementById("zoomed-picture");
        zoomedPictureHolder.innerHTML = '<img src="' + source.src + '" height="' + source.height * 2 + '" width="' + source.width * 2 + '"/>';
    }

    //function EventHandler(ev) {
    //    if (!ev) {
    //        ev = window.event;
    //    }

    //    ev.stopPropagation();
    //    ev.preventDefault();
    //    var clickedElement = ev.target;

    //    if (clickedElement.nodeName === "IMG") {
    //        zoomPic(clickedElement);
    //    }

    //    var listToShowOrHide = clickedElement.nextElementSibling;
    //    if (!listToShowOrHide) {
    //        return;
    //    }

    //    if (listToShowOrHide.style.display === "none") {
    //        listToShowOrHide.style.display = "";
    //    }
    //    else {
    //        listToShowOrHide.style.display = "none";
    //    }
    //};


    function ImageGallery(selector) {
        var items = [];
        var gallery = document.querySelector(selector);

        var itemsList = document.createElement("div");

        //function attachEventHandler(element, eventType, eventHandler) {
        //    if (!element) {
        //        return;
        //    }

        //    if (document.addEventListener) {
        //        element.addEventListener(eventType, eventHandler, false);
        //    }
        //    else if (document.attachEvent) {
        //        element.attachEvent("on" + eventType, eventHandler);
        //    }
        //    else {
        //        element['on' + eventType] = eventHandler;
        //    }
        //}
        

        gallery.addEventListener("click", function (ev) {
            if (!ev) {
                ev = window.event;
            }

            ev.stopPropagation();
            ev.preventDefault();
            var clickedElement = ev.target;

            if (clickedElement.nodeName === "IMG") {
                zoomPic(clickedElement);
            }

            var listToShowOrHide = clickedElement.nextElementSibling;
            if (!listToShowOrHide) {
                return;
            }

            if (listToShowOrHide.style.display === "none") {
                listToShowOrHide.style.display = "";
            }
            else {
                listToShowOrHide.style.display = "none";
            }
        }, false);

        this.addImage = function (title, path) {
            var newImage = new Image(title, path);
            items.push(newImage);
            initialPicture = newImage;
            return newImage;
        };

        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            items.push(newAlbum);
            return newAlbum;
        };

        this.render = function () {
            for (var i = 0; i < items.length; i += 1) {
                var dom = items[i].render();
                if (dom instanceof Image) {
                    itemList.insertBefore(dom, itemsList.firstChild);
                }
                else {
                    itemsList.appendChild(dom);
                }
            }

            gallery.appendChild(itemsList);
            return this;
        };
    }

    function Image(title, path) {
        var items = [];

        this.addImage = function (title, path) {
            var newImage = new Image(title, path);
            items.push(newImage);
            return newImage;
        };

        this.render = function () {
            var imageNode = document.createElement("div");
            imageNode.innerHTML = "<a href='#' >" + title + "</a>" + "<BR/>";
            imageNode.style.display = "inline-block";
            imageNode.style.border = "1px solid black";
            var picNode = document.createElement("img");
            picNode.src = path;
            picNode.alt = title;
            imageNode.appendChild(picNode);
            return imageNode;
        };
    }

    function Album(title) {
        var items = [];

        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            items.push(newAlbum);
            return newAlbum;
        };

        this.addImage = function (title, path) {
            var newImage = new Image(title, path);
            items.push(newImage);
            return newImage;
        };

        this.render = function () {
            var albumNode = document.createElement("div");
            albumNode.innerHTML = "<a href='#' >" + title + "</a>"; + "<BR/>";
            albumNode.style.display = "block";
            albumNode.style.border = "1px solid black";
            if (items.length > 0) {
                var sublist = document.createElement("div");
                sublist.style.display = "none";
                for (var i = 0, len = items.length; i < len; i += 1) {
                    var subitem = items[i].render();
                    sublist.appendChild(subitem);
                }

                albumNode.appendChild(sublist);
            };

            return albumNode;
        };
    }

    return {
        getImageGallery: function (selector) {
            return new ImageGallery(selector);
        }
    }
}());
