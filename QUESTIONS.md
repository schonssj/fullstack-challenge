# Questions - Take Home Test #

### Discuss your strategy and decisions implementing the application. Please, consider time complexity, effort cost, technologies used and any other variable that you understand important on your development process. ###
    
#### Backend development ####
I started this challenge by analyzing provided context and source files, then I could start development by setting up an ASP.NET Core Web API to implement all logic and data processing.

The schema information allowed me to identify which are the entities for this context, so I shaped model classes for them:
```csharp
- Models/Bill.cs
- Models/Legislator.cs
- Models/Vote.cs
- Models/VoteResult.cs
```

Thinking of CSV files only as datasets, which could be substituted by a database in the future, led me to use **Repository** pattern to separate business logic from data access, resulting in creation of:
```csharp
- Repositories/BillRepository.cs
- Repositories/LegislatorRepository.cs
- Repositories/VoteRepository.cs
- Repositories/VoteResultRepository.cs
```
Which are the files responsible for reading their respectives CSV sheets and parsing them into objects, using **CsvHelper** lib to achieve this.

As for the business logic itself, it takes place on:
```csharp
- Services/BillService.cs
- Services/LegislatorService.cs
```
Which are the files that orchestrate interation between application and data access layers, building data transfer objects (DTO) that will serve client application.

The DTOs are a representation of data that will be displayed to client. Each of them was made to answer a question of this challenge, resulting in:
```csharp
- DTO/BillResultsDTO.cs
- DTO/LegislatorVotesDTO.cs
```

Finally, in order to expose these behaviors, two Controllers act as endpoints to serve client applications:
```csharp
- Controllers/BillController.cs
- Controllers/LegislatorController.cs
```

#### Tests ####

I also set up a Tests project using MSTest in order to guarantee that data is being retrieved from CSV. Tests are available under `src/TakeHomeTest.Tests` folder and can be ran by using `dotnet test` command in an integrated terminal.

#### Frontend Development ####

In order to display information in a friendly way to end-user, a basic Angular SPA was created, providing a web page that shows essentially two tables: one containing a list of bills and their results (supporters/opposers), and other containing a list of legislators and all bills supported/opposed by each one.

#### Technologies ####

For both projects, I choose languages and frameworks I am familiar with, so I could speed up development part and focus on solving the challenge in the best way. For Backend side, I used .NET 8 with C# 12, while Frontend was built with Angular 19, TypeScript 5.7 and Angular Material for styling.

This tech stack is pretty reliable for building large-scale applications, as both have advantages like strongly typing and built-in DI modules. Although, it brings more complexity to get things working due to extense verbosity in comparison to other frameworks (i.e., same result could be achieved writting less code with React.js + Node.js).

### How would you change your solution to account for future columns that might be requested, such as “Bill Voted On Date” or“Co-Sponsors”? ###

For every new column this solution might need to account in the future, a new property must be written in the Model class (in this case, I think it would be Bill.cs). This way, the CSV Reader will be able to translate column values into code and make them ready to use. 
If this new info is supposed to be shown to the client, then we would need to write the property on a DTO class as well.

### How would you change your solution if instead of receiving CSVs of data, you were given a list of legislators or bills that you should generate a CSV for? ###
    
It depends on how this list would be provided. But, assuming that this data would come from a client application, our solution would need a new endpoint for this feature, so it could receive the list and ask a Service class to generate these files using CsvHelper as well.