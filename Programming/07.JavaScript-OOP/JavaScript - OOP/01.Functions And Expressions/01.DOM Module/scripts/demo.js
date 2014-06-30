// Create Div with some properties
var newElementDiv = document.createElement('div');
newElementDiv.style.position = 'absolute';
newElementDiv.style.top = '50px';
newElementDiv.style.left = '250px';
newElementDiv.style.width = '100px';
newElementDiv.style.height = '100px';
newElementDiv.style.color = 'white';
newElementDiv.style.fontWeight = 'bold';
newElementDiv.style.textAlign = 'center';
newElementDiv.style.lineHeight = '100px';
newElementDiv.style.borderRadius = '50px';
newElementDiv.style.backgroundColor = 'green';
newElementDiv.innerHTML = 'Click Me';
newElementDiv.id = 'boxDiv';
domModule.appendChild(newElementDiv,'body');

// Create HR element
var newElementHr = document.createElement('hr');
newElementHr.style.borderColor = 'red';
newElementHr.style.width = '350px';
domModule.appendChild(newElementHr, '#output');

// add Event Handler to Div to change background color
domModule.addHandler('#boxDiv', 'click', function () {
    if (this.style.backgroundColor === 'green'){
        this.style.backgroundColor = 'red';
    } else {
        this.style.backgroundColor = 'green';
    }
});

// Test Buffer features
for (var index = 0; index < 101; index+=1) {
    var li = document.createElement('li');
    li.innerText = "I'm list-item " + index;
    domModule.appendToBuffer('ul', li)
}
