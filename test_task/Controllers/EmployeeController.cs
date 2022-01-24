using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using test_task.Data;
using test_task.Models;

namespace test_task.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            var employees = StoredData.tableModel.Employees;
            return View(employees);
        }

        public ActionResult AddEmployee()
        {
            ViewData["Companies"] = ToSelectList(StoredData.tableModel.Companies);
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {

            employee.EmployeeId = StoredData.tableModel.Employees.Count + 1;

            //var result = DBUtils.insertEmployee(employee).Result;
            
            var result = true;

            if (result)
            {
                StoredData.tableModel.Employees.Add(employee);
                for (int i = 0; i < StoredData.tableModel.Companies.Count; i++)
                {
                    if (StoredData.tableModel.Companies[i].Id == employee.CompanyId)
                    {
                        StoredData.tableModel.Companies[i].Size +=1;
                       // var curentResult = DBUtils.updateCompany(StoredData.tableModel.Companies[i]);
                        break;
                    }
                }
                            
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("AddEmployee");
        }

        public ActionResult DeleteEmployee(int id)
        {
            //var result = DBUtils.deleteEmployee(id).Result;
            var companyId = -1;
            foreach (var i in StoredData.tableModel.Employees)
            {
                if (i.EmployeeId == id)
                {
                    companyId = i.CompanyId;
                    StoredData.tableModel.Employees.Remove(i);
                    break;
                }
            }

            for (int i = 0; i < StoredData.tableModel.Companies.Count; i++)
            {

                if (StoredData.tableModel.Companies[i].Id == companyId)
                {
                    StoredData.tableModel.Companies[i].Size -= 1;
                    // var curentResult = DBUtils.updateCompany(StoredData.tableModel.Companies[i]);
                    break;
                }

            }

            return RedirectToAction("Index");
        }

        public ActionResult EditEmployee(int id)
        {
            ViewData["Companies"] = ToSelectList(StoredData.tableModel.Companies);
            Employee employee = new Employee();
            foreach (var i in StoredData.tableModel.Employees)
            {
                if (i.EmployeeId == id)
                {
                    employee = i;
                    break;
                }
            }
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            //var result = DBUtils.updateEmployee(employee).Result;
            var result = true;

            if (result)
            {
                int previousCompanyId = -1;

                for (int i = 0; i < StoredData.tableModel.Employees.Count; i++)
                {
                    if (StoredData.tableModel.Employees[i].EmployeeId == employee.EmployeeId)
                    {
                        previousCompanyId = StoredData.tableModel.Employees[i].CompanyId;
                        StoredData.tableModel.Employees[i] = employee;
                        break;
                    }
                }

                for (int i = 0; i < StoredData.tableModel.Companies.Count; i++)
                {
                    if (StoredData.tableModel.Companies[i].Id == employee.CompanyId)
                    {
                        StoredData.tableModel.Companies[i].Size += 1;
                        // var curentResult = DBUtils.updateCompany(StoredData.tableModel.Companies[i]);
                    }

                    if(StoredData.tableModel.Companies[i].Id == previousCompanyId)
                    {
                        StoredData.tableModel.Companies[i].Size -= 1;
                        // var curentResult = DBUtils.updateCompany(StoredData.tableModel.Companies[i]);
                    }

                }


                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("EditEmployee");
        }

        [NonAction]
        public SelectList ToSelectList(List<Company> companies)
        {

            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var company in companies)
            {
                list.Add(new SelectListItem()
                {
                    Value = company.Id.ToString(),
                    Text = company.Name
                });
            }

            return new SelectList(list, "Value", "Text");
        }
    }
}
