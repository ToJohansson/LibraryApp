using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces;
public interface IBookRepository
{
    void AddBook(Book book);
    void RemoveBook(string identifier);// titel eller ISBN
    IEnumerable<Book> GetAllBooks();
    IEnumerable<Book> Search(string query);
    Book? GetByISBN(string isbn);
    void Update(Book book);
}
