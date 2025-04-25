using Library.Core.Services;
using Library.InMemory;
using LibraryApp.Handlers;
using LibraryApp.Menues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.AppControl;
internal class AppFactory
{
    public static App CreateApp()
    {
        var repository = new InMemoryBookRepository();
        var service = new LibraryService(repository);

        BookBorrowingHandler borrowingHandler = new BookBorrowingHandler(service);
        BookListingHandler listingHandler = new BookListingHandler(service);
        BookManagementHandler managementHandler = new BookManagementHandler(service);

        var menu = new Menu(managementHandler, listingHandler, borrowingHandler);
        return new App(menu);
    }
}
