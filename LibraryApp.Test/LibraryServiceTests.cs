using Library.Core.Models;
using Library.Core.Services;
using Library.InMemory;

namespace LibraryApp.Test;

public class LibraryServiceTests
{
    private readonly LibraryService _libraryService;
    private readonly InMemoryBookRepository _bookRepository;
    const string _isbn = "ISBN12345";

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
    }

    [Fact]
    public void AddBook_ShouldThrowException_WhenTitleOrAuthorIsMissing()
    {
        // TODO
    }

    [Fact]
    public void AddBook_ShouldThrowException_WhenDuplicateISBN()
    {
        // TODO
    }

    // ListBooks(SortOrder)
    [Fact]
    public void ListBooks_ShouldReturnBooksSortedByTitle_WhenSortOrderIsTitle()
    {
        // TODO
    }

    [Fact]
    public void ListBooks_ShouldReturnBooksSortedByAuthor_WhenSortOrderIsAuthor()
    {
        // TODO
    }

    [Fact]
    public void ListBooks_ShouldReturnUnsortedBooks_WhenSortOrderIsNone()
    {
        // TODO
    }

    // ListBooks()
    [Fact]
    public void ListBooks_ShouldReturnAllBooks()
    {
        // TODO
    }

    // MarkAsBorrowed
    [Fact]
    public void MarkAsBorrowed_ShouldSetBookAsUnavailable_WhenBookExistsAndIsAvailable()
    {
        // TODO
    }

    [Fact]
    public void MarkAsBorrowed_ShouldThrowException_WhenBookDoesNotExist()
    {
        // TODO
    }

    [Fact]
    public void MarkAsBorrowed_ShouldNotChangeAvailability_WhenBookIsAlreadyBorrowed()
    {
        // TODO
    }

    // MarkAsReturned
    [Fact]
    public void MarkAsReturned_ShouldSetBookAsAvailable_WhenBookExists()
    {
        // TODO
    }

    [Fact]
    public void MarkAsReturned_ShouldThrowException_WhenBookDoesNotExist()
    {
        // TODO
    }

    // RemoveBook
    [Fact]
    public void RemoveBook_ShouldRemoveBook_WhenIdentifierMatchesISBNTitleOrAuthor()
    {
        // TODO
    }

    [Fact]
    public void RemoveBook_ShouldThrowException_WhenNoBookMatchesIdentifier()
    {
        // TODO
    }

    // SearchBooks
    [Fact]
    public void SearchBooks_ShouldReturnMatchingBooks_WhenQueryMatchesTitleAuthorOrISBN()
    {
        // TODO
    }

    [Fact]
    public void SearchBooks_ShouldReturnEmptyList_WhenNoBooksMatchQuery()
    {
        // TODO
    }
}
