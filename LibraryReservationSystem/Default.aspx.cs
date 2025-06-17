using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace LibraryReservationSystem
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            dgBooks.DataSource = GetBooks();
            dgBooks.DataBind();
        }

        protected void dgBooks_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgBooks.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        private List<Book> GetBooks()
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

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
        }
    }
}