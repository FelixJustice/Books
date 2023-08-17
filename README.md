# Books

This project is a very simple web backend built on .net core web api. That can fetch, create or delete from database.

## Setup:
<p>You can find the SQLite database within this project called books.db. To be able to access it for studying or editing purposes you can download SQLiteStudio to your computer which you can find via the following link: https://sqlitestudio.pl/.</p>
<p>Before running the project go into Program.cs and add the right path into the books.db by editing this part in the file: 
    builder.Services.AddDbContext<BooksContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Data Source={The path to the books.db in the project}")));</p>
<p>Then when you are ready copy this project to your local machine and open it with Visual Studio for example and hit the F10 button to run the project.</p>
<p>When project is running you can test it out with Postman(download link https://www.postman.com/downloads/) and start doing API calls.</p>

## Project:
This project has 4 http triggers that you can find more information about below.

## Get books

### Request

`GET /Books`

    
  <p>http://localhost:9000/Books/</p>
  <p>Gives all the books in the database. This trigger has also three optional query parameters: author=text, year=number and publisher=text.</p>
  <p>Note: That if it does not find any books it will still return a Ok response with a empty array.</p>
    
      
### Ok Response
    [
      {
        "id": 2,
        "title": "Old Testament",
        "author": "Various",
        "year": -165,
        "publisher": null,
        "description": "A holy book of Christianity and Jewish faith"
      },
      {
        "id": 3,
        "title": "The Subtle Knife",
        "author": "Philip Pullman",
        "year": 1997,
        "publisher": "Scholastic Point",
        "description": null
      },
      {
        "id": 4,
        "title": "Goosebumps: Beware, the Snowman",
        "author": "R.L. Stine",
        "year": 1997,
        "publisher": "Scholastic Point",
        "description": null
      }
    ]

### Request

`Get /Books/{id}`

    
  <p>http://localhost:9000/Books/{id}</p>
  <p>Goes and fetches book that corresponds with the id requestd.</p>
    

### Ok Response
    {
      "id": 2,
      "title": "Old Testament",
      "author": "Various",
      "year": -165,
      "publisher": null,
      "description": "A holy book of Christianity and Jewish faith"
    } 

## Create a book

### Request

`Post /Books`

<p>This will insert a book into the database.</p>

### Json Body
    {
      "title": <title_of_book>,
      "author": <author_of_book>,
      "year": <year_of_book>,
      "publisher": <publisher_of_book>,
      "description": <description_of_book>
    }

<p>Note: title, author and year is required else if will lead to a bad request. Publisher is optional but can't be empty.</p>

### Ok Response
    {
      "id": 1
    }

## Delete a book

### Request

`Delete /Books/{id}`

<p>This operation will delete the book that corresponds with the id requested.</p>

### Ok response
<p>You will know if it successfully deleted the book that corresponds with the id by getting 204 No Content response.</p>
