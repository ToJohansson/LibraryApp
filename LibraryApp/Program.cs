// See https://aka.ms/new-console-template for more information
Console.WriteLine("Library APP!");

List<Book> books = new List<Book>
            {
                new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "9780061120084", Category = "Fiction" },
                new Book { Title = "1984", Author = "George Orwell", ISBN = "9780451524935", Category = "Dystopian" },
                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "9780743273565", Category = "Classic" },
                new Book { Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "9780141439518", Category = "Romance" },
                new Book { Title = "Moby-Dick", Author = "Herman Melville", ISBN = "9781503280786", Category = "Adventure" },
                new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", ISBN = "9780345339683", Category = "Fantasy" },
                new Book { Title = "War and Peace", Author = "Leo Tolstoy", ISBN = "9781400079988", Category = "Historical" },
                new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", ISBN = "9780316769488", Category = "Coming-of-Age" },
                new Book { Title = "Brave New World", Author = "Aldous Huxley", ISBN = "9780060850524", Category = "Science Fiction" },
                new Book { Title = "The Brothers Karamazov", Author = "Fyodor Dostoevsky", ISBN = "9780374528379", Category = "Philosophical" }
            };

foreach (var book in books)
{
    Console.WriteLine(book);
}