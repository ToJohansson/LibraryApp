📚 LibraryApp
Ett konsolprogram i C# för att hantera ett bibliotekssystem – där användare kan:

Lägga till, ta bort och uppdatera böcker.

Söka och sortera bland böcker.

Låna och lämna tillbaka böcker.

All konsolhantering är samlad i en Utils/Helpers-klass för att göra programmet mer enhetligt och lättare att underhålla.

🚀 Hur man kör programmet
Klona projektet eller ladda ner koden till din dator.

Öppna projektet i din IDE (Visual Studio, Rider eller VS Code).

Bygg projektet (Build).

Kör programmet (dotnet run i terminalen eller tryck på "Start" i din IDE).

Du kommer att mötas av huvudmenyn:
Welcome to the Library System
1. Add Book
2. Remove Book
3. Update Book
4. Search Books
5. Borrow and Return books
0. Exit
Please choose an option:
Navigera genom menyerna genom att skriva siffrorna och följa instruktionerna.

🛠 Projektstruktur
LibraryApp/Interfaces/IMenu.cs – Interface för menyer.

LibraryApp/Menues/Menu.cs – Huvudmeny och undermenyer.

LibraryApp/Handlers/BookManagementHandler.cs – Lägga till, ta bort, uppdatera böcker.

LibraryApp/Handlers/BookListingHandler.cs – Söka, lista och sortera böcker.

LibraryApp/Handlers/BookBorrowingHandler.cs – Låna och returnera böcker.

LibraryApp/Utils/Helpers.cs – All konsolutskrift och användarinput (DRY-princip).

✅ Vad som är testat och klart
Menysystem – Flera nivåer av menyer fungerar som förväntat.

Bokhantering – Lägga till, ta bort och uppdatera böcker testat och fungerar.

Sökfunktioner – Söka böcker via titel, författare eller ISBN fungerar korrekt.

Sorteringsfunktioner – Sortera på titel och författare fungerar.

Lån/Returnering – Kan låna och lämna tillbaka böcker med korrekt meddelande.

Felhantering – Ogiltiga val hanteras och visar "Invalid option" istället för att krascha.

DRY-kodprincip – All input och output är centraliserad via Helpers.cs.

Null-säkring – Vid sökningar hanteras null korrekt (om bok ej finns).

Console.Clear() – Menyer och val rensar skärmen för bättre läsbarhet.
