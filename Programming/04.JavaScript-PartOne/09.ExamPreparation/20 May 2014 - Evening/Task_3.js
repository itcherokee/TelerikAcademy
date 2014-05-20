function Solve(input) {


}

var fs = require( "fs" );
fs.readFile( 'tests\\task3_1.txt', function ( error, fileContent ) {
    //fs.readFile( 'tests\\clojure1.txt', function ( error, fileContent ) {
    var input = fileContent.toString().split( '\r\n' );
    console.log( input );
    // use the input array
    console.log( Solve( input ) );
});