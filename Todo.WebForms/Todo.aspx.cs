using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Todo.WebForms
{
    public partial class Todo : System.Web.UI.Page
    {
        private Presenters.TodoPresenter _p = null;
        Presenters.TodoPresenter Presenter
        {
            get
            {
                if (_p == null)
                    _p = new Presenters.TodoPresenter();

                return _p;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Models.TodoViewModel vm =
                    this.Presenter.Intitialize();

                this.lblHeader.Text = vm.HeaderText;
                this.lblFooter.Text = vm.FooterText;
            }

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Models.Todo todo = new Models.Todo()
            {
                Description = this.txtDescription.Text
            };

            this.Presenter.CreateTodoItem(todo);
        }

        protected void grvTodo_PreRender(object sender, EventArgs e)
        {
            this.grvTodo.DataSource = this.Presenter.ReadTodos();
            this.grvTodo.DataBind(); 
        }

        protected void grvTodo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Boundaries.ITodoRequest row = e.Row.DataItem as Boundaries.ITodoRequest;

                if (row.Completed) e.Row.Cells[1].Style.Add("text-decoration", "line-through");

                Button edit = e.Row.Cells[2].FindControl("btnEdit") as Button;
                edit.Visible = this.grvTodo.EditIndex == -1;

                Button save = e.Row.Cells[2].FindControl("btnSave") as Button;
                save.Visible = this.grvTodo.EditIndex >= 0;
            }
        }

        protected void grvTodo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Models.Todo todo = new Models.Todo()
            {
                ID = (int)e.Keys["ID"]
            };

            this.Presenter.DeleteTodo(todo);
        }

        protected void grvTodo_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void grvTodo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Models.Todo todo = new Models.Todo()
            {
                ID = (int)e.Keys["ID"],
                Description = e.NewValues["Description"] as string,
                Completed = Convert.ToBoolean(e.NewValues["Completed"])
            };

            this.Presenter.UpdateTodo(todo);

            this.grvTodo.EditIndex = -1;
        }
    }
}