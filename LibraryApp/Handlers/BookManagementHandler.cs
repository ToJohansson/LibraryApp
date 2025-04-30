using Library.Core.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Handlers;
public class BookManagementHandler
{
    private readonly LibraryService _service;
    private readonly ILogger<BookManagementHandler> _logger;

    public BookManagementHandler(LibraryService libraryService, ILogger<BookManagementHandler> logger)
    {
        _service = libraryService;
        _logger = logger;
    }

    //    Lägg till böcker i biblioteket.
    public bool AddBook(string title, string author, string isbn, string category)
    {
        try
        {
            _service.AddBook(title, author, isbn, category);
            _logger.LogInformation("new book added with isbn {0}", isbn);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error: {0}", ex.Message);
            return false;
        }
    }
    //  Ta bort böcker från biblioteket.
    public bool RemoveBook(string identifier)
    {
        try
        {
            _service.RemoveBook(identifier);
            _logger.LogInformation("Book removed by {0}", identifier);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }
    //  Uppdatera befintliga böcker.
    public bool UpdateBook(string title, string author, string isbn, string category)
    {
        try
        {
            _service.Update(title, author, isbn, category);
            _logger.LogInformation("Updated successful");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return false;
        }
    }




}
