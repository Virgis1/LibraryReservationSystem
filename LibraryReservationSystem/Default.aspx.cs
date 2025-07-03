using LibraryReservationSystem.Data;
using System;
using System.Web.UI.WebControls;

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
            lvBooks.DataSource = BookRepository.GetBooks();
            lvBooks.DataBind();
        }

        protected void lvBooks_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {          
            DataPager dpBooks = lvBooks.FindControl("dpBooks") as DataPager;
            if (dpBooks != null)
            {
                dpBooks.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            }
            BindBooks();
        }
    }
}
