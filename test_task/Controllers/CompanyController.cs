using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_task.Data;
using test_task.Models;


namespace test_task.Controllers
{
    public class CompanyController : Controller
    {

        public ActionResult Index()
        {                                       
            var companies = StoredData.tableModel.Companies;
            return View(companies);
        }

        public ActionResult AddCompany()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCompany(Company company)
        {
            company.Id = StoredData.tableModel.Companies.Count + 1;
            //var result = DBUtils.insertCompany(company).Result;
            
            var result = true;

            if (result)
            {
                StoredData.tableModel.Companies.Add(company);
                return RedirectToAction("Index"); 
            }
            else
                return RedirectToAction("AddCompany");
        }

        public ActionResult DeleteCompany(int id)
        {
            // var result = DBUtils.deleteCompany(id).Result;
            foreach(var i in StoredData.tableModel.Companies)
            {
                if (i.Id == id)
                {
                    StoredData.tableModel.Companies.Remove(i);
                    break;
                }
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult EditCompany(int id)
        {
            Company company = new Company();
            foreach (var i in StoredData.tableModel.Companies)
            {
                if (i.Id == id)
                {
                    company = i;
                    break;
                }
            }
            return View(company);
        }
        
        [HttpPost]
        public ActionResult EditCompany(Company company)
        {
            //var result = DBUtils.updateCompany(company).Result;
            var result = true;
            
            if (result)
            {
                for (int i = 0; i < StoredData.tableModel.Companies.Count; i++)
                {
                    if (StoredData.tableModel.Companies[i].Id == company.Id)
                    {
                        StoredData.tableModel.Companies[i] = company;
                        break;
                    }
                }
                return RedirectToAction("Index"); 
            }
            else
                return RedirectToAction("EditCompany");
        }
    }
}
