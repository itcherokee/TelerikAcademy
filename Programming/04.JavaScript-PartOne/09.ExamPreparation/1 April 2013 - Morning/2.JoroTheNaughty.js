function Solve( input ) {
    var dimensionsAnJumps = input.shift().split( ' ' ).map( Number );
    var startPosition = input.shift().split( ' ' ).map( Number );
    var field = initalizeField(),
        currentRow = startPosition[0],
        currentCol = startPosition[1],
        sumOfNumbers = 0,
        numberOfJumps = 0,
        jumps = [];
    
    for ( var i = 0; i < dimensionsAnJumps[2]; i++ ) {
        var currentJump = input[i].split( ' ' ).map( Number );
        jumps.push( currentJump );
    }

    var currentJumpsIndex = 0;
    while ( true ) {
        if ( currentRow < 0 || currentRow >= dimensionsAnJumps[0] ||
            currentCol < 0 || currentCol >= dimensionsAnJumps[1] ) {
            return 'escaped ' + sumOfNumbers;
        }

        if ( field[currentRow][currentCol] === 'x' ) {
            return 'caught ' + numberOfJumps;
        }

        sumOfNumbers += field[currentRow][currentCol];
        field[currentRow][currentCol] = 'x';
        if ( currentJumpsIndex === dimensionsAnJumps[2] ) {
            currentJumpsIndex = 0;
        }

        currentRow += jumps[currentJumpsIndex][0];
        currentCol += jumps[currentJumpsIndex][1];
        currentJumpsIndex++;
        numberOfJumps++;
    }

    function initalizeField() {
        var board = [];
        var counter = 1;
        for ( var row = 0; row < dimensionsAnJumps[0]; row++ ) {
            board.push( [] );
            for ( var col = 0; col < dimensionsAnJumps[1]; col++ ) {
                board[row][col] = counter++;
            }
        }

        return board;
    }
}

// if you test in BGCoder, following lines shuld not be copied into it!
// They are just for testing under Browser Console or Node.js

var inputOne = ['6 7 3', '0 0', '2 2', '-2 2', '3 -1'];

var fs = require( "fs" );
fs.readFile( 'tests\\joroTheNaughty.txt', function ( error, fileContent ) {
    var input = fileContent.toString().split( '\r\n' );
    //  console.log( input );
    // use the input array
    console.log( Solve( input ) );
});