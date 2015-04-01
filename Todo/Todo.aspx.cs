using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Todo
{
    public partial class Todo : System.Web.UI.Page, Boundaries.ITodo
    {
        private Presenters.Todo _p = null;
        Presenters.Todo Presenter
        {
            get
            {
                if (_p == null)
                    _p = new Presenters.Todo(this);

                return _p;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ViewModels.TodoViewModel vm = 
                    this.Presenter.Intitialize();

                this.lblHeader.Text = vm.HeaderText;
                this.lblFooter.Text = vm.FooterTest;
            }
            
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            this.TodoItem = new Models.TodoItem()
            {
                Description = this.txtDescription.Text
            };

            this.Presenter.CreateTodoItem();
        }

        protected void grvTodo_PreRender(object sender, EventArgs e)
        {
            this.Presenter.ReadTodos();
        }

        protected void grvTodo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.TodoItem row = e.Row.DataItem as Models.TodoItem;

                if (row.Completed) e.Row.Cells[1].Style.Add("text-decoration", "line-through");

                Button edit = e.Row.Cells[2].FindControl("btnEdit") as Button;
                edit.Visible = this.grvTodo.EditIndex == -1;

                Button save = e.Row.Cells[2].FindControl("btnSave") as Button;
                save.Visible = this.grvTodo.EditIndex >= 0;
            }
        }

        protected void grvTodo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            this.TodoItem = new Models.TodoItem()
            {
                ID = (int)e.Keys["ID"]
            };

            this.Presenter.DeleteTodo();
        }

        protected void grvTodo_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void grvTodo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            CheckBox cbDone = this.grvTodo.Rows[e.RowIndex].FindControl("cbDone") as CheckBox;

            this.TodoItem = new Models.TodoItem()
            {
                ID = (int)e.Keys["ID"],
                Description = e.NewValues["Description"] as string,
                Completed = Convert.ToBoolean(e.NewValues["Completed"])
            };

            this.Presenter.UpdateTodo();

            this.grvTodo.EditIndex = -1;
        }

        public List<Models.TodoItem> TodoList
        {
            set
            {
                this.grvTodo.DataSource = value;
                this.grvTodo.DataBind();
            }
        }

        public Models.TodoItem TodoItem
        {
            get;
            private set;
        }

        public EventHandler<Events.OperationResultEventArgs> OnOperationExecuted
        {
            get { throw new NotImplementedException(); }
        }
    }
}