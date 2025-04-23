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
        // 1. Kontrollera om en bok med samma ISBN redan finns i repository
        // 2. Om den inte finns:
        //    a) Skapa ett nytt Book-objekt
        //    b) Sätt IsAvailable = true
        //    c) Lägg till boken i repository med _repository.AddBook(...)
        // 3. Annars: kasta ett undantag eller ignorera beroende på logik
        throw new NotImplementedException();
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
        // 2. Om boken inte finns: kasta ett undantag eller gör inget
        // 3. Om boken finns och är tillgänglig:
        //    a) Sätt IsAvailable = false
        //    b) Uppdatera boken i repository med _repository.Update(...)
        throw new NotImplementedException();
    }

    public void MarkAsReturned(string isbn)
    {
        // 1. Hämta boken från repository med ISBN
        // 2. Om boken inte finns: kasta ett undantag eller gör inget
        // 3. Om boken finns:
        //    a) Sätt IsAvailable = true
        //    b) Uppdatera boken i repository
        throw new NotImplementedException();
    }

    public void RemoveBook(string identifier)
    {
        // 1. Försök tolka identifier som ISBN först: _repository.GetByISBN(...)
        // 2. Om boken finns, ta bort den
        // 3. Annars: sök bland alla böcker efter match på titel (case insensitive)
        // 4. Om en match hittas, ta bort den
        // 5. Om inget hittas: gör inget eller kasta undantag
        throw new NotImplementedException();
    }

    IEnumerable<Book> ILibraryService.SearchBooks(string query)
    {
        // 1. Anropa _repository.Search(query)
        // 2. Returnera resultatet (filtrerat på titel/författare i repository)
        throw new NotImplementedException();
    }

}
