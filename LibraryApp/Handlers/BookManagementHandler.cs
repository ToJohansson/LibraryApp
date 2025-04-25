using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Handlers;
public class BookManagementHandler
{
    private readonly LibraryService _service;

    public BookManagementHandler(LibraryService libraryService)
    {
        _service = libraryService;
    }

    //    Lägg till böcker i biblioteket.
    public bool AddBook(string title, string author, string isbn, string category)
    {
        try
        {
            _service.AddBook(title, author, isbn, category);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    //  Ta bort böcker från biblioteket.
    public bool RemoveBook(string identifier)
    {
        try
        {
            _service.RemoveBook(identifier);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    //  Uppdatera befintliga böcker.
    public bool UpdateBook(string title, string author, string isbn, string category)
    {
        try
        {
            _service.Update(title, author, isbn, category);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }




}
