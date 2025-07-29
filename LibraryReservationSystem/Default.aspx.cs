using LibraryReservationSystem.Data;
using System;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace LibraryReservationSystem
{
    public partial class _Default : System.Web.UI.Page
    {
        private string SortExpression
        {
            get => ViewState["SortExpression"] as string ?? "Title";
            set => ViewState["SortExpression"] = value;
        }

        private string SortDirection
        {
            get => ViewState["SortDirection"] as string ?? "ASC";
            set => ViewState["SortDirection"] = value;
        }

        private int ItemsPerPage
        {
            get
            {
                int pageSize = 5;
                int.TryParse(ConfigurationManager.AppSettings["BooksPageSize"], out pageSize);
                return pageSize;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBooks();
            }
        }

        private void BindBooks()
        {
            var books = BookRepository.GetBooks();

            books = (SortDirection == "ASC")
                ? books.OrderBy(b => GetPropertyValue(b, SortExpression)).ToList()
                : books.OrderByDescending(b => GetPropertyValue(b, SortExpression)).ToList();

            lvBooks.DataSource = books;
            lvBooks.DataBind();

            var dpBooks = lvBooks.FindControl("dpBooks") as DataPager;
            if (dpBooks != null)
            {
                dpBooks.PageSize = ItemsPerPage;
            }
        }

        private object GetPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }

        protected void lvBooks_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            var dpBooks = lvBooks.FindControl("dpBooks") as DataPager;
            if (dpBooks != null)
            {
                dpBooks.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            }
            BindBooks();
        }

        protected void lvBooks_Sorting(object sender, ListViewSortEventArgs e)
        {
            if (SortExpression == e.SortExpression)
                SortDirection = (SortDirection == "ASC") ? "DESC" : "ASC";
            else
            {
                SortExpression = e.SortExpression;
                SortDirection = "ASC";
            }

            BindBooks();
        }

        protected void btnShowAddForm_Click(object sender, EventArgs e)
        {
            pnlAddBookForm.Visible = true;
            btnShowAddForm.Visible = false;
        }

        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            var newBook = new LibraryReservationSystem.Business.Book
            {
                Title = txtTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Year = int.TryParse(txtYear.Text.Trim(), out int y) ? y : DateTime.Now.Year,
                Description = txtDescription.Text.Trim(),
                IsInStock = chkIsInStock.Checked
            };

            BookRepository.AddBook(newBook);

            pnlAddBookForm.Visible = false;
            btnShowAddForm.Visible = true;
            ClearForm();
            BindBooks();
        }

        protected void btnCancelAdd_Click(object sender, EventArgs e)
        {
            pnlAddBookForm.Visible = false;
            btnShowAddForm.Visible = true;
            ClearForm();
        }

        private void ClearForm()
        {
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtYear.Text = "";
            txtDescription.Text = "";
            chkIsInStock.Checked = false;
        }
    }
}
