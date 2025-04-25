using Library.Core.Services;
using Library.InMemory;
using LibraryApp.Interfaces;
using LibraryApp.Menues;

namespace LibraryApp;

public class App
{

    public void Run()
    {
        var repository = new InMemoryBookRepository();
        var service = new LibraryService(repository);
        var menu = new Menu(service);
        menu.Display();
    }
}
