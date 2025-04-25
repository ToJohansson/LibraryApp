using LibraryApp.Interfaces;
using System;
using Library.Core.Services;

namespace LibraryApp.Menues
{
    public class Menu : IMenu
    {
        private readonly LibraryService _libraryService;

        public Menu(LibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Library System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. List Books");
                Console.WriteLine("4. Search Books");
                Console.WriteLine("5. Exit");
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
                        ListBooks();
                        break;
                    case "4":
                        SearchBooks();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

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

            _libraryService.AddBook(title, author, isbn, category);
            Console.WriteLine("Book added successfully!");
            Console.ReadKey();
        }

        private void RemoveBook()
        {
            Console.Write("Enter Book ISBN to remove: ");
            var isbn = Console.ReadLine();
            _libraryService.RemoveBook(isbn);
            Console.WriteLine("Book removed successfully!");
            Console.ReadKey();
        }

        private void ListBooks()
        {
            Console.WriteLine("Listing all books...");
            var books = _libraryService.ListBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN})");
            }
            Console.ReadKey();
        }

        private void SearchBooks()
        {
            Console.Write("Enter search query (title, author, or ISBN): ");
            var query = Console.ReadLine();
            var books = _libraryService.SearchBooks(query);
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN})");
            }
            Console.ReadKey();
        }
    }
}


