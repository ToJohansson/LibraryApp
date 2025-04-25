using Library.Core.Enums;
using Library.Core.Models;
using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Handlers;
public class BookListingHandler
{
    private readonly LibraryService _service;
    public BookListingHandler(LibraryService libraryService)
    {
        _service = libraryService;
    }

    // List all books by sort order
    public IEnumerable<Book> SortedBooks(SortOrder sort)
    {
        try
        {
            return _service.ListBooks(sort);
        }
        catch (Exception ex)
        {
            return new List<Book>();
        }
    }

    // List of all books
    public IEnumerable<Book> UnSortedBooks()
    {
        try
        {
            return _service.ListBooks();
        }
        catch (Exception ex)
        {
            return new List<Book>();
        }
    }

    // Search all books with common string
    public IEnumerable<Book> BooksWithSearchString(string search)
    {
        try
        {
            return _service.SearchBooks(search);
        }
        catch (Exception ex)
        {
            return new List<Book>();
        }
    }

    // Get a book by ISBN
    public Book? GetBook(string isbn)
    {
        try
        {
            return _service.GetBook(isbn);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
