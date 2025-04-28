using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models;
public record Book
{

    public Book()
    {

    }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string Category { get; set; }
    public bool IsAvailable { get; set; }
    public Book(string title, string author, string isbn, string category, bool isAvaiable = true)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Category = category;
        IsAvailable = isAvaiable;
    }
    public override string ToString()
    {
        return $"Title: {Title}\n" +
           $"Author: {Author}\n" +
           $"ISBN: {ISBN}\n" +
           $"Category: {Category}\n" +
           $"Status: {(IsAvailable ? "Available" : "Checked Out")}";
    }
}

