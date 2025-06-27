using LibraryReservationSystem.Business;
using LibraryReservationSystem.Data;
using System;
using System.Linq;

namespace LibraryReservationSystem
{
    public partial class Details2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id;
                if (int.TryParse(Request.QueryString["id"], out id))
                {
                    var book = BookRepository.GetBooks().FirstOrDefault(b => b.Id == id);
                    if (book != null)
                    {
                        
                        lblAuthor.Text = book.Author;
                    
                    }
                    else
                    {
                        lblAuthor.Text = "Book not found.";
                    }
                }
            }
        }
    }
}
