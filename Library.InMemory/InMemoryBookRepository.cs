using Library.Core.Interfaces;
using Library.Core.Models;

namespace Library.InMemory;

public class InMemoryBookRepository : IBookRepository
{
    private List<Book> _books = new List<Book>();
    public InMemoryBookRepository()
    {

    }
    public void AddBook(Book book)
    {
        if (!_books.Any(b => b.ISBN.Equals(book.ISBN, StringComparison.OrdinalIgnoreCase)))
        {
            _books.Add(book);
        }
        else
            throw new InvalidOperationException($"A book with ISBN {book.ISBN} already exists.");
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _books;
    }

    public Book? GetByISBN(string isbn)
    {
        return _books.FirstOrDefault(b => b.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));
    }

    public void RemoveBook(Book book)
    {
        var bookToRemove = _books.FirstOrDefault(b => b.ISBN == book.ISBN);
        if (bookToRemove != null)
        {
            _books.Remove(bookToRemove);
        }
    }

    public IEnumerable<Book> Search(string query)
    {
        return _books.Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                b.Author.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                b.ISBN.Contains(query, StringComparison.OrdinalIgnoreCase));
    }

    public void Update(Book updatedBook)
    {
        if (updatedBook == null)
            throw new ArgumentException($"Book with ISBN {updatedBook.ISBN} does not exist.");

        var existingBook = GetByISBN(updatedBook.ISBN);
        if (existingBook != null)
        {
            existingBook.Title = String.IsNullOrWhiteSpace(updatedBook.Title)
                ? existingBook.Title
                : updatedBook.Title;
            existingBook.Author = String.IsNullOrWhiteSpace(updatedBook.Author)
                ? existingBook.Author
                : updatedBook.Author;
            existingBook.Category = String.IsNullOrWhiteSpace(updatedBook.Category)
                ? existingBook.Category
                : updatedBook.Category;
        }
    }
}
