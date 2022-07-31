Create a website like IMDB with basic CRUD operations using C# (Asp.NET Core Web API).

Entities used are:

Actor - ActorId, ActorName
Genre - GenreId, GenreName
Producer - ProducerId, ProducerName
Movie - MovieId, MovieTitle, ReleaseDate, GenreId, ActorId, ProducerId

Database is designed using Microsoft SQL Server.

Using Entity Framework Core Data Access Layer was developed using Database-first approach. NuGet Packages used are:

1. Microsoft.EntityFrameworkCore.SqlServer NuGet package is used to access data from MS SQL Server database.
2. Microsoft.EntityFrameworkCore.Tools NuGet package is used to execute EF Core commands during development.

Scaffolding:

1. MSSQL Table is conveted to a Class ( also known as Entity).
2. Rows of a table represent the Class Objects.
3. Table data represents list of Objects.

Syntax: Scaffold-DbContext [-Connection] "" [-Provider] "" [-OutputDir] ""
        -Connection "" (Connection String to the database)
        -Provider "" ( Provider to use i.e., Microsoft.EntityFrameworkCore.SqlServer)
        -OutputDir "" ( The directory to put files in)

Once the Data Access Layer is designed Service layer is built because it plays a key role in providing data in a format that is consumable by different types of presentation apps. It also separates user interface (presentation) from rest of the layers (business, data access).

Controller classes are created using ASP.NET Core Web API Application in order to receive inputs and provide response.
