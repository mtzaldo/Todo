using System.Web.Mvc;

namespace Todo.MVC.Controllers
{
    public class TodoController : Controller
    {

        public ActionResult Index()
        {
            Presenters.IndexTodoPresenter p =
                new Presenters.IndexTodoPresenter();

            Models.TodoViewModel vm = p.Init();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(Models.Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                Presenters.CreateTodoPresenter presenter =
                    new Presenters.CreateTodoPresenter();

                presenter.CreateTodoItem(todo);

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
            Presenters.IndexTodoPresenter p =
                new Presenters.IndexTodoPresenter();

            Models.TodoViewModel vm = p.Init();

            vm.TodoItem = new Models.Todo() { ID = id };

            return View("Index", vm);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Todo todo)
        {
            Presenters.IndexTodoPresenter p =
                new Presenters.IndexTodoPresenter();

            Models.TodoViewModel vm = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    vm = p.Init();
                    vm.TodoItem = todo;

                    return View("Index", vm);
                }

                Presenters.UpdateTodoPresenter presenter =
                    new Presenters.UpdateTodoPresenter();

                presenter.Save(todo);

                return RedirectToAction("Index");
            }
            catch
            {
                vm = p.Init();
                vm.TodoItem = todo;

                return View("Index", vm);
            }
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            Presenters.DeleteTodoPresenter presenter =
                new Presenters.DeleteTodoPresenter();

            presenter.DeleteTodo(new Models.Todo() { ID = id });

            return RedirectToAction("Index");
        }
    }
}
