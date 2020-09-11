# SportsBook
This project started as part of a technical test for a job application. I wanted to use and showcase how to use repository and unit of work patterns in .Net Core. Also, I decided to go for a generic repository in this case.

The project was meant to be used as a console application. I still want to develop a proper console application and commands but will work on API server first. I intend to use repository for different applications and include async methods.

I would normally use Mapper for my domain entities and DTOs but decided to try mapping my objects myself. Only using Entity Framework for my DbContext and migrations to create the DB in SQL Server

# TODO
- Add Logger and improve the error / message logging functions. Especially in the services.
- Add all the Unit tests for repository, UoW and domain entities. 
- Use API server using repository and also to practice Web API and REST practices.

# Business rules
