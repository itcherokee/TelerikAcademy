var extendedConsole = (function () {

    String.prototype.formatString = stringFormat;

    function replaceAtPlaceholder(input, searchFor, replaceWith) {
        var pattern = new RegExp(searchFor, 'g');
        input = input.replace(pattern, replaceWith);
        return input;
    }

    function stringFormat(format) {
        var output = '';
        if (format.length) {
            output = format[0];
            if (format.length <= 1) {
                return output;
            }

            for (var placeIndex = 1; placeIndex < format.length; placeIndex++) {
                output = replaceAtPlaceholder(output, '\\{'
                    + (placeIndex - 1) + '\\}', format[placeIndex]);
            }
        }

        return output;
    }

    function writeLine(msg) {
        console.log(String().formatString(arguments));
    }

    function writeError(msg) {
        console.error(String().formatString(arguments));
    }

    function writeWarning(msg) {
        console.warn(String().formatString(arguments));
    }

    return {
        writeLine: writeLine,
        writeWarning: writeWarning,
        writeError: writeError
    }
})();





