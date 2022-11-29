using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUDusingmvc.DAL;

namespace CRUDusingmvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration configuration;
        ProductDAL productDAL;
        public ProductController(IConfiguration configuration)
        {
            this.configuration = configuration;
            productDAL=new ProductDAL(this.configuration);


        }

        // GET: ProductController
        public ActionResult List()
        {
            ViewBag.ProductList=productDAL.GetAllProducts();
            return View();
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var model = productDAL.GetProductById(id);
            return View(model);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p)
        {
            try
            {
                int result = productDAL.AddProduct(p);
                if (result==1)
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = productDAL.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product p)
        {
            try
            {
                int result=productDAL.UpdateProduct(p);
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var model=productDAL.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName ("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = productDAL.DeleteProduct(id);
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
