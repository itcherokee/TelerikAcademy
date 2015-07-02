/* Task Description */
/* 
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		v*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		v*	age must always be a number in the range 0 150
		v	*	the setter of age can receive a convertible-to-number value
		v*	if any of the above is not met, throw Error
	v*	property `fullname`
		v*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		v*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	v*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	v*	all methods and properties must be attached to the prototype of the Person
	v*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {
	var MIN_NAME_LENGTH = 3,
		MAX_NAME_LENGTH =  20,
		MIN_AGE = 0,
		MAX_AGE = 150,
		NAME_REGEX = /^[a-zA-Z]*$/g;

	function isValidName(value){
		return !!(typeof value === 'string' && value.match(NAME_REGEX)
			&& value.length >= MIN_NAME_LENGTH && value.length <= MAX_NAME_LENGTH);
	}

	var Person = (function () {
		function Person(firstname, lastname, age) {
			this.firstname = firstname;
			this.lastname = lastname;
			this.age = age;
		}

		Object.defineProperties(Person.prototype, {
			firstname : {
				get: function() {
					return this._firstname;
				},
				set: function(value) {
					if (isValidName(value)){
						this._firstname = value;
						return this;
					}

					throw new Error ('Invalid value for Firstname provided');
				},
				configurable: false,
				enumerable: true
			},
			lastname : {
				get: function() {
					return this._lastname;
				},
				set: function(value) {
					if (isValidName(value)){
						this._lastname = value;
						return this;
					}

					throw new Error ('Invalid value for Firstname provided');
				},
				configurable: false,
				enumerable: true
			},
			age : {
				get: function() {
					return this._age;
				},
				set: function(value) {
					var age = parseInt(value);
					if (isNaN(age) || age < MIN_AGE || age > MAX_AGE){
						throw new Error ('Invalid value for age provided');
					}

					this._age = age;

					return this;
				},
				configurable: false,
				enumerable: true
			},
			fullname : {
				get: function() {
					return this.firstname + ' ' + this.lastname;
				},
				set: function(value) {
					var names;
					if (typeof value === 'string' ){
						names = value.trim().split(' ');
						if (names.length !== 2) {
							throw new Error ('Firstname or Lastname has not been provided or simply too many names have been given');
						}

						this.firstname = names[0];
						this.lastname = names[1];

						return this;
					} else {
						throw new Error ('Invalid full name provided');
					}
				},
				configurable: false,
				enumerable: true
			}
		});

		Person.prototype.introduce = function(){
			return 'Hello! My name is ' + this.fullname + ' and I am ' + this.age +'-years-old';
		};
		
		return Person;
	} ());

	return Person;
}

module.exports = solve;


