using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Handlers;
public class BookManagementHandler
{
    private readonly LibraryService _service;

    public BookManagementHandler(LibraryService libraryService)
    {
        _service = libraryService;
    }
}
