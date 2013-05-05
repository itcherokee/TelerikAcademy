var Console = (function () {

    function Format(args) {
        if (args.length > 1) {
            var index = 1;
            for (index = 1; index < args.length; index++)
                args[0] = args[0].replace("{" + ((0 | index) - 1) + "}", args[index]);
        }

        return args[0];
    }

    return {
        writeLine: function () {
            console.log(Format(arguments).toString());
        },

        writeError: function () {
            console.error(Format(arguments).toString());
        },

        writeWarning: function () {
            console.warn(Format(arguments).toString());
        }
    };
}());
