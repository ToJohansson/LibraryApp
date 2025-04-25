using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Handlers;
public class BookListingHandler
{
    private readonly LibraryService _service;
    public BookListingHandler(LibraryService libraryService)
    {
        _service = libraryService;
    }
}
