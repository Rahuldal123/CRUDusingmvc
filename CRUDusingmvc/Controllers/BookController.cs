using CRUDusingmvc.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusingmvc.Controllers
{
    public class BookController : Controller
    {
        private readonly IConfiguration configuration;
        bookDAL bookDAL;
        public BookController(IConfiguration configuration)
        {
            this.configuration = configuration;
            bookDAL=new bookDAL(this.configuration);
        }

        // GET: BookController
        public ActionResult List()
        {
            ViewBag.BookList=bookDAL.Getallbooks();
            return View();
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var model = bookDAL.GetBookById(id);
            return View(model);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book b)
        {
            try
            {
                int result=bookDAL.AddBook(b);
                if(result==1)
                {
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return BadRequest();
                }
               
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var model=bookDAL.GetBookById(id);
            return View(model);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book b)
        {
            try
            {
                int result = bookDAL.UpdateBook(b);
                if(result==1)
                {
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return BadRequest();
                }
            }
                
            catch
            {
                return BadRequest();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var model= bookDAL.GetBookById(id);
            return View(model);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result= bookDAL.DeleteBook(id);
                if(result==1)
                {
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
