// Task 12: Write a function that creates a HTML UL using a template for every HTML LI. 
//          The source of the list should an array of elements. Replace all placeholders
//          marked with –{…}–   with the value of the corresponding property of the object.

var taskTwelve = function () {
    "use strict";
    var brake = "<br />";
    
    function Person(name, age) {
        if (this === window) {
            return new Person(name, age);
        }

        this.name = name;
        this.age = age;
    }

    // replace placeholders with actual person name & age
    function replacePlaceholders(people, source) {
        var target = [];
        var oldSource = "";
        for (var person in people) {
            oldSource = source;
            oldSource = oldSource.replace("-{name}-", people[person].name);
            oldSource = oldSource.replace("-{age}-", people[person].age);
            target.push(oldSource);
        }
        
        return target;
    }

    // function generating UL list to replace (to be inserted) template in the HTML 
    function generateList(people, template) {
        var target = ["<ul>"];
        var newSource = replacePlaceholders(people, template);
        for (var line in newSource) {
            target.push("<li>");
            target.push(newSource[line]);
            target.push("</li>");
        }
        
        target.push("</ul>");
        return target.join("");
    }

    // parser
    function parseTemplate() {
        var template = document.getElementById("list-item").innerHTML;
        var peopleList = [new Person("Peshko", 12), new Person("Goshko", 23), new Person("Toshko", 40)];
        return generateList(peopleList, template);
    }

    var runMe = function () {
        var output = brake;
        document.getElementById("above-js").innerHTML = '<div data-type="template" id="list-item" style="visibility:hidden;"><strong>-{name}-</strong> <span>-{age}-</span></div>';
        output += "Result UL list: " + parseTemplate();
        document.getElementById("tb-result").value = parseTemplate();

        return output;
    };

    return runMe();
};