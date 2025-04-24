using Library.Core.Enums;
using Library.Core.Models;
using Library.Core.Services;
using Library.InMemory;

namespace LibraryApp.Test;

public class LibraryServiceTests
{
    private readonly LibraryService _libraryService;
    private readonly InMemoryBookRepository _bookRepository;
    private string _isbn = "ISBN12345";

    public LibraryServiceTests()
    {
        _bookRepository = new InMemoryBookRepository();
        _libraryService = new LibraryService(_bookRepository);
    }

    // AddBook
    [Fact]
    public void AddBook_ShouldAddBook_WhenValidDataProvided()
    {
        // TODO
        _libraryService.AddBook("Test", "Test", _isbn, "test");
        Assert.Single(_libraryService.ListBooks());
    }

    [Fact]
    public void AddBook_ShouldThrowException_WhenTitleOrAuthorIsMissing()
    {
        // Arrange 
        Action actEmptyTitle = () => _libraryService.AddBook("", "author", "isbn", "category");
        Action actEmptyAuthor = () => _libraryService.AddBook("title", "", "isbn", "category");
        Action actEmptyIsbn = () => _libraryService.AddBook("title", "author", "", "category");
        Action actEmptyCategory = () => _libraryService.AddBook("title", "author", "isbn", "");
        //act
        ArgumentException exceptionEmptyTitle = Assert.Throws<ArgumentException>(actEmptyTitle);
        ArgumentException exceptionEmptyAuthor = Assert.Throws<ArgumentException>(actEmptyAuthor);
        ArgumentException exceptionEmptyIsbn = Assert.Throws<ArgumentException>(actEmptyIsbn);
        ArgumentException exceptionEmptyCategory = Assert.Throws<ArgumentException>(actEmptyCategory);
        //assert
        Assert.Equal("Title, author, isbn and category is needed.", exceptionEmptyTitle.Message);
        Assert.Equal("Title, author, isbn and category is needed.", exceptionEmptyAuthor.Message);
        Assert.Equal("Title, author, isbn and category is needed.", exceptionEmptyIsbn.Message);
        Assert.Equal("Title, author, isbn and category is needed.", exceptionEmptyCategory.Message);
    }

    [Fact]
    public void AddBook_ShouldThrowException_WhenDuplicateISBN()
    {
        _libraryService.AddBook("test", "test", "test", "test");
        Action action = () => _libraryService.AddBook("test", "test", "test", "test");
        ArgumentException exception = Assert.Throws<ArgumentException>(action);
        Assert.Equal("A book with this isbn number already exists.", exception.Message);

    }

    // ListBooks(SortOrder)
    [Fact]
    public void ListBooks_ShouldReturnBooksSortedByTitle_WhenSortOrderIsTitle()
    {
        _libraryService.AddBook("Ctest", "test", "test1", "test");
        _libraryService.AddBook("Btest", "test", "test2", "test");
        _libraryService.AddBook("Atest", "test", "test3", "test");
        var sorted = _libraryService.ListBooks(SortOrder.Title).ToArray();
        Assert.NotEmpty(sorted);
        Assert.Equal("Atest", sorted[0].Title);
    }

    [Fact]
    public void ListBooks_ShouldReturnBooksSortedByAuthor_WhenSortOrderIsAuthor()
    {
        _libraryService.AddBook("Atest", "C", "test1", "test");
        _libraryService.AddBook("Btest", "B", "test2", "test");
        _libraryService.AddBook("Ctest", "A", "test3", "test");
        var sorted = _libraryService.ListBooks(SortOrder.Author).ToArray();
        Assert.NotEmpty(sorted);
        Assert.Equal("A", sorted[0].Author);
    }

    [Fact]
    public void ListBooks_ShouldReturnUnsortedBooks_WhenSortOrderIsNone()
    {
        // TODO
        _libraryService.AddBook("Atest", "C", "test1", "test");
        _libraryService.AddBook("Btest", "B", "test2", "test");
        _libraryService.AddBook("Ctest", "A", "test3", "test");
        var sorted = _libraryService.ListBooks().ToArray();
        Assert.NotEmpty(sorted);
        Assert.Equal("C", sorted[0].Author);
        Assert.Equal("B", sorted[1].Author);
        Assert.Equal("A", sorted[2].Author);
    }

    // MarkAsBorrowed
    [Fact]
    public void MarkAsBorrowed_ShouldSetBookAsUnavailable_WhenBookExistsAndIsAvailable()
    {
        _libraryService.AddBook("test", "test", "test", "test");
        _libraryService.MarkAsBorrowed("test");
        var mock = _libraryService.GetBook("test");
        Assert.False(mock.IsAvailable);

    }

    // MarkAsReturned
    [Fact]
    public void MarkAsReturned_ShouldSetBookAsAvailable_WhenBookExists()
    {
        _libraryService.AddBook("test", "test", "test", "test");
        _libraryService.MarkAsBorrowed("test");
        _libraryService.MarkAsReturned("test");
        var mock = _libraryService.GetBook("test");
        Assert.True(mock.IsAvailable);
    }

    // RemoveBook
    [Fact]
    public void RemoveBook_ShouldRemoveBook_WhenIdentifierMatchesISBNTitleOrAuthor()
    {
        _libraryService.AddBook("Ctest", "test", "test", "test");
        var book = _libraryService.GetBook("test");
        _libraryService.RemoveBook("test");
        Assert.DoesNotContain(book, _libraryService.ListBooks());
    }

    // SearchBooks
    [Fact]
    public void SearchBooks_ShouldReturnMatchingBooks_WhenQueryMatchesTitleAuthorOrISBN()
    {
        _libraryService.AddBook("A", "A", "A", "A");
        _libraryService.AddBook("B", "B", "B", "B");
        _libraryService.AddBook("A", "A", "C", "A");
        var result = _libraryService.SearchBooks("A");

        Assert.Equal(2, result.Count());  // Förväntar sig 2 böcker som matchar
        Assert.All(result, book =>
        {
            Assert.Contains("A", book.Title, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("A", book.Author, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("A", book.Category, StringComparison.OrdinalIgnoreCase);
        });

    }

}
