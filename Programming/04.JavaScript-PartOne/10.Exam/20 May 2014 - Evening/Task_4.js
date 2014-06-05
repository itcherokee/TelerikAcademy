function a( e ) {
    return f( 2 * e ) / ( f( e + 1 ) * f( e ) ) / 2;

    function f( n ) {
        r = i = 1;
        while ( i <= n )r *= i++;
        return r;
    }

}

console.log(a(7))