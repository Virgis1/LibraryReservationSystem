using LibraryReservationSystem.Data;
using System;
using System.Configuration;
using System.Web.UI;

namespace LibraryReservationSystem.Controls
{
    public partial class BookCount : System.Web.UI.UserControl
    {
        private readonly IBookRepository _repository;

        public BookCount()
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
                var books = _repository.GetBooks();
                lblBookCount.Text = "Knygų skaičius: " + books.Count;
            }
        }
    }
}
