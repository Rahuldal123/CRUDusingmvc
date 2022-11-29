using CRUDusingmvc.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusingmvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration configuration;
        EmployeeDAL employeeDAL;
        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            employeeDAL =new EmployeeDAL(this.configuration);
        }

        // GET: EmployeeController
        public ActionResult List()
        {
            ViewBag.EmployeeList = employeeDAL.GetAllEmployees();
            return View();
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);

            return View(model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int result=employeeDAL.AddEmployee(emp);
                if(result==1)
                return RedirectToAction(nameof(List));
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

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var model=employeeDAL.GetEmployeeById(id);
            return View(model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int result=employeeDAL.UpdateEmployee(emp);
                if(result== 1)
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

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = employeeDAL.GetEmployeeById(id);
            return View(model);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = employeeDAL.DeleteEmployee(id);
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
