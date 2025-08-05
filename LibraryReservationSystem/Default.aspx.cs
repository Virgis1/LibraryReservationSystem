using LibraryReservationSystem.Data;
using System;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace LibraryReservationSystem
{
    public partial class _Default : System.Web.UI.Page
    {

        private static readonly IBookRepository _repository;

        static _Default()
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

        protected override void InitializeCulture()
        {
            string selectedCulture = Request.QueryString["lang"];

            if (string.IsNullOrEmpty(selectedCulture))
            {
                selectedCulture = Request.UserLanguages != null && Request.UserLanguages.Length > 0
                    ? Request.UserLanguages[0]
                    : "lt-LT";
            }

            try
            {
                var cultureInfo = new System.Globalization.CultureInfo(selectedCulture);
                System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }
            catch
            {
                var ci = new System.Globalization.CultureInfo("lt-LT");
                System.Threading.Thread.CurrentThread.CurrentCulture = ci;
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            }

            base.InitializeCulture();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rfvTitle.ErrorMessage = GetLocalResourceObject("TitleRequired")?.ToString() ?? rfvTitle.ErrorMessage;

                BindBooks(true);
            }
        }

        private void BindBooks(bool resetPageIndex = false)
        {
            var books = _repository.GetBooks();

            // ✅ Filter results if search text entered
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string searchTerm = txtSearch.Text.Trim().ToLower();
                books = books
                    .Where(b =>
                        (!string.IsNullOrEmpty(b.Title) && b.Title.ToLower().Contains(searchTerm)) ||
                        (!string.IsNullOrEmpty(b.Author) && b.Author.ToLower().Contains(searchTerm)) ||
                        b.Year.ToString().Contains(searchTerm))
                    .ToList();
            }

            // ✅ Apply sorting
            books = (SortDirection == "ASC")
                ? books.OrderBy(b => GetPropertyValue(b, SortExpression)).ToList()
                : books.OrderByDescending(b => GetPropertyValue(b, SortExpression)).ToList();

            if (books.Count == 0)
            {
                lvBooks.DataSource = null;
                lvBooks.DataBind();

                var dpBooksEmpty = lvBooks.FindControl("dpBooks") as DataPager;
                if (dpBooksEmpty != null)
                {
                    dpBooksEmpty.Visible = false;
                }
                return;
            }

            lvBooks.DataSource = books;
            lvBooks.DataBind();

            var dpBooks = lvBooks.FindControl("dpBooks") as DataPager;
            if (dpBooks != null)
            {
                dpBooks.PageSize = ItemsPerPage;
                dpBooks.Visible = true;

                if (resetPageIndex)
                {
                    dpBooks.SetPageProperties(0, ItemsPerPage, true);
                }
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
            if (!Page.IsValid)
                return;

            var newBook = new LibraryReservationSystem.Business.Book
            {
                Title = txtTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Year = int.TryParse(txtYear.Text.Trim(), out int y) ? y : DateTime.Now.Year,
                Description = txtDescription.Text.Trim(),
                IsInStock = chkIsInStock.Checked
            };

            _repository.AddBook(newBook);

            pnlAddBookForm.Visible = false;
            btnShowAddForm.Visible = true;
            ClearForm();

            Response.Redirect(Request.Url.AbsoluteUri);
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

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    BindBooks(true);
        //}

        //protected void btnClearSearch_Click(object sender, EventArgs e)
        //{
        //    txtSearch.Text = string.Empty;
        //    BindBooks(true);
        //}

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            var books = _repository.GetBooks()
                .Where(b =>
                    (!string.IsNullOrEmpty(b.Title) && b.Title.ToLower().Contains(searchText)) ||
                    (!string.IsNullOrEmpty(b.Author) && b.Author.ToLower().Contains(searchText)) ||
                    (b.Year.ToString().Contains(searchText))
                )
                .ToList();

            lvBooks.DataSource = books;
            lvBooks.DataBind();
        }


    }


}
