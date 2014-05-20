function Solve(input) {
    input = input.map(Number);
    input.shift();
    var countSeq = 1;

    for (var i = 1; i < input.length; i++) {
        if (input[i] < input[i - 1]) {
            countSeq++;
        }
    }

    return countSeq;
}

// if you test in BGCoder, following lines shuld not be copied into it!
// They are just for testing under Browser Console or Node.js

var inputOne = ['7', '1', '2', '-3', '4', '4', '0', '1'];
var inputTwo = ['6', '1', '3', '-5', '8', '7', '-6'];
var inputThree = ['9','1','8','8','7','6','5','7','7','6'];

console.log(Solve(inputOne));
console.log(Solve(inputTwo));
console.log(Solve(inputThree));
