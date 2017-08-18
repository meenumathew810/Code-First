using EmpManagement.Data;
using EmpManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;

namespace EmpManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeDbContext dbContext = new EmployeeDbContext();
            List<Employee> employess = dbContext.Employees.OrderBy(c=>c.Name).ToList();
            return View(employess);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeDbContext dbContext = new EmployeeDbContext();
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                ViewBag.Message = "Saved Successfully";
                return View();
            }
            else
            {
                return View(employee);
            }

        }

        public ActionResult Edit(int Id)
        {
            EmployeeDbContext dbContext = new EmployeeDbContext();
            Employee employee = dbContext.Employees.Where(c => c.Id == Id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            //EmployeeDbContext dbContext = new EmployeeDbContext();
            //Employee employee = dbContext.Employees.Where(c => c.Id == emp.Id).FirstOrDefault();
            ////employee.Name = emp.Name;
            ////employee.Email = emp.Email;
            ////employee.Phone = emp.Phone;
            //dbContext.Entry(employee).CurrentValues.SetValues(emp);
            //dbContext.SaveChanges();
            //return RedirectToAction("Index");

            EmployeeDbContext dbContext = new EmployeeDbContext();
            Employee employee = dbContext.Employees.Where(c => c.Id == emp.Id).FirstOrDefault();
            //UpdateModel(employee, new string[] { "Name" });
            UpdateModel<IEmployee>(employee);
            dbContext.SaveChanges();

            // bool isValid = TryUpdateModel(employee);
            // if (isValid)
            // {
            //     dbContext.SaveChanges();
            // }
            //else
            // {
            //     //return View();
            // }  
            return RedirectToAction("Index");

        }
        public ActionResult Details(int Id)
        {
            EmployeeDbContext dbContext = new EmployeeDbContext();
            Employee employee = dbContext.Employees.Where(c => c.Id == Id).FirstOrDefault();
            return View(employee);
        }
        public ActionResult Delete(int Id)
        {
            EmployeeDbContext dbContext = new EmployeeDbContext();
            Employee employee = dbContext.Employees.Where(c => c.Id == Id).FirstOrDefault();
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}