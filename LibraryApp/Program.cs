using Library.Core.Enums;
using Library.Core.Interfaces;
using Library.Core.Models;
using Library.Core.Services;
using Library.InMemory;
using LibraryApp.Interfaces;
using LibraryApp;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        App app = new App();
        app.Run();
    }
}


