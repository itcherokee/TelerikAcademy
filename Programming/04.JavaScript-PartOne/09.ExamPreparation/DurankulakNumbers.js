function Solve(args) {
    var i, tempVal = '0', resultArr = [], result = 0;
    var myNum = args[0];
    var arr = generateArr();
    for (i = 0; i < myNum.length; i++) {
        tempVal = myNum[i];
        if (myNum[i].toLowerCase() === myNum[i]) {
            tempVal += myNum[i + 1];
            i++;
        }
     
		resultArr.push(arr.indexOf(tempVal));
    }

    for (i = resultArr.length - 1; i >= 0; i--) {
        result += resultArr[i] * Math.pow(168, resultArr.length - 1 - i);
    }

    return result;

    function generateArr() {
        var capsLetters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
        var arrAlphabet = new Array(168);
        for (i = 0; i < arrAlphabet.length; i++) {
            if (i < capsLetters.length) {
                arrAlphabet[i] = capsLetters[i];
            } else {
                arrAlphabet[i] = capsLetters[Math.floor(i / 26) - 1].toLowerCase() + capsLetters[i % 26]
            }
        }
        
		return arrAlphabet;
    }
}

console.log("'" + Solve('XZAA') + "'");