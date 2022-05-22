// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Publisher.Data;
using Publisher.Domain;

using (PublisherContext context = new PublisherContext())
{
    context.Database.EnsureCreated();
}

//GetAuthors();
//AddAuthor();
//GetAuthors();

AddAuthorWithBooks();
GetAuthorWithBooks();

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

void AddAuthorWithBooks()
{
    var author = new Author
    {
        FirstName = "Ahmed",
        LastName = "Mansour"
    };

    author.Books = new List<Book>
    {
        new Book{ Title = "Programming with C#", PublishDate = new DateTime(2022, 1,1)},
        new Book{ Title = "Programming with Java", PublishDate = new DateTime(2022, 2,1)},
    };

    using var context = new PublisherContext();

    context.Add(author);
    context.SaveChanges();
}

void GetAuthorWithBooks()
{
    using var context = new PublisherContext();

    var authors = context.Authors.Include(a => a.Books).ToList();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + "" + author.LastName + " Owning these books: ");
        foreach (var book in author.Books)
        {
            Console.WriteLine(book.Title);
        }
    }
}