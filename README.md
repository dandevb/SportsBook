# SportsBook
This project started as part of a technical test for a job application. I wanted to use and showcase how to use repository and unit of work patterns in .Net Core. Also, I decided to go for a generic repository in this case.

The project was meant to be used as a console application. I still want to develop a proper console application and commands but will work on API server first. I intend to use repository for different applications and include async methods.

I would normally use Mapper for my domain entities and DTOs but decided to try mapping my objects myself. Only using Entity Framework for my DbContext and migrations to create the DB in SQL Server

# TODO
- Add Logger and improve the error / message logging functions. Especially in the services.
- Add all the Unit tests for repository, UoW and domain entities. 
- Use API server using repository and also to practice Web API and REST practices.

# Business rules for models
A sport contains the following elements:
- Name
- Display Name
- Slug (url friendly version of name)
- Order
- Active (Either true or false)

An event contains the following elements:
- Name
- Event Type (Either preplay or inplay)
- Sport
- Status (Preplay, Inplay or Ended)
- Slug (url friendly version of name)
- Active (Either true or false)

A market contains the following elements:
- Name
- Display Name
- Order
- Active (Either true or false)
- Schema (integer value which controls how market is displayed)
- Columns (number of columns used in display)

A selection contains the following elements:
- Name
- Event
- Market
- Price (Decimal value, to 2 decimal places)
- Active (Either true or false)
- Outcome (Unsettled, Void, Lose, Place, Win)

Implement a system which manages multiple sports, events, markets, and selections.

# Business Requirements
- A sport may have multiple events
- An event may have multiple markets
- A market may have multiple selections
- When all the selections of a particular market are inactive, the market becomes inactive
- When all the markets of an event are inactive, the event becomes inactive
- When all the events of an sport are inactive, the sport becomes inactive

# Unit Testing
Planning to use NUnit, MSTest and Mock as frameworks to practice unit testing in this project.
My goals for unit testing are:
- Unit test repository, UoW and entities
- Follow the best practices defined here: https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
- Practice a TDD approach on the API server
