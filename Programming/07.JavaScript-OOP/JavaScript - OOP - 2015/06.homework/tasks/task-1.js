/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
	var TITLE_VALID_REGEX =  /^\S?((\S)\s?(\S)?)*\S$/,
		studentId = 0;

	function isValidParameter(parameter) {
		return this[parameter] === null || typeof(this[parameter]) === 'undefined';
	}

	function isValidString(parameter) {
		return typeof (parameter) === 'string' && parameter !== '';
	}

	function isInt(number){
		return Number(number) === number && number % 1===0;
	}

	function validateTitle(title){
		if (!TITLE_VALID_REGEX.test(title)){
			throw new Error('Invalid Title has been provided.')
		}

		return title;
	}

	function validateName(name){
		if (!isValidParameter(name) || !isValidString(name)
				|| name.charAt(0) !== name.charAt(0).toUpperCase()
				|| (name.length > 1 && name.substr(1) !== name.substr(1).toLowerCase())){
			throw new Error('Invalid Name has been provided.')
		}

		return name;
	}

	function isExistingStudent(studentID) {
		return this.students.filter(function (element) {
				return element.id === studentID;
			}).length !== 0;
	}

	var Presentation = (function () {
		var Presentation = {
			get title(){
				return this._title;
			},
			set title(value){
				this._title = validateTitle(value);
			},
			get homework(){
				return this._homework;
			},
			set homework(value){
				this._homework = value;
			},
			init: function (title) {
				this.title = title;
				this.homework = [];

				return this;
			},
			addHomework: function(studentId){
				this.homework.push(studentId);
			},
			getHomeworksByStudent: function(studentId){

			}
		};

		return Presentation;
	})();

	var Student = (function () {
		var Student = {
			get firstName(){
				return this._firstName;
			},
			set firstName(value){
				this._firstName = validateName(value);
			},
			get lastName(){
				return this._lastname;
			},
			set lastName(value){
				this._lastname = value;
			},
			get id(){
				return this._id;
			},
			set id(value){
				this._id = value;
			},
			get score(){
				return this._score;
			},
			set score(value){
				if (!isValidParameter(value) || isNaN(value)|| !isInt(value)){
					throw new Error('Invalid Score provided');
				}

				this._score = value;
			},
			init:function(firstName, lastName){
				this.firstName = validateName(firstName);
				this.lastName = validateName(lastName);
				this.id = ++studentId;
				this.score = 0;
				return this;
			}
		};

		return Student;
	})();

	var Course = {
		get title(){
			return this._title;
		},
		set title(value){
			this._title = validateTitle(value);
		},
		get presentations(){
			return this._presentations.slice();
		},
		set presentations(value){
			if (Array.isArray(value) && value.length > 0){
				this._presentations = value.map(function(title){
					return Object.create(Presentation).init(title);
				});
			} else {
				throw new Error('Presentations are not provided in correct format/type or there is none at all.')
			}
		},
		get students(){
			return this._students;
		},
		set students(value){
			this._students = value;
		},
		init: function(title, presentations) {
			this.title = title;
			this.presentations = presentations;
			this.students = [];
			return this;
		},
		addStudent: function(name) {
			var names,
				student;

			if (isValidParameter(name) && isValidString(name)){
				names = name.trim().split(' ');
			} else {
				throw new Error ('Invalid student names provided.')
			}

			if (names.length !== 2){
				throw new Error('One or both of the student names are omitted or more than 2 names provided.')
			}

			student = Object.create(Student).init(names[0], names[1]);
			this.students.push(student);

			return student.id;
		},
		getAllStudents: function() {
			return this.students.map(function(student){
				var newStudent = {};
				newStudent.firstname = student.firstName;
				newStudent.lastname = student.lastName;
				newStudent.id = student.id;
				return newStudent;
			});
		},
		submitHomework: function(studentID, homeworkID) {
			if (!isValidParameter(studentID) || !isValidParameter(homeworkID) || isNaN(studentID) || isNaN(homeworkID)
					|| !isInt(studentID) || !isInt(homeworkID)){
				throw new Error('Invalid studentId/homeworkId provided');
			}

			if (!isExistingStudent.call(this, studentID)){
				throw new Error('Non existing student provided for homework');
			}

			if(this.presentations.length < homeworkID || homeworkID < 0){
				throw new Error('Non existing presentation for attaching homework provided');
			}

			this.presentations[homeworkID-1].addHomework(studentId);

			return this;
		},
		pushExamResults: function(results) {
			var studentsToProcess = [];
			if (Array.isArray(results)){
				this._presentations = value.forEach(function(element){
					if (!isValidParameter(element.StudentID) || isNaN(element.StudentID) || !isInt(element.StudentID
							|| !isExistingStudent(element.StudentID))){
						throw new Error('Invalid StudentId provided');
					}

					if (!isValidParameter(element.Score) || isNaN(element.Score)|| !isInt(element.Score)){
						throw new Error('Invalid Score provided');
					}

					if (studentsToProcess.filter(function (student) {
							return student.id === element.StudentID
						}).length > 0){
						throw new Error('Student is trying to cheat with more than 1 score');
					}

					studentsToProcess.push(element);
				});
				studentsToProcess.forEach(function (result) {
					var that = this;
					this.students.filter(function (student) {
						student.score = that.Score;
					})
				})
			} else {
				throw new Error('Exam results are not provided in correct format/type.')
			}
		},
		getTopStudents: function() {
			var topStudents = []; //* Create method getTopStudents which returns an array of the top 10 performing students
			//* Array must be sorted from best to worst
			//* If there are less than 10, return them all
			//* The final score that is used to calculate the top performing students is done as follows:
				//* 75% of the exam result
					var scorePart =  student.score * 0.75;
				//* 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
					var homeworkPart = this.presentations.     this.presentations.length
		}
	};

	return Course;


};

module.exports = solve;
