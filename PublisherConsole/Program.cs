// See https://aka.ms/new-console-template for more information
using Publisher.Data;
using Publisher.Domain;

using (PublisherContext context = new PublisherContext())
{
    context.Database.EnsureCreated();
}

GetAuthors();
AddAuthor();
GetAuthors();

void AddAuthor()
{
    using var context = new PublisherContext();

    var author = new Author { FirstName = "Ahmed", LastName = "Mansour" };

    context.Authors.Add(author);

    context.SaveChanges();
}

void GetAuthors()
{
    using var context = new PublisherContext();

    var authors = context.Authors.ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}