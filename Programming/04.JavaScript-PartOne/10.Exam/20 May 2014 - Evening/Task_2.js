function Solve( input ) {
    var rowAndCol = input.shift().split( ' ' ).map( Number );
    var field = initalizeField();

    var currentRow = rowAndCol[0] - 1;
    var currentCol = rowAndCol[1] - 1;
    var steps = [[-2, 1], [-1, 2], [1, 2], [2, 1], [2, -1], [1, -2], [-1, -2], [-2, -1]];
    var sum = field[currentRow][currentCol],
        jumps = 0;



    var jumpField = initalizeJumpField();
    //   console.log( jumpField );


    while ( true ) {


        if ( currentRow < 0 || currentRow >= rowAndCol[0] || currentCol < 0 || currentCol >= rowAndCol[1] ) {
            return 'Go go Horsy! Collected ' + sum + ' weeds';
        }

        if ( field[currentRow][currentCol] === 'x' ) {
            return 'Sadly the horse is doomed in ' + jumps + ' jumps';
        }

        field[currentRow][currentCol] = 'x';
        //console.log();
        var cellMove = jumpField[currentRow][currentCol] -1;
       // console.log(steps)
        currentRow += steps[cellMove][0];
        currentCol += steps[cellMove][1];
        if ( !(currentRow < 0 || currentRow >= rowAndCol[0] || currentCol < 0 || currentCol >= rowAndCol[1]  )) {
            sum += field[currentRow][currentCol];
            jumps++;
        }

    }

    function initalizeField() {
        var board = [];
        //var counter = 1;
        for ( var row = 0; row < rowAndCol[0]; row++ ) {
            board.push( [] );
            var content = Math.pow( 2, row );
            for ( var col = 0; col < rowAndCol[1]; col++ ) {
                board[row][col] = content - col;
            }
        }

        return board;
    }

    function initalizeJumpField() {
        var board = [];
        //var counter = 1;
        for ( var row = 0; row < rowAndCol[0]; row++ ) {
            board.push( input.shift().split( '' ).map( Number ) );

        }

        return board;
    }
}

//var input = [
//    '3 5',
//    '54561',
//    '43328',
//    '52388'
//];

var input =[
  '3 5',
  '54361',
  '43326',
  '52188',
];


console.log(Solve( input ));
//var fs = require( "fs" );
//fs.readFile( 'tests\\task2_1.txt', function ( error, fileContent ) {
//    //fs.readFile( 'tests\\clojure1.txt', function ( error, fileContent ) {
//    var input = fileContent.toString().split( '\r\n' );
//    console.log( input );
//    // use the input array
//    console.log( Solve( input ) );
//});