﻿using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LibraryApp.Utils;
using Microsoft.Extensions.Logging;

namespace LibraryApp.Handlers
{
    public class ReportExportHandler
    {
        private readonly BookListingHandler _listingHandler;
        private readonly ILogger<ReportExportHandler> _logger;
        public ReportExportHandler(BookListingHandler bookListingHandler, ILogger<ReportExportHandler> logger)
        {
            _listingHandler = bookListingHandler;
            _logger = logger;
        }

        /*
         * ExportBorrowedBooksReport
         * ----------------------------
         */
        public bool ExportBorrowedBooksReport()
        {
            try
            {
                // Steg 1: Hämta alla utlånade böcker
                var borrowedBooks = _listingHandler.UnSortedBooks()
                    .Where(b => b.IsAvailable == false)
                    .ToList();

                // Steg 2: Kontrollera om det finns några utlånade böcker
                if (!borrowedBooks.Any())
                {
                    _logger.LogInformation("No books has been checked out.");
                    return false;
                }

                // Steg 3: Skapa mappen om den inte finns
                CreateDirectory(out string folderPath);

                // Steg 4: Skapa filnamn
                var fileName = CreateFileName();
                var filePath = Path.Combine(folderPath, fileName);

                // Steg 5: Bygg rapportens innehåll
                var reportContent = BuildReportContent(borrowedBooks);

                // Steg 6: Skriv rapportinnehållet till fil
                return WriteReportToFile(filePath, reportContent);
            }
            catch (Exception ex)
            {
                // Steg 7: Hantera eventuella fel
                _logger.LogError(ex.Message);
                return false;
            }
        }

        private string CreateFileName()
        {
            // Skapa en tidsstämpel baserat på nuvarande datum och tid
            string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            return $"BorrowedBooksReport_{timeStamp}.txt";
        }

        private void CreateDirectory(out string folderPath)
        {
            // Determine the path for the "LibraryApp" directory
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string libraryAppDirectory = Path.Combine(currentDirectory, "..", "..", "..");

            // Resolve the absolute path to the "Reports" folder
            folderPath = Path.Combine(Path.GetFullPath(libraryAppDirectory), "Reports");

            try
            {
                // Kontrollera om mappen "Reports" finns, annars skapa den
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    _logger.LogInformation("Folder path [ {0} ] has been created.", folderPath);
                }
            }
            catch (Exception ex)
            {
                // Hantera fel om mappen inte kan skapas
                _logger.LogError(ex.Message);
            }
        }
        private string BuildReportContent(IEnumerable<Book> borrowedBooks)
        {
            // Skapa en StringBuilder för att bygga rapportinnehållet
            StringBuilder sb = new StringBuilder();

            // Lägg till rubriker för rapporten
            sb.AppendLine("Borrowed Books Report");
            sb.AppendLine($"Date: {DateTime.Now}");
            sb.AppendLine("-----------------------------------------------------------------------");

            // Iterera över varje bok i borrowedBooks och bygg rapportinnehållet
            foreach (var book in borrowedBooks)
            {
                sb.AppendLine($"Title: {book.Title}");
                sb.AppendLine($"Author: {book.Author}");
                sb.AppendLine($"ISBN: {book.ISBN}");
                sb.AppendLine($"Category: {book.Category}");
                sb.AppendLine("-----------------------------------------------------------------------");
            }

            // Returnera det sammanställda rapportinnehållet som en sträng
            return sb.ToString();
        }

        private bool WriteReportToFile(string filePath, string reportContent)
        {
            // Försök att skriva rapportens innehåll till filen
            try
            {
                // Skapa filvägen om den inte finns
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                // Skriv innehållet till filen
                File.WriteAllText(filePath, reportContent);
                _logger.LogInformation($"Report created at: {filePath}");
                return true;
            }
            catch (Exception ex)
            {
                // Hantera eventuella fel vid filskrivning
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
