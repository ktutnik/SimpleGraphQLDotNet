using GraphQL.Types;

public class Note
{
    public Guid Id { get; set; }
    public string Message { get; set; }
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
        Field<ListGraphType<NoteType>>("notes", resolve: context => new List<Note> {
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
