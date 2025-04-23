using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models;
internal class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string Category { get; set; }

    public override string? ToString()
    {
        return $"{Title} | {Author} | {Category} | {ISBN} |";
    }
}

