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
public class AppFactory
{
    public static App CreateApp()
    {
        var repository = new InMemoryBookRepository();
        SeedData.Initialize(repository); // add some data to work with
        var service = new LibraryService(repository);

        BookBorrowingHandler borrowingHandler = new BookBorrowingHandler(service);
        BookListingHandler listingHandler = new BookListingHandler(service);
        BookManagementHandler managementHandler = new BookManagementHandler(service);

        ReportExportHandler reportExportHandler = new ReportExportHandler(listingHandler);

        var menu = new Menu(managementHandler, listingHandler, borrowingHandler, reportExportHandler);
        return new App(menu);
    }
}
