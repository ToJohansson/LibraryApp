using Library.Core.Services;
using Library.InMemory;
using LibraryApp.Handlers;
using LibraryApp.Menues;
using Microsoft.Extensions.Logging;
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
        // Skapa loggern och injicera den i handlers
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddSimpleConsole(options =>
            {
                options.SingleLine = true;
                options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
            });
        });
        var logger = loggerFactory.CreateLogger<AppFactory>();

        var repository = new InMemoryBookRepository();
        SeedData.Initialize(repository); // add some data to work with
        var service = new LibraryService(repository);

        BookBorrowingHandler borrowingHandler = new BookBorrowingHandler(service, loggerFactory.CreateLogger<BookBorrowingHandler>());

        BookListingHandler listingHandler = new BookListingHandler(service, loggerFactory.CreateLogger<BookListingHandler>());

        BookManagementHandler managementHandler = new BookManagementHandler(service, loggerFactory.CreateLogger<BookManagementHandler>());

        ReportExportHandler reportExportHandler = new ReportExportHandler(listingHandler, loggerFactory.CreateLogger<ReportExportHandler>());

        var menu = new Menu(managementHandler, listingHandler, borrowingHandler, reportExportHandler);
        return new App(menu);
    }
}

