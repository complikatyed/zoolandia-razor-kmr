using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.DAL;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.Controllers
{
    public class EmployeeController : Controller
    {
        private ZooRepository repo = new ZooRepository();
        // GET: Employee
        public ActionResult Index()
        {

            List<Employee> list_of_employees = repo.GetEmployees();
            ViewBag.Message = "What a great looking group of employees!";
            ViewBag.Employees = list_of_employees;

            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
