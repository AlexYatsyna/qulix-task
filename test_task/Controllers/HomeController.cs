using Microsoft.AspNetCore.Mvc;
using test_task.Data;


namespace test_task.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //StoredData.tableModel.Companies = DBUtils.selectAllCompaniesOrOne().Result;
            //StoredData.tableModel.Employees = DBUtils.selectAllEmploeesOrOne().Result;

            return View(StoredData.tableModel);
    }
}
}
