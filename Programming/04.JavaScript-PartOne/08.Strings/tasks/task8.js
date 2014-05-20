// Task 8:  Write a JavaScript function that replaces in a HTML document 
//          given as string all the tags <a href="…">…</a> with corresponding 
//          tags [URL=…]…/URL]. 

var taskEight = function () {
    "use strict";
    var brake = "<br />";

    String.prototype.htmlEscape = function () {
        var escapedStr = String(this).replace(/&/g, '&amp;');
        escapedStr = escapedStr.replace(/</g, '&lt;');
        escapedStr = escapedStr.replace(/>/g, '&gt;');
        escapedStr = escapedStr.replace(/"/g, '&quot;');
        escapedStr = escapedStr.replace(/'/g, "&#39");
        return escapedStr;
    };
    
    function replaceAnchorTags(source) {
        var startIndex = 0,
            endIndex = 0,
            closingIndex = 0,
            position = 0,
            target = "";
        while (true) {
            startIndex = source.indexOf("<a href=", position);
            if (startIndex < 0) {
                break;
            }
            
            // copy the text from last <a> closing to newly found into new string (target)
            target += source.slice(position, startIndex) + "[URL=";
            position = startIndex + 8;
            endIndex = source.indexOf(">", startIndex);
            closingIndex = source.indexOf("</a>", position);
            
            // copy the web address from current <a> and text between opening and closing <a> tags into new string (target)
            target += source.slice(position++, endIndex) + "]" + source.slice(endIndex + 1, closingIndex) + "[/URL]";
            position = closingIndex + 4;
        }
        
        // if we did not reach the end of the source string, copy the rest of text (after last <a> tag) into new string (target)
        if (position < source.length) {
            target += source.slice(position, source.length);
        }
        
        return target;
    }

    

    var runMe = function () {
        var output = "Initial data has been hardcoded in order to simplify your task:" + brake + brake,
            text = '<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';
        output += "Original text: " + brake + text.htmlEscape() + brake + brake;
        output += "Changed text: " + brake + replaceAnchorTags(text) + brake;

        return output;
    };

    return runMe();
};