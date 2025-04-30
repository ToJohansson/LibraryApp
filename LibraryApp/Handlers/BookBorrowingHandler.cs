using Library.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Handlers;
public class BookBorrowingHandler
{
    private readonly LibraryService _service;
    private readonly ILogger<BookBorrowingHandler> _logger;
    public BookBorrowingHandler(LibraryService libraryService, ILogger<BookBorrowingHandler> logger)
    {
        _service = libraryService;
        _logger = logger;
    }

    // mark book as borrowed
    public bool BorrowBook(string isbn)
    {
        try
        {
            _service.MarkAsBorrowed(isbn);
            _logger.LogInformation("Book check out is: Success");
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return false;
        }
    }
    // mark book as returned
    public bool ReturnBook(string isbn)

    {
        try
        {
            _service.MarkAsReturned(isbn);
            _logger.LogInformation("Book return out is: Success");

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return false;
        }
    }
}
