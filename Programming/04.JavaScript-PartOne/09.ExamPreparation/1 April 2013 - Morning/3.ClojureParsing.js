function Solve( input ) {

    var line;
    var lineNumber = 0;
    var result = 0;
    var functions = {};


    while ( input.length > 0 ) {
        line = input.shift();
        line.trim();
        lineNumber++;

        var isBracket = false;
        var isSecondBracket = false;
        var isDef = false;
        var isOperator = false;
        //  var isSecondOperator = false;
        var isNegative = false;
        //  var isSecondNegative = false;
        var operator = '';
        //  var operatorSecond = '';

        var i = 0;
        var tempOperands = [];
        while ( i < line.length ) {
            if ( line[i] === '(' ) {
                if ( isBracket ) {
                    // this is second openning bracket -> calculate operands up to now
                    result = calculate( tempOperands, operator );
                    isSecondBracket = true;
                    if ( isNaN( result ) ) {
                        result += lineNumber;
                    }
                } else {
                    isBracket = true;
                }
            } else if ( line[i] === ')' ) {
                if ( isSecondBracket ) {
                    isSecondBracket = false;
                } else {
                    isBracket = false;
                }



                if ( isDef ) {
                    functions[startFuncName] = calculate( tempOperands, operator );
                } else {
                    result = calculate( tempOperands, operator );
                    if ( isNaN( result ) ) {
                        result += lineNumber;
                    }
                }
            } else if ( line[i] === '+' || line[i] === '*' || line[i] === '/' || line[i] === '-' ) {
                // operator assignement 
                if ( isOperator ) {
                    isNegative = true;
                } else {
                    isOperator = true;
                    operator = line[i];
                }
            } else if ( line[i] === 'd' && i + 4 < line.length ) {
                // def   
                if ( line[i] + line[i + 1] + line[i + 2] + line[i + 3] === 'def ' ) {
                    // definirane na funkcia
                    i += 4;

                    var startFuncName = '';
                    var isFuncNameFound = false;
                    while ( i < line.length ) {
                        // find function name & value after it
                        if ( line[i] >= 'A' && line[i] <= 'z' && !isDef ) {
                            startFuncName += line[i++];
                        } else if ( line[i] === ' ' && startFuncName.length > 0 ) {
                            isFuncNameFound = true;
                            isDef = true;
                            i++;
                        } else if ( line[i] >= '0' && line[i] <= '9' ) {
                            // numbers
                            var currentNumberFunc = line[i];
                            for ( var j = i + 1; j < line.length; j++ ) {
                                if ( line[j] >= '0' && line[j] <= '9' ) {
                                    currentNumberFunc += line[j];
                                } else {
                                    if ( isNegative ) {
                                        isNegative = false;
                                        currentNumberFunc = '-' + currentNumberFunc;
                                    }

                                    tempOperands.push( parseInt( currentNumberFunc ) );
                                    i = j - 1;
                                    break;
                                }
                            }

                            functions[startFuncName] = currentNumberFunc;
                            i++;
                        } else if ( line[i] === '+' || line[i] === '*' || line[i] === '/' || line[i] === '-' ) {
                            i--;
                            break;
                        } else if ( line[i] === '(' ) {
                            // '(' found
                            functions[startFuncName] = "";
                            isSecondBracket = true;
                            break;


                        } else if ( line[i] === ')' ) {
                            i--;
                            break;
                        }
                    }

                }
            } else if ( line[i] >= '0' && line[i] <= '9' ) {
                // numbers
                var currentNumber = line[i];
                for ( var j = i + 1; j < line.length; j++ ) {
                    if ( line[j] >= '0' && line[j] <= '9' ) {
                        currentNumber += line[j];
                    } else {
                        if ( isNegative ) {
                            isNegative = false;
                            currentNumber = '-' + currentNumber;
                        }

                        tempOperands.push( parseInt( currentNumber ) );
                        i = j - 1;
                        break;
                    }
                }
            } else if ( line[i] !== ' ' ) {
                var currentfuncName = '';
                while ( i < line.length ) {
                    if ( line[i] !== ' ' ) {
                        currentfuncName += line[i++];
                    } else {
                        tempOperands.push( functions[currentfuncName] );
                        break;
                    }
                }
            }

            i++;
        }
    }

    return result;

    function findFuncName() {
        // find function name & value after it
        if (line[i] >= 'A' && line[i] <= 'z' && !isDef) {
            startFuncName += line[i++];
        } else if (line[i] === ' ' && startFuncName.length > 0) {
            isFuncNameFound = true;
            isDef = true;
            i++;
        }
    }

    function calculate( data, operation ) {
        var operands = [];
        for ( var operand in data ) {
            if ( isNaN( data[operand] ) ) {
                operands.push( functions[data[operand]] );
            } else {
                operands.push( data[operand] );
            }
        }

        var operationResult = operands[0];
        for ( var k = 1; k < operands.length; k++ ) {
            switch ( operation ) {
                case '+':
                    operationResult += operands[k];
                    break;
                case '-':
                    operationResult -= operands[k];
                    break;
                case '*':
                    operationResult *= operands[k];
                    break;
                case '/':
                    operationResult /= operands[k];
                    break;
            }
        }

        if ( operationResult === Infinity ) {
            return 'Division by zero! At Line:';
        } else {
            return Math.floor( operationResult );
        }
    }
}

var fs = require( "fs" );
fs.readFile( 'tests\\clojure3.txt', function ( error, fileContent ) {
    //fs.readFile( 'tests\\clojure1.txt', function ( error, fileContent ) {
    var input = fileContent.toString().split( '\r\n' );
    console.log( input );
    // use the input array
    console.log( Solve( input ) );
});
