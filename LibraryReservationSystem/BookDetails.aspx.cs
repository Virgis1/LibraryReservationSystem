using LibraryReservationSystem.Business;
using LibraryReservationSystem.Data;
using System;
using System.Configuration;
using System.Linq;

namespace LibraryReservationSystem
{
    public partial class BookDetails : System.Web.UI.Page
    {
        private readonly IBookRepository _repository;

        // Constructor to initialize repository based on Web.config setting
        public BookDetails()
        {
            string repoType = ConfigurationManager.AppSettings["RepositoryType"];
            if (!string.IsNullOrEmpty(repoType) && repoType.Equals("File", StringComparison.OrdinalIgnoreCase))
            {
                _repository = new FileBookRepository();
            }
            else
            {
                _repository = new InMemoryBookRepository();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.QueryString["id"], out int id))
                {
                    var book = _repository.GetBooks().FirstOrDefault(b => b.Id == id);
                    if (book != null)
                    {
                        lblTitle.Text = book.Title;
                        lblAuthor.Text = book.Author;
                        lblYear.Text = book.Year.ToString();
                        lblDescription.Text = book.Description;
                        lblIsInStock.Text = book.IsInStock ? "Taip" : "Ne";
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
