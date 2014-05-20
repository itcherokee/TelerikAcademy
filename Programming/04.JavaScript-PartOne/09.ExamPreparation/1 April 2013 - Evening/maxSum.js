function Solve(input) {
    input = input.map(Number);
    input.shift();
    var maxSum = input[0],
        startIndex = 0,
        tempSum = maxSum,
        currentIndex = 1;

    while (startIndex < input.length) {
        if (tempSum > maxSum) {
            maxSum = tempSum;
        }

        if (currentIndex >= input.length) {
            startIndex++;
            currentIndex = startIndex;
            tempSum = 0;
        }

        tempSum += input[currentIndex];
        currentIndex++;
    }

    return maxSum;
}

// if you test in BGCoder, following lines shuld not be copied into it!
// They are just for testing under Browser Console or Node.js

var inputOne = ['8', '1', '6', '-9', '4', '4', '-2', '10', '-1'];
var inputTwo = ['6', '1', '3', '-5', '8', '7', '-6'];
var inputThree = ['9', '-9', '-8', '-8', '-7', '-6', '-5', '-1', '-7', '-6'];
var inputFour = ['1','0'];

console.log(Solve(inputOne));
console.log(Solve(inputTwo));
console.log(Solve(inputThree));
console.log(Solve(inputFour));