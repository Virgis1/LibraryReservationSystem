using LibraryReservationSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryReservationSystem.Controls
{
    public partial class BookCount : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Optional, but prevents reloading every time
            {
                var books = BookRepository.GetBooks();
                lblBookCount.Text = "Knygų skaičius: " + books.Count;
            }
        }
    }
}