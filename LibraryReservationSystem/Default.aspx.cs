using System;
using System.Web.UI.WebControls;
using LibraryReservationSystem.Data;

namespace LibraryReservationSystem
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBooks();
            }
        }

        private void BindBooks()
        {
            dgBooks.DataSource = BookRepository.GetBooks();
            dgBooks.DataBind();
        }

        protected void dgBooks_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgBooks.CurrentPageIndex = e.NewPageIndex;
            BindBooks();
        }
    }
}
