/* Task description */
/*
 Write a function that finds all the prime numbers in a range
 1) it should return the prime numbers in an array
 2) it must throw an Error if any on the range params is not convertible to `Number`
 x3) it must throw an Error if any of the range params is missing
 */

function findPrimes(begin, end) {
    var currentNumber,
        primes = [];

    if (begin === undefined || end === undefined) {
        throw new Error;
    }

    function isPrime(number) {
        if ((number <= 1)) return false;
        else if (number <= 3) return true;
        else if ((number % 2 == 0) || (number % 3 == 0)) return false;
        else {
            for (var i = 5; i * i <= number; i += 6) {
                if (number % i == 0 || number % (i + 2) == 0) return false;
            }
        }

        return true;
    }

    for (currentNumber = +begin; currentNumber <= +end; currentNumber += 1) {

        if (isPrime(currentNumber)){
            primes.push(currentNumber);
        }
    }

    return primes;
}

module.exports = findPrimes;
