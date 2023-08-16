# Books

This project is a very simple web backend built on .net core web api.

## Setup:
You can find the SQLite database within this project called books.db. To be able to access it to study it or editing it for personal use you can download SQLiteStudio to you're computer which you can find via this link https://sqlitestudio.pl/.

## Project:
This project has 4 Http triggers.

## Get books

### GET baseurl/Books 

=> Gives all the books in the database. This trigger has also three optional query parameters: author=text, year=number and publisher=text.

GET: baseurl/Books/{id} => Goes and fetches that id's book from database.

POST: baseurl/Books => Adds a book into the database. Just make sure that you have in API calls body a JSON that f 
