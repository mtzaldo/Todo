using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Todo.MVC.Controllers
{
    public class TodoController : Controller
    {
        Presenters.TodoPresenter _p = null;
        Presenters.TodoPresenter Presenter
        {
            get
            {
                if (_p == null)
                    _p = new Presenters.TodoPresenter();

                return _p;
            }
        }

        public ActionResult Index()
        {
            Models.TodoViewModel vm =
                this.Presenter.Intitialize();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(Models.Todo todo)
        {
            try
            {
                this.Presenter.CreateTodoItem(todo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(int id)
        {
            Models.TodoViewModel vm =
                this.Presenter.Intitialize();

            vm.TodoItem = new Models.Todo() { ID = id };

            return View("Index", vm);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Todo todo)
        {
            try
            {
                this.Presenter.UpdateTodo(todo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            this.Presenter.DeleteTodo(new Models.Todo() { ID = id });

            return RedirectToAction("Index");
        }
    }
}
