// Format correctly the following source code
//
// The code that is needless (not used by other parts of code) is put in comment lines (not deleted), except the functions which may be called by other script

"use strict";

var browserName = navigator.appName;
var addScroll = false;

if ((navigator.userAgent.indexOf("MSIE 5") > 0) || (navigator.userAgent.indexOf("MSIE 6")) > 0) {
    addScroll = true;
}

// var off = 0;
// var txt = "";
var pointX = 0;
var pointY = 0;
document.onmousemove = mouseMove;

if (browserName === "Netscape") {
    document.captureEvents(Event.MOUSEMOVE);
}

function mouseMove(evn) {
    if (browserName === "Netscape") {
        pointX = evn.pageX - 5;
        pointY = evn.pageY;
        if (document.layers.ToolTip.visibility === "show") {
            popTip();
        }
    }
    else {
        pointX = event.x - 5;
        pointY = event.y;
        if (document.all.ToolTip.style.visibility === "visible") {
            popTip();
        }
    }
}

var theLayer;

function popTip() {
    if (browserName === "Netscape") {
        theLayer = eval("document.layers[\"ToolTip\"]");
        if ((pointX + 120) > window.innerWidth) {
            pointX = window.innerWidth - 150;
        }

        theLayer.left = pointX + 10;
        theLayer.top = pointY + 15;
        theLayer.visibility = "show";
    }
    else {
        theLayer = eval("document.all[\"ToolTip\"]");
        if (theLayer) {
            pointX = event.x - 5;
            pointY = event.y;

            if (addScroll) {
                pointX += document.body.scrollLeft;
                pointY += document.body.scrollTop;
            }

            if ((pointX + 120) > document.body.clientWidth) {
                pointX = pointX - 150;
            }

            theLayer.style.pixelLeft = pointX + 10;
            theLayer.style.pixelTop = pointY + 15;
            theLayer.style.visibility = "visible";
        }
    }
}

function hideTip() {
    // var args = hideTip.arguments;
    if (browserName === "Netscape") { document.layers.ToolTip.visibility = "hide"; }
    else {
        document.all.ToolTip.style.visibility = "hidden";
    }
}

function hideMenu1() {
    if (browserName === "Netscape") {
        document.layers.menu1.visibility = "hide";
    }
    else {
        document.all.menu1.style.visibility = "hidden";
    }
}

function showMenu1() {
    if (browserName === "Netscape") {
        theLayer = eval("document.layers[\"menu1\"]");
        theLayer.visibility = "show";
    }
    else {
        theLayer = eval("document.all[\"menu1\"]");
        theLayer.style.visibility = "visible";
    }
}

function hideMenu2() {
    if (browserName === "Netscape") {
        document.layers.menu2.visibility = "hide";
    }
    else {
        document.all.menu2.style.visibility = "hidden";
    }
}

function showMenu2() {
    if (browserName === "Netscape") {
        theLayer = eval("document.layers[\"menu2\"]");
        theLayer.visibility = "show";
    }
    else {
        theLayer = eval("document.all[\"menu2\"]");
        theLayer.style.visibility = "visible";
    }
}