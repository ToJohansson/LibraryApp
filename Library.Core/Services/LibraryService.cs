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
        throw new NotImplementedException();
    }

    public void MarkAsBorrowed(string isbn)
    {
        throw new NotImplementedException();
    }

    public void MarkAsReturned(string isbn)
    {
        throw new NotImplementedException();
    }

    public void RemoveBook(string identifier)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Book> ILibraryService.SearchBooks(string query)
    {
        throw new NotImplementedException();
    }
}
