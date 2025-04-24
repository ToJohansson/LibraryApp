using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Test;
internal class InMemoryBookRepositoryTests
{
    // AddBook
    [Fact]
    public void AddBook_ShouldAddBook_WhenISBNIsUnique()
    {
        // TODO
    }

    [Fact]
    public void AddBook_ShouldThrowException_WhenISBNAlreadyExists()
    {
        // TODO
    }

    // GetAllBooks
    [Fact]
    public void GetAllBooks_ShouldReturnAllBooks()
    {
        // TODO
    }

    // GetByISBN
    [Fact]
    public void GetByISBN_ShouldReturnBook_WhenISBNExists()
    {
        // TODO
    }

    [Fact]
    public void GetByISBN_ShouldReturnNull_WhenISBNDoesNotExist()
    {
        // TODO
    }

    // RemoveBook
    [Fact]
    public void RemoveBook_ShouldRemoveBook_WhenBookExists()
    {
        // TODO
    }

    [Fact]
    public void RemoveBook_ShouldNotThrow_WhenBookDoesNotExist()
    {
        // TODO
    }

    // Search
    [Fact]
    public void Search_ShouldReturnMatchingBooks_WhenQueryMatchesTitle()
    {
        // TODO
    }

    [Fact]
    public void Search_ShouldReturnMatchingBooks_WhenQueryMatchesAuthor()
    {
        // TODO
    }

    [Fact]
    public void Search_ShouldReturnMatchingBooks_WhenQueryMatchesISBN()
    {
        // TODO
    }

    [Fact]
    public void Search_ShouldReturnEmpty_WhenNoMatches()
    {
        // TODO
    }

    // Update
    [Fact]
    public void Update_Should_UpdateTitle_When_NewTitleIsProvided()
    {
        // TODO
    }

    [Fact]
    public void Update_Should_KeepOriginalTitle_When_NewTitleIsEmpty()
    {
        // TODO
    }

    [Fact]
    public void Update_Should_KeepOriginalAuthor_When_NewAuthorIsNullOrWhitespace()
    {
        // TODO
    }

    [Fact]
    public void Update_Should_KeepOriginalCategory_When_NewCategoryIsEmpty()
    {
        // TODO
    }

    [Fact]
    public void Update_Should_NotChangeAnything_When_BookDoesNotExist()
    {
        // TODO
    }

    [Fact]
    public void Update_Should_ThrowArgumentNullException_When_UpdatedBookIsNull()
    {
        // TODO
    }
}
