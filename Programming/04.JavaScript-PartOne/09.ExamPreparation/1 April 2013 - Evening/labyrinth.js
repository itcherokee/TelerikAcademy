function Solve(input) {
    var dimensions = input[0].split(' ').map(Number);
    input.shift();
    var startPosition = input[0].split(' ').map(Number);
    input.shift();

    var fieldNumbers = initalizeField();
    var fieldDirections = initalizeField(input),
        currentRow = startPosition[0],
        currentCol = startPosition[1],
        totalSum = fieldNumbers[currentRow][currentCol],
        countCells = 1;

    while (true) {
        fieldNumbers[currentRow][currentCol] = 0;
        switch (fieldDirections[currentRow][currentCol]) {
            case 'l':
                currentCol -= 1;
                break;
            case 'r':
                currentCol += 1;
                break;
            case 'u':
                currentRow -= 1;
                break;
            case 'd':
                currentRow += 1;
                break;
        }

        if (currentRow < 0 || currentRow >= dimensions[0] || currentCol < 0 || currentCol >= dimensions[1]) {
            return 'out ' + totalSum;
        } else if (fieldNumbers[currentRow][currentCol] === 0) {
            return 'lost ' + countCells;
        }

        totalSum += fieldNumbers[currentRow][currentCol];
        countCells++;
    }

    function initalizeField() {
        if (arguments.length !== 0) {
            var directions = Array.prototype.slice.apply(arguments)[0];
        }

        var board = [];
        var counter = 1;
        for (var row = 0; row < dimensions[0]; row++) {
            board.push([]);
            for (var col = 0; col < dimensions[1]; col++) {
                if (arguments.length !== 0) {
                    board[row][col] = directions[row][col];
                } else {
                    board[row][col] = counter++;
                }
            }
        }

        return board;
    }
}

// if you test in BGCoder, following lines shuld not be copied into it!
// They are just for testing under Browser Console or Node.js

var inputOne = [
    "3 4",
    "1 3",
    "lrrd",
    "dlll",
    "rddd"];

var inputTwo = [
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "durlddud",
    "urrrldud",
    "ulllllll"];

var inputThree = [
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "lurlddud",
    "urrrldud",
    "ulllllll"];

//console.log(Solve(inputOne));
//console.log(Solve(inputTwo));
//console.log(Solve(inputThree));


var fs = require("fs");
fs.readFile('tests\\labyrinth1.txt', function (error, fileContent) {
    var input = fileContent.toString().split('\r\n');
    // use the input array
    console.log(Solve(input));
});