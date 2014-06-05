function Solve( params ) {
    var s = params[0], c1 = params[1], c2 = params[2], c3 = params[3];
    var answer = 0;
    var sum = 0;
    for ( var numC1 = 0; numC1 <= c1; numC1 += 1 ) {
        var c1Sum = numC1 * c1;
        if ( c1Sum <= s ) {
            for ( var numC2 = 0; numC2 <= c2; numC2 += 1 ) {
                var c2Sum = numC2 * c2;
                if ( c1Sum + c2Sum <= s ) {
                    for ( var numC3 = 0; numC3 <= c3; numC3 += 1 ) {
                        var c3Sum = numC3 * c3;
                        var subTotal = c1Sum + c2Sum + c3Sum;
                        if ( subTotal > s ) {
                            break;
                        }
                        if ( ( subTotal <= s ) && ( subTotal > answer ) ) {
                            answer = subTotal;
                        }
                    }
                }
            }
        }
    }

    return answer;
}

 var params = ['1', '6900', '110', '11'];

//var params = ['110', '19', '29', '39'];
// var params = ['110', '13', '15', '17'];


console.log( Solve( params ) );

