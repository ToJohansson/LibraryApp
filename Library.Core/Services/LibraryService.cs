using Library.Core.Enums;
using Library.Core.Interfaces;
using Library.Core.Models;
using System;
using System.Collections;
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

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(category))
        {
            throw new ArgumentException("Title, author, isbn and category is needed.");
        }
        if (_repository.GetByISBN(isbn) is not null)
        {
            throw new ArgumentException("A book with this isbn number already exists.");
        }
        var book = new Book(title, author, isbn, category);
        _repository.AddBook(book);
    }

    public Book GetBook(string identifier)
    {
        return _repository.GetAllBooks()
         .FirstOrDefault(b => b.Title.Contains(identifier, StringComparison.OrdinalIgnoreCase) ||
                     b.Author.Contains(identifier, StringComparison.OrdinalIgnoreCase) ||
                     b.ISBN.Contains(identifier, StringComparison.OrdinalIgnoreCase));
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

    public IEnumerable<Book> ListBooks()
    {
        return _repository.GetAllBooks();
    }

    public void MarkAsBorrowed(string isbn)
    {
        // 1. Hämta boken från repository med ISBN
        var book = _repository.GetByISBN(isbn);
        // 2. Om boken inte finns: kasta ett undantag eller gör inget
        if (book == null)
        {
            throw new ArgumentException($"Book with ISBN: {isbn} does not exists.");
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
            throw new ArgumentException($"Book with isb: {isbn} does not exsist.");
        }
        // 3. Om boken finns:
        //    a) Sätt IsAvailable = true
        book.IsAvailable = true;
        //    b) Uppdatera boken i repository
        _repository.Update(book);
    }

    public void RemoveBook(string identifier)
    {
        var bookList = _repository.GetAllBooks();
        var bookToRemove = bookList
            .FirstOrDefault(b => b.Title.Equals(identifier, StringComparison.OrdinalIgnoreCase) ||
                                 b.Author.Equals(identifier, StringComparison.OrdinalIgnoreCase) ||
                                 b.ISBN.Equals(identifier, StringComparison.OrdinalIgnoreCase));
        if (bookToRemove is null)
        {
            throw new ArgumentException($"No book was found with identifier: {identifier}");
        }
        _repository.RemoveBook(bookToRemove);
    }

    public IEnumerable<Book> SearchBooks(string query)
    {
        return _repository.GetAllBooks()
            .Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                        b.Author.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                        b.ISBN.Contains(query, StringComparison.OrdinalIgnoreCase));
    }

    public void Update(string title, string author, string isbn, string category)
    {
        var oldBook = _repository.GetByISBN(isbn);
        if (oldBook == null)
            throw new ArgumentException($"Book with ISBN {isbn} does not exist.");

        Book updatedBook = new Book(title, author, isbn, category);
        _repository.Update(updatedBook);
    }
}
