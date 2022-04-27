using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);
// setup required services
builder.Services.AddGraphQL(o => o
    .AddHttpMiddleware<ISchema>()
    .AddSystemTextJson()
    .AddSchema<NotesSchema>()
    .AddGraphTypes(typeof(NotesSchema).Assembly));

var app = builder.Build();

// setup middlewares
app
    .UseGraphQL<ISchema>()
    .UseGraphQLGraphiQL();
    
await app.RunAsync();
