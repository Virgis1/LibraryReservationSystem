using System.Collections.Generic;
using System.Linq;
using LibraryReservationSystem.Business;

namespace LibraryReservationSystem.Data
{
    public static class BookRepository
    {
        private static IList<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Netekę vilties", Author = "Colleen Hoover",
                Year = 2025, Description = "„Nepaprasta istorija apie meilę ir išlikimą...", IsInStock = false},
            new Book { Id = 2, Title = "Skandaras ir griaučių prakeiksmas. 4 knyga", Author = "A.F. Steadman", Year = 2022, Description = "2022 m. išleista britų rašytojos knyga...", IsInStock = false },
            new Book { Id = 3, Title = "Nepaleisti 13. Tomeno vaikinai", Author = "Chloe Walsh", Year = 2025, Description = "Įspūdinga ir nepamirštama meilės istorija..." },
            new Book { Id = 4, Title = "Keturi susitarimai. Toltekų išminties knyga", Author = "Don Miguel Ruiz", Year = 2024, Description = "Remdamasis senovės toltekų išmintimi...", IsInStock = false },
            new Book { Id = 5, Title = "SKURDO VAIKAS", Author = "Katriona O’Sullivan", Year = 2025, Description = "Stulbinamas asmeninis liudijimas..." , IsInStock = false },
            new Book { Id = 6, Title = "PENKIOS MEILĖS KALBOS", Author = "Gary Chapman", Year = 2022, Description = "Pagrindinis žmogaus emocinis poreikis..." },
            new Book { Id = 7, Title = "Prezidentas Gitanas Nausėda: iš arti", Author = "Laima Lavaste", Year = 2025, Description= "Išskirtinė galimybė pasinerti į..." , IsInStock = false },
            new Book { Id = 8, Title = "LEBRONAS", Author = "Jeff Benedict", Year = 2025, Description = "NEW YORK TIMES BESTSELERIS..." , IsInStock = false }
        };

        public static IList<Book> GetBooks()
        {
            return _books;
        }

        public static void UpdateBook(Book updatedBook)
        {
            var book = _books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Year = updatedBook.Year;
                book.Description = updatedBook.Description;
                book.IsInStock = updatedBook.IsInStock;
            }
        }
    }
}
