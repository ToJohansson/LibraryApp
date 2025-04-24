using Library.Core.Interfaces;
using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InMemory;
public class SeedData
{
    public static readonly List<Book> books = new List<Book>
    {
        new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084", "Fiction"),
        new Book("1984", "George Orwell", "9780451524935", "Dystopian"),
        new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488", "Fiction"),
        new Book("Moby-Dick", "Herman Melville", "9781503280786", "Adventure"),
        new Book("Pride and Prejudice", "Jane Austen", "9781503290563", "Romance"),
        new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565", "Fiction"),
        new Book("The Hobbit", "J.R.R. Tolkien", "9780547928227", "Fantasy"),
        new Book("War and Peace", "Leo Tolstoy", "9781853260629", "Historical Fiction")
    };
    public static void Initialize(IBookRepository bookRepository)
    {
        foreach (var book in books)
        {
            bookRepository.AddBook(book);
        }
    }
}
