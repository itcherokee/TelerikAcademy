/* Task Description */
/* 
 Write a function that sums an array of numbers:
 numbers must be always of type Number
 returns `null` if the array is empty
 throws Error if the parameter is not passed (undefined)
 throws if any of the elements is not convertible to Number

 */

function sum(numbers) {
    if (numbers === undefined) {
        throw new Error;
    }

    if (numbers.length === 0) {
        return null
    }

    return numbers.reduce(function (a, b) {
        if (isNaN(+b)) {
            throw new Error;
        }

        return +a + +b;
    }, 0);
}


//
//console.log(sum([]));
//console.log(sum([1,2,3]));
//console.log(sum(["1", "2", "3", "11"]));
////console.log(sum());
//console.log(sum([1, 'Pesho']));

module.exports = sum;