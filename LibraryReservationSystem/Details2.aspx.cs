using LibraryReservationSystem.Data;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace LibraryReservationSystem
{
    public partial class Details2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDetails();
            }
        }

        private void BindDetails()
        {
            if (int.TryParse(Request.QueryString["id"], out int id))
            {
                var book = BookRepository.GetBooks().FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    dvBook.DataSource = new[] { book };
                    dvBook.DataBind();
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            dvBook.ChangeMode(DetailsViewMode.Edit);
            BindDetails();
        }

        protected void dvBook_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dvBook.ChangeMode(e.NewMode);
            BindDetails();
        }
    }
}
