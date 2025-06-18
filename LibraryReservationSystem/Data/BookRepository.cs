using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryReservationSystem.Business;

namespace LibraryReservationSystem.Data
{
    public static class BookRepository
    {
        public static List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book { Title = "Netekę vilties", Author = "Colleen Hoover", Year = 2025 },
                new Book { Title = "Skandaras ir griaučių prakeiksmas. 4 knyga", Author = "A.F. Steadman", Year = 2022 },
                new Book { Title = "Nepaleisti 13. Tomeno vaikinai", Author = "Chloe Walsh", Year = 2025 },
                new Book { Title = "Keturi susitarimai. Toltekų išminties knyga", Author = "Don Miguel Ruiz", Year = 2024 },
                new Book { Title = "SKURDO VAIKAS", Author = "Katriona O’Sullivan", Year = 2025 },
                new Book { Title = "PENKIOS MEILĖS KALBOS", Author = "Gary Chapman", Year = 2022 },
                new Book { Title = "Prezidentas Gitanas Nausėda: iš arti", Author = "Laima Lavaste", Year = 2025 },
                new Book { Title = "LEBRONAS", Author = "Jeff Benedict", Year = 2025 }
            };
        }
    }
}