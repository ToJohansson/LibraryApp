using LibraryApp.Interfaces;
using System;
using LibraryApp.Handlers;
using Library.Core.Enums;
using LibraryApp.Utils;
using System.Diagnostics.Metrics;

namespace LibraryApp.Menues
{
    public class Menu : IMenu
    {
        private readonly BookManagementHandler _managementHandler;
        private readonly BookListingHandler _listingHandler;
        private readonly BookBorrowingHandler _borrowingHandler;

        public Menu(BookManagementHandler bookManagementHandler, BookListingHandler bookListingHandler, BookBorrowingHandler bookBorrowingHandler)
        {
            _managementHandler = bookManagementHandler;
            _listingHandler = bookListingHandler;
            _borrowingHandler = bookBorrowingHandler;
        }
        #region MAIN MENU:

        public void Display()
        {
            while (true)
            {
                var options = new List<string>
                {
                    "Add Book",
                    "Remove Book",
                    "Update Book",
                    "Search Books",
                    "Borrow and Return books"
                };
                var option = Helpers.DisplayOptionsAndGetChoice("Welcome to the Library System", options);

                switch (option)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        RemoveBook();
                        break;
                    case "3":
                        UpdateBook();
                        break;
                    case "4":
                        SearchBooks();
                        break;
                    case "5":
                        BoorowAnndReturnBooks();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        #endregion

        #region MENU FOR/AND BOOK LISTING HANDLER METHODS
        private void SearchBooks()
        {
            while (true)
            {
                var options = new List<string>
                {
                    "Sort books by Title or Author",
                    "Show all books",
                    "Search books with common naming",
                    "Search a specific Book"
                };
                var option = Helpers.DisplayOptionsAndGetChoice("Search Books", options);
                switch (option)
                {
                    case "1":
                        SortBooks();
                        break;
                    case "2":
                        ListBooks();
                        break;
                    case "3":
                        SearchBooksByQuery();
                        break;
                    case "4":
                        GetSingleBook();
                        break;
                    case "0":
                        return;
                    default:
                        Helpers.InvalidOption();
                        break;
                }
            }
        }


        private void SortBooks()
        {
            while (true)
            {
                var options = new List<string>
                {
                    "Sort by Title",
                    "Sort by Author"
                };
                var option = Helpers.DisplayOptionsAndGetChoice("Sort Books", options);
                switch (option)
                {
                    case "1":
                        SortByTitle();
                        break;
                    case "2":
                        SortByAuthor();
                        break;
                    case "0":
                        return;
                    default:
                        Helpers.InvalidOption();
                        break;
                }
            }
        }
        private void GetSingleBook()
        {
            Helpers.GetBookAndDisplay(Helpers.GetUserInput("Enter ISBN: "), _listingHandler.GetBook);
        }

        private void SortByAuthor()
        {
            var booksAuthor = _listingHandler.SortedBooks(SortOrder.Author);
            Helpers.DisplayBooks(booksAuthor);
        }

        private void SortByTitle()
        {
            var booksTitle = _listingHandler.SortedBooks(SortOrder.Title);
            Helpers.DisplayBooks(booksTitle);
        }

        private void ListBooks()
        {
            var books = _listingHandler.UnSortedBooks();
            Helpers.DisplayBooks(books);
        }

        private void SearchBooksByQuery()
        {
            var books = _listingHandler.BooksWithSearchString(
                Helpers.GetUserInput("Enter search query (title, author, or ISBN): "));
            Helpers.DisplayBooks(books);
        }
        #endregion

        #region Book management handler
        private void AddBook()
        {
            var title = Helpers.GetUserInput("Enter Title: ");
            var author = Helpers.GetUserInput("Enter Author: ");
            var isbn = Helpers.GetUserInput("Enter ISBN: ");
            var category = Helpers.GetUserInput("Enter Category: ");
            var result = _managementHandler.AddBook(title, author, isbn, category);
            Helpers.DisplayActionResult(result, "Book added successfully!", "Something went wrong.");

        }
        private void RemoveBook()
        {
            var isbn = Helpers.GetUserInput("Enter Book ISBN to remove: ");
            var result = _managementHandler.RemoveBook(isbn);
            Helpers.DisplayActionResult(result, "Book removed successfully!", "Something went wrong");
        }
        private void UpdateBook()
        {
            var isbn = Helpers.GetUserInput("Enter ISBN to update book: ");
            var title = Helpers.GetUserInput("Enter Title: ");
            var author = Helpers.GetUserInput("Enter Author: ");
            var category = Helpers.GetUserInput("Enter Category: ");
            var result = _managementHandler.AddBook(title, author, isbn, category);
            Helpers.DisplayActionResult(result, "Book updated successfully!", "Something went wrong.");
        }
        #endregion

        #region Borrow and Return 
        private void BoorowAnndReturnBooks()
        {
            while (true)
            {
                var options = new List<string>
                {
                    "Check out book",
                    "Return book"
                };
                var option = Helpers.DisplayOptionsAndGetChoice("Check out or Return Book", options);
                switch (option)
                {
                    case "1":
                        BorrowBook();
                        break;
                    case "2":
                        ReturnBook();
                        break;
                    case "0":
                        return;
                    default:
                        Helpers.InvalidOption();
                        break;
                }
            }
        }

        private void ReturnBook()
        {
            var returnIsbn = Helpers.GetUserInput("Enter ISBN: ");
            var result = _borrowingHandler.ReturnBook(returnIsbn);
            Helpers.DisplayActionResult(result, $"You have returned book with ISBN: {returnIsbn}", "Something went wrong");
        }

        private void BorrowBook()
        {
            var borrowIsbn = Helpers.GetUserInput("Enter ISBN: ");
            var result = _borrowingHandler.BorrowBook(borrowIsbn);
            Helpers.DisplayActionResult(result, $"Book with ISBN: {borrowIsbn}, is now checked out", "Something went wrong.");
        }
        #endregion
    }
}


