using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Utils;
public static class Helpers
{
    public static string GetUserInputReturnAnswer(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public static string DisplayOptionsAndGetChoice(string title, List<string> options)
    {
        Console.Clear();
        Console.WriteLine(title);
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }
        Console.WriteLine("0. Return");
        Console.Write("Please choose an option: ");
        return Console.ReadLine();
    }


    public static void DisplayMessageAndWait(string message)
    {
        Console.WriteLine(message);
        Console.ReadKey();
    }
    public static void InvalidOption()
    {
        Console.WriteLine("Invalid option. Please try again.");
    }

    public static void DisplayBooks(IEnumerable<object> books)
    {
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
        Console.ReadKey();
    }
}
