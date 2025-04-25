using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Handlers;
public class BookBorrowingHandler
{
    private readonly LibraryService _service;
    public BookBorrowingHandler(LibraryService libraryService)
    {
        _service = libraryService;
    }
}
