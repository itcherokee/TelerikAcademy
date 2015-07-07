//'use strict';
var app = app || {};
(function (scope) {
    var person = (function () {
        var person = {
            init: function (name) {
                this.name = name;
                return this;
            },
            toString: function(){
                return 'Name: ' + this.name;
            }
        };

        return person;
    })();

    scope.student = (function (parent) {
        var student = {
            init:function(name, grade){
                var self = Object.create(parent);
                person.init.call(self, name);
                self.grade = grade;

                return self;
            }
        };

        return student;
    })(person);

})(app);

var p = app.student.init('Pepo', 3);
var g = app.student.init('Gogo', 5);
console.log(p == g);
console.log(p.toString());
console.log(g.toString());

