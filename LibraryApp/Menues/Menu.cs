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

        private void GetSingleBook()
        {
            //string getIsbn = "Enter ISBN: ";
            string isbn = Helpers.GetUserInputReturnAnswer("Enter ISBN: ");
            var book = _listingHandler.GetBook(isbn);
            Console.WriteLine((book == null ? $"No book with ISBN: [ {isbn} ] exists." : book));
            Console.ReadKey();
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

        private void SortByAuthor()
        {
            var booksAuthor = _listingHandler.SortedBooks(SortOrder.Author);
            foreach (var b in booksAuthor)
            {
                Console.WriteLine(b);
            }
            Console.ReadKey();
        }

        private void SortByTitle()
        {
            var booksTitle = _listingHandler.SortedBooks(SortOrder.Title);
            foreach (var b in booksTitle)
            {
                Console.WriteLine(b);
            }
            Console.ReadKey();
        }

        private void ListBooks()
        {
            Console.WriteLine("Listing all books...");
            var books = _listingHandler.UnSortedBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author}, Category: {book.Category} \n" +
                                    $"(ISBN: {book.ISBN}) \n" +
                                 $"Availability: {(book.IsAvailable ? "Available" : "Borrowed")}" +
                                 "\n");
            }
            Console.ReadKey();
        }

        private void SearchBooksByQuery()
        {
            var books = _listingHandler.BooksWithSearchString(
                Helpers.GetUserInputReturnAnswer("Enter search query (title, author, or ISBN): "));
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN})");
            }
            Console.ReadKey();
        }
        #endregion

        #region Book management handler
        private void AddBook()
        {
            var title = Helpers.GetUserInputReturnAnswer("Enter Title: ");
            var author = Helpers.GetUserInputReturnAnswer("Enter Author: ");
            var isbn = Helpers.GetUserInputReturnAnswer("Enter ISBN: ");
            var category = Helpers.GetUserInputReturnAnswer("Enter Category: ");
            Helpers.DisplayMessageAndWait(_managementHandler.AddBook(title, author, isbn, category)
                ? "Book added successfully!"
                : "Something went wrong.");
        }
        private void RemoveBook()
        {
            var isbn = Helpers.GetUserInputReturnAnswer("Enter Book ISBN to remove: ");
            Helpers.DisplayMessageAndWait(_managementHandler.RemoveBook(isbn)
                ? "Book removed successfully!"
                : "Something went wrong.");
        }
        private void UpdateBook()
        {
            var isbn = Helpers.GetUserInputReturnAnswer("Enter ISBN to update book: ");
            var title = Helpers.GetUserInputReturnAnswer("Enter Title: ");
            var author = Helpers.GetUserInputReturnAnswer("Enter Author: ");
            var category = Helpers.GetUserInputReturnAnswer("Enter Category: ");

            Helpers.DisplayMessageAndWait(_managementHandler.UpdateBook(title, author, isbn, category)
                 ? "Book updated successfully!"
                 : "Something went wrong.");
        }
        #endregion

        #region Borrow and Return 
        private void BoorowAnndReturnBooks()
        {
            while (true)
            {
                var options = new List<string>
                {
                    "Borrow book",
                    "Return book"
                };
                var option = Helpers.DisplayOptionsAndGetChoice("Borrow or Return Book", options);
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
            Console.Write("Enter ISBN: ");
            var returnIsbn = Console.ReadLine();
            Console.WriteLine(_borrowingHandler.ReturnBook(returnIsbn)
                ? $"You have returned book with ISBN: {returnIsbn}"
                : "Something went wrong.");
            Console.ReadKey();
        }

        private void BorrowBook()
        {
            Console.Write("Enter ISBN: ");
            var borrowIsbn = Console.ReadLine();
            Console.WriteLine(_borrowingHandler.BorrowBook(borrowIsbn)
                ? $"You have borrowed book with ISBN: {borrowIsbn}"
                : "Something went wrong.");
            Console.ReadKey();
        }
        #endregion
    }
}


