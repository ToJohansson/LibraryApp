// See https://aka.ms/new-console-template for more information
using Library.Core.Enums;
using Library.Core.Interfaces;
using Library.Core.Models;
using Library.Core.Services;
using Library.InMemory;
using System.Text;

Console.WriteLine("Library APP!");




InMemoryBookRepository inMemoryBookRepository = new InMemoryBookRepository();
//SeedData.Initialize(inMemoryBookRepository);
LibraryService libraryService = new LibraryService(inMemoryBookRepository);

libraryService.AddBook("hoppsan", "C", "1", "category");
libraryService.AddBook("test", "B", "2", "category");

libraryService.MarkAsBorrowed("1");
foreach (var item in libraryService.ListBooks())
{
    Console.WriteLine(item.IsAvailable + " " + item.Title);
}
libraryService.MarkAsReturned("1");
foreach (var item in libraryService.ListBooks())
{
    Console.WriteLine(item.IsAvailable + " " + item.Title);
}

