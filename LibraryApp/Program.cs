using Library.Core.Enums;
using Library.Core.Interfaces;
using Library.Core.Models;
using Library.Core.Services;
using Library.InMemory;
using LibraryApp.Interfaces;
using System.Text;
using LibraryApp.AppControl;

class Program
{
    static void Main(string[] args)
    {
        var app = AppFactory.CreateApp();
        app.Run();
    }
}


