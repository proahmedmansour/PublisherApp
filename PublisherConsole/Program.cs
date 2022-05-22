// See https://aka.ms/new-console-template for more information
using Publisher.Data;

GetFilteredData();

void GetFilteredData()
{
    using var context = new PublisherContext();

    var authors = context.Authors.Where(x => x.FirstName == "Ahmed").ToList();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}