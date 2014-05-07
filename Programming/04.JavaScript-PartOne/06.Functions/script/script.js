(function () {
    "use strict";
    var tasks = document.getElementsByName('tasks');
    var buttons = document.getElementsByTagName('button');
    var spans = document.getElementsByTagName('span');

    // Hides all tasks summaries
    function hideSummary() {
        var index, last;
        for (index = 0, last = spans.length; index < last; index++) {
            spans[index].style.display = "none";
        }
    }
	
    // Event handler for Radio buttons - shows currently selected task summary
    function attachRadioHandler(i) {
        var currentSpan = spans[i];
        function handler() {
            hideSummary();
			jsConsole.clean();
            selectedTask =
            currentSpan.style.display = "inline";
        }

        return handler;
    }

    var selectedTask = "";

    // Identify currently selected task
    function currentTask() {
        var index;
        var last;
        var currentTaskIndex = -1;
        for (index = 0, last = tasks.length; index < last; index++) {
            if (tasks[index].checked) {
                currentTaskIndex = index;
                break;
            }
        }

        return currentTaskIndex;
    }

    // Event handler for Show JavaScript button - select currently selected task and opens new window with code
    function attachViewButtonHandler() {
        var taskFile = "";
        taskFile = "tasks/task" + (currentTask() + 1) + ".js";
        window.open(taskFile, "", 'left=100, top=100, width=700, height=600, menubar=no, status=no, channelmode=no');
    }

    // Run button handler - used to output to jsConsole the result
    function attachRunButtonHandler() {
        switch (currentTask()) {
            case 0:
                jsConsole.writeLine(taskOne());
                break;
            case 1:
                jsConsole.writeLine(taskTwo());
                break;
            case 2:
                jsConsole.writeLine(taskThree());
                break;
            case 3:
                jsConsole.writeLine(taskFour());
                break;
            case 4:
                jsConsole.writeLine(taskFive());
                break;
            case 5:
                jsConsole.writeLine(taskSix());
                break;
            case 6:
                jsConsole.writeLine(taskSeven());
                break;
            default:
        }
    }

    // Attach events to each radio button and two normal buttons
    for (var indx = 0, len = tasks.length; indx < len; indx++) {
        tasks[indx].addEventListener("click", attachRadioHandler(indx), false);
    }

    buttons[0].addEventListener("click", attachRunButtonHandler, false);
    buttons[1].addEventListener("click", attachViewButtonHandler, false);
}());