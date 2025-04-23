using Library.Core.Enums;
using Library.Core.Interfaces;
using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services;
public class LibraryService : ILibraryService
{
    private readonly IBookRepository _repository;
    public LibraryService(IBookRepository repository)
    {
        _repository = repository;
    }
    public void AddBook(string title, string author, string isbn, string category)
    {

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentNullException("Title and author is needed.");
        }
        if (_repository.GetByISBN(isbn) is not null)
        {
            throw new ArgumentNullException("A book with this isb number already exists.");
        }
        var book = new Book(title, author, isbn, category);
        _repository.AddBook(book);
    }

    public IEnumerable<Book> ListBooks(SortOrder sortOrder)
    {
        var books = _repository.GetAllBooks();

        return sortOrder switch
        {
            SortOrder.Title => books.OrderBy(b => b.Title),
            SortOrder.Author => books.OrderBy(b => b.Author),
            _ => books
        };
    }

    public void MarkAsBorrowed(string isbn)
    {
        // 1. Hämta boken från repository med ISBN
        var book = _repository.GetByISBN(isbn);
        // 2. Om boken inte finns: kasta ett undantag eller gör inget
        if (book == null)
        {
            throw new ArgumentNullException($"Book with isbn: {isbn} does not exists.");
        }
        // 3. Om boken finns och är tillgänglig:
        if (book.IsAvailable)
        {
            //    a) Sätt IsAvailable = false
            book.IsAvailable = false;
        }
        //    b) Uppdatera boken i repository med _repository.Update(...)
        _repository.Update(book);
    }

    public void MarkAsReturned(string isbn)
    {
        // 1. Hämta boken från repository med ISBN
        var book = _repository.GetByISBN(isbn);
        // 2. Om boken inte finns: kasta ett undantag eller gör inget
        if (book == null)
        {
            throw new ArgumentNullException($"Book with isb: {isbn} does not exsist.");
        }
        // 3. Om boken finns:
        //    a) Sätt IsAvailable = true
        book.IsAvailable = true;
        //    b) Uppdatera boken i repository
        _repository.Update(book);
    }

    public void RemoveBook(string identifier)
    {
        // 1. Försök tolka identifier som ISBN först: _repository.GetByISBN(...)
        var book = new Book();

        var bookList = _repository.GetAllBooks();
        foreach (var b in bookList)
        {
            if (identifier == b.Title || identifier == b.Author || identifier == b.ISBN)
            {
                book = b;
                break;
            }
        }
        var bookToRemove = bookList.FirstOrDefault(b => b.Title == identifier ||
                                                        b.Author == identifier ||
                                                        b.ISBN == identifier);


        // 2. Om boken finns, ta bort den
        // 3. Annars: sök bland alla böcker efter match på titel (case insensitive)
        // 4. Om en match hittas, ta bort den
        // 5. Om inget hittas: gör inget eller kasta undantag
        _repository.RemoveBook(book);
    }

    IEnumerable<Book> ILibraryService.SearchBooks(string query)
    {
        // 1. Anropa _repository.Search(query)
        // 2. Returnera resultatet (filtrerat på titel/författare i repository)
        throw new NotImplementedException();
    }

}
