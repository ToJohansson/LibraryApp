using Library.Core.Enums;
using Library.Core.Models;
using Library.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Handlers;
public class BookListingHandler
{
    private readonly LibraryService _service;
    private readonly ILogger<BookListingHandler> _logger;
    public BookListingHandler(LibraryService libraryService, ILogger<BookListingHandler> logger)
    {
        _service = libraryService;
        _logger = logger;
    }

    // List all books by sort order
    public IEnumerable<Book> SortedBooks(SortOrder sort)
    {
        try
        {
            _logger.LogInformation("Books sorted by {0}", sort);
            return _service.ListBooks(sort);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new List<Book>();
        }
    }

    // List of all books
    public IEnumerable<Book> UnSortedBooks()
    {
        try
        {
            _logger.LogInformation("Books are unsorted");
            return _service.ListBooks();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new List<Book>();
        }
    }

    // Search all books with common string
    public IEnumerable<Book> BooksWithSearchString(string search)
    {
        try
        {
            _logger.LogInformation("Books searched by {0}", search);
            return _service.SearchBooks(search);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new List<Book>();
        }
    }

    // Get a book by ISBN
    public Book? GetBook(string isbn)
    {
        try
        {
            _logger.LogInformation("Book fetched by {0}", isbn);
            return _service.GetBook(isbn);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
}
