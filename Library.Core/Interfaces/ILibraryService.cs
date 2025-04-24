using Library.Core.Enums;
using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces;
public interface ILibraryService
{
    void AddBook(string title, string author, string isbn, string category);
    void RemoveBook(string identifier);
    IEnumerable<Book> ListBooks(SortOrder sortOrder);
    IEnumerable<Book> ListBooks();
    IEnumerable<Book> SearchBooks(string query);
    void MarkAsBorrowed(string isbn);
    void MarkAsReturned(string isbn);
}
