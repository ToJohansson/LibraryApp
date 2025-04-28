using LibraryApp.Interfaces;
using System;
using LibraryApp.Handlers;
using Library.Core.Enums;

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
                Console.Clear();
                Console.WriteLine("Welcome to the Library System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Update Book");
                Console.WriteLine("4. Search Books");
                Console.WriteLine("5. Borrow and Return books");
                Console.WriteLine("0. Exit");
                Console.Write("Please choose an option: ");
                var option = Console.ReadLine();

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
                Console.Clear();
                Console.WriteLine("Search Books");
                Console.WriteLine("1. Sort books by Title or Author");
                Console.WriteLine("2. Show all books");
                Console.WriteLine("3. Search books with common naming");
                Console.WriteLine("4. Search a specific Book");
                Console.WriteLine("5. Return");
                Console.Write("Please choose an option: ");
                var option = Console.ReadLine();

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
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void GetSingleBook()
        {
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();
            var book = _listingHandler.GetBook(isbn);
            Console.WriteLine((book == null ? $"No book with ISBN: [ {isbn} ] exists." : book));
            Console.ReadKey();
        }

        private void SortBooks()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Sort Books");
                Console.WriteLine("1. Sort by Title");
                Console.WriteLine("2. Sort by Author");

                Console.WriteLine("0. Return");
                Console.Write("Please choose an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var booksTitle = _listingHandler.SortedBooks(SortOrder.Title);
                        foreach (var b in booksTitle)
                        {
                            Console.WriteLine(b);
                        }
                        Console.ReadKey();
                        break;
                    case "2":
                        var booksAuthor = _listingHandler.SortedBooks(SortOrder.Author);
                        foreach (var b in booksAuthor)
                        {
                            Console.WriteLine(b);
                        }
                        Console.ReadKey();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
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
            Console.Write("Enter search query (title, author, or ISBN): ");
            var query = Console.ReadLine();
            var books = _listingHandler.BooksWithSearchString(query);
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
            Console.Write("Enter Title: ");
            var title = Console.ReadLine();
            Console.Write("Enter Author: ");
            var author = Console.ReadLine();
            Console.Write("Enter ISBN: ");
            var isbn = Console.ReadLine();
            Console.Write("Enter Category: ");
            var category = Console.ReadLine();

            Console.WriteLine(_managementHandler.AddBook(title, author, isbn, category)
                ? "Book added successfully!"
                : "Something went wrong.");
            Console.ReadKey();
        }
        private void RemoveBook()
        {
            Console.Write("Enter Book ISBN to remove: ");
            var isbn = Console.ReadLine();
            Console.WriteLine(_managementHandler.RemoveBook(isbn)
                ? "Book removed successfully!"
                : "Something went wrong.");
            Console.ReadKey();
        }
        private void UpdateBook()
        {
            Console.Write("Enter ISBN to update book: ");
            var isbn = Console.ReadLine();
            Console.Write("Enter Title: ");
            var title = Console.ReadLine();
            Console.Write("Enter Author: ");
            var author = Console.ReadLine();
            Console.Write("Enter Category: ");
            var category = Console.ReadLine();

            Console.WriteLine(_managementHandler.UpdateBook(title, author, isbn, category)
                 ? "Book updated successfully!"
                 : "Something went wrong.");
            Console.ReadKey();
        }
        #endregion

        #region Borrow and Return 
        private void BoorowAnndReturnBooks()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Borrow book");
                Console.WriteLine("2. Return book");

                Console.WriteLine("0. return");
                Console.Write("Please choose an option: ");
                var option = Console.ReadLine();

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
                        Console.WriteLine("Invalid option. Please try again.");
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


