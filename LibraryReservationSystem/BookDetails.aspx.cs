using LibraryReservationSystem.Business;
using LibraryReservationSystem.Data;
using System;
using System.Linq;

namespace LibraryReservationSystem
{
    public partial class BookDetails : System.Web.UI.Page
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
                        lblTitle.Text = book.Title;
                        lblAuthor.Text = book.Author;
                        lblYear.Text = book.Year.ToString();
                        lblDescription.Text = book.Description;
                    }
                    else
                    {
                        lblTitle.Text = "Book not found.";
                    }
                }
            }
        }
    }
}
