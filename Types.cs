using GraphQL.Types;

public class Note
{
    public Guid Id { get; set; }
    public string Message { get; set; }
}

public class Search
{
    public int Offset { get; set; }
    public int Limit { get; set; }
}

public class SearchInputType: InputObjectGraphType<Search> 
{
    public SearchInputType()
    {
        Name = "Search";
        Field(c => c.Limit);
        Field(c => c.Offset);
    }
}

public class NoteType : ObjectGraphType<Note>
{
    public NoteType()
    {
        Name = "Note";
        Description = "Note Type";
        Field(d => d.Id, nullable: false).Description("Note Id");
        Field(d => d.Message, nullable: true).Description("Note Message");
    }
}

public class NotesQuery : ObjectGraphType
{
    public NotesQuery()
    {
        Field<ListGraphType<NoteType>>("notes",
            arguments: new QueryArguments(new QueryArgument<SearchInputType>() { Name = "search" }),
            resolve: context => new List<Note> {
                new Note { Id = Guid.NewGuid(), Message = "Hello World!" },
                new Note { Id = Guid.NewGuid(), Message = "Hello World! How are you?" }
            });
    }
}

public class NotesSchema : Schema
{
    public NotesSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<NotesQuery>();
    }
}
