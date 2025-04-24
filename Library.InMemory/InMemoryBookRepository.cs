using Library.Core.Interfaces;
using Library.Core.Models;

namespace Library.InMemory;

public class InMemoryBookRepository : IBookRepository
{
    public void AddBook(Book book)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> GetAllBooks()
    {
        throw new NotImplementedException();
    }

    public Book? GetByISBN(string isbn)
    {
        throw new NotImplementedException();
    }

    public void RemoveBook(Book book)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> Search(string query)
    {
        throw new NotImplementedException();
    }

    public void Update(Book book)
    {
        throw new NotImplementedException();
    }
}
