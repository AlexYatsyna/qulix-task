using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using test_task.Models;

namespace test_task.Components
{
    public class MenuViewComponent : ViewComponent
    {

        private List<MenuItem> menuItems = new List<MenuItem>
        {
            new MenuItem { Controller = "Company", Action = "Index", Text = "C/U/D Companies" },
            new MenuItem {  Controller = "Employee", Action = "Index", Text = "C/U/D Employees" }
        };

        public IViewComponentResult Invoke()
        {
            var controller = ViewContext.RouteData.Values["controller"];

            foreach (var item in menuItems)
            {
                if(controller != null && (string)controller == item.Controller)
                    item.Active = "active";
            }

            return View(menuItems);

        }
    }
}