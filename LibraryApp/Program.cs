// See https://aka.ms/new-console-template for more information
using Library.Core.Enums;
using Library.Core.Interfaces;
using Library.Core.Models;
using Library.Core.Services;
using Library.InMemory;
using System.Text;

Console.WriteLine("Library APP!");




InMemoryBookRepository inMemoryBookRepository = new InMemoryBookRepository();
SeedData.Initialize(inMemoryBookRepository);
LibraryService libraryService = new LibraryService(inMemoryBookRepository);

StringBuilder sb = new StringBuilder();
SortOrder authorSort = SortOrder.Author;
SortOrder TitleSort = SortOrder.Title;
var allBooksSortByAuthor = libraryService.ListBooks(authorSort);
var allBooksSortByTitle = libraryService.ListBooks(TitleSort);

Console.WriteLine("All books sort by author");
foreach (Book book in allBooksSortByAuthor)
{
    Console.WriteLine(book);
    Console.WriteLine("");

}

Console.WriteLine("#############################");
Console.WriteLine("#############################");
Console.WriteLine("#############################");
Console.WriteLine("#############################");
Console.WriteLine("#############################");
Console.WriteLine("#############################");

Console.WriteLine("All books sort by Title");
foreach (Book book in allBooksSortByTitle)
{
    Console.WriteLine(book);
    Console.WriteLine("");

}


