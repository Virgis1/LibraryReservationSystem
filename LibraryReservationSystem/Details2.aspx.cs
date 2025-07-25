﻿using LibraryReservationSystem.Data;
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
            btnEdit.Visible = false;
            btnSave.Visible = true;
            BindDetails();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (dvBook.CurrentMode == DetailsViewMode.Edit)
            {
                TextBox txtTitle = (TextBox)dvBook.FindControl("txtTitle");
                TextBox txtDescription = (TextBox)dvBook.FindControl("txtDescription");
                CheckBox chkIsInStock = (CheckBox)dvBook.FindControl("chkIsInStock");

                int id = int.Parse(Request.QueryString["id"]);
                var book = BookRepository.GetBooks().FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    book.Title = txtTitle.Text;
                    book.Description = txtDescription.Text;
                    book.IsInStock = chkIsInStock.Checked;

                    BookRepository.UpdateBook(book);

                    dvBook.ChangeMode(DetailsViewMode.ReadOnly);
                    btnEdit.Visible = true;
                    btnSave.Visible = false;
                    BindDetails();
                }
            }
        }

        protected void dvBook_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dvBook.ChangeMode(e.NewMode);
            BindDetails();
        }
    }
}
