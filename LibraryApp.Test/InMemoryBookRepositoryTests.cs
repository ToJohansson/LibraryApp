using Library.Core.Models;
using Library.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Test;
public class InMemoryBookRepositoryTests
{

    private InMemoryBookRepository repository;

    public InMemoryBookRepositoryTests()
    {
        repository = new InMemoryBookRepository();
    }
    // AddBook
    [Fact]
    public void AddBook_ShouldAddBook_WhenISBNIsUnique()
    {
        Book book = new Book("test", "test", "test", "test");
        repository.AddBook(book);
        var books = repository.GetAllBooks();
        Assert.Equal(1, books.Count());

    }

    [Fact]
    public void AddBook_ShouldThrowException_WhenISBNAlreadyExists()
    {
        Book book1 = new Book("test", "test", "test", "test");
        Book book2 = new Book("test", "test", "test", "test");

        repository.AddBook(book1);
        Action action = () => repository.AddBook(book2);
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(action);
        Assert.Equal($"A book with ISBN {book2.ISBN} already exists.", exception.Message);
    }

    // GetAllBooks
    [Fact]
    public void GetAllBooks_ShouldReturnAllBooks()
    {
        Book book1 = new Book("test", "test", "1", "test");
        Book book2 = new Book("test", "test", "2", "test");
        repository.AddBook(book1);
        repository.AddBook(book2);
        var books = repository.GetAllBooks();
        Assert.Equal(2, books.Count());
    }

    // GetByISBN
    [Fact]
    public void GetByISBN_ShouldReturnBook_WhenISBNExists()
    {
        Book book1 = new Book("test", "test", "1", "test");
        repository.AddBook(book1);
        var book = repository.GetByISBN("1");
        Assert.Equal(book, book1);
    }
    [Fact]
    public void Search_ShouldReturnMatchingBooks_WhenQueryMatchesTitle()
    {
        Book book1 = new Book("test", "test", "1", "test");
        Book book2 = new Book("tset", "tset", "2", "tset");
        Book book3 = new Book("test", "test", "3", "test");
        repository.AddBook(book1);
        repository.AddBook(book2);
        repository.AddBook(book3);
        var result = repository.Search("test");

        Assert.Equal(2, result.Count());  // Förväntar sig 2 böcker som matchar
    }

    // RemoveBook
    [Fact]
    public void RemoveBook_ShouldRemoveBook_WhenBookExists()
    {
        Book book = new Book("test", "test", "test", "test");
        repository.AddBook(book);
        repository.RemoveBook(book);
        Assert.DoesNotContain(book, repository.GetAllBooks());
    }

    [Fact]
    public void Update_Should_KeepOriginalTitle_When_NewTitleIsEmpty()
    {
        // Arrange
        Book originalBook = new Book("Original Title", "Original Author", "123", "Original Category");
        Book updatedBook = new Book("", "Updated Author", "123", "Updated Category");

        repository.AddBook(originalBook);

        // Act
        repository.Update(updatedBook);
        var book = repository.GetByISBN("123");

        // Assert
        Assert.Equal("Original Title", book.Title); // Titeln ska vara oförändrad
        Assert.Equal("Updated Author", book.Author); // Men andra fält ska vara uppdaterade
        Assert.Equal("Updated Category", book.Category);
    }


}
