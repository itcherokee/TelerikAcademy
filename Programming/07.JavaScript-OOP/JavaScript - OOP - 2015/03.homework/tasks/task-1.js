/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				v*	Each book has unique title, author and ISBN
				v*	It must return the newly created book with assigned ID
				v*	If the category is missing, it must be automatically created
			*	List all books
				v*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				v*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			v*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			v*	Author is any non-empty string
			v*	Unique params are Book title and Book ISBN
			v*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
	var library = (function () {
		var books = [];
		var categories = [];

		function listBooks() {
            var result = [],
                category,
                author;

            function filterBy(prop, value){
                return books.filter(function(element){
                    return element[prop] === value;
                })
            }

            if(arguments.length > 0){
                if (arguments[0].category){
                    result = filterBy('category', arguments[0].category)
                } else if (arguments[0].author) {
                    result = filterBy('author', arguments[0].author)
                }
            } else {
                result = books.slice(0);
            }

            result.sort(function(a, b){ return a.ID - b.ID; });
			return result;
		}

		function addBook(book) {

            function isValid(prop){
                var minLength = 2,
                    maxLength = 200;

                if (this[prop]){
                    if (this[prop].length < minLength || this[prop].length > maxLength){
                        return false;
                    }
                } else {
                    return false;
                }

                return true;
            }

            function isUnique(prop, value){
                var result;

                result = books.filter(function( element){
                    return element[prop] === value;
                });

                return result.length !== 1;
            }

			book.ID = books.length + 1;

            // Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
            if (!isValid.call(book, 'title')){
                throw new Error ('Invalid Title');
            }

            // 	Author is any non-empty string
            if (book.author.trim().length === 0){
                throw new Error('Author can not be empty');
            }

            if (!isValid.call(book, 'category')){
                throw new Error ('Invalid Category');
            }

            // Unique params are Book title and Book ISBN
            if (!isUnique.call(this, 'title', book.title)){
                throw new Error('Book\'s title is not unique');
            }

            // Book ISBN is an unique code that contains either 10 or 13 digits
            if (!isUnique.call(this, 'isbn', book.isbn)) {
                throw new Error('Book\'s isbn is not unique');
            }

            if (book.isbn.trim().length !== 10 && book.isbn.trim().length !== 13){
                throw new Error('Book\'s isbn is invalid');
            }

            // TODO: check is array empty
            if (categories.filter(function(element){return element === book.category;}).length === 0){
                categories.push(book.category)
            }

			books.push(book);
			return book;
		}

		function listCategories() {
            categories.sort(function(a, b){ return a.ID - b.ID; });
			return categories;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());

	return library;
}

module.exports = solve;
