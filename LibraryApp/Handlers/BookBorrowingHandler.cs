using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Handlers;
public class BookBorrowingHandler
{
    private readonly LibraryService _service;
    public BookBorrowingHandler(LibraryService libraryService)
    {
        _service = libraryService;
    }

    // mark book as borrowed
    public bool BorrowBook(string isbn)
    {
        try
        {
            _service.MarkAsBorrowed(isbn);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    // mark book as returned
    public bool ReturnBook(string isbn)
    {
        try
        {
            _service.MarkAsReturned(isbn);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
