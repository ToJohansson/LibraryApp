using Library.Core.Services;
using Library.InMemory;
using LibraryApp.Interfaces;
using LibraryApp.Menues;

namespace LibraryApp.AppControl;

public class App
{
    private readonly Menu _menu;

    public App(Menu menu)
    {
        _menu = menu;
    }

    public void Run()
    {
        _menu.Display();
    }
}
