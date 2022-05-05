# Simple GraphQL Server using ASP.Net Core

These steps used to create the project

```
dotnet new web -o SimpleGraphQLDotNet
cd SimpleGraphQLDotNet
dotnet add package GraphQL.Server.Transports.AspNetCore
dotnet add package GraphQL.MicrosoftDI
dotnet add package GraphQL.Server.Ui.GraphiQL
dotnet add package GraphQL.SystemTextJson
```

Running the project 

```
dotnet run
```

Then navigate to `https://localhost:7013/ui/graphiql`