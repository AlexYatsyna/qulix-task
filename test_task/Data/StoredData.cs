using System.Collections.Generic;
using test_task.Models;
using test_task.ViewModels;

namespace test_task.Data
{
    public class StoredData
    {
        public static TableModel tableModel = new TableModel()
        {
            Companies = new List<Company>
            {
              new Company { Id = 1, Name = "Qulix", Size = 1, Form = CompanyForm.OOO },
              new Company { Id = 2, Name = "Epam", Size = 2, Form = CompanyForm.YP },
              new Company { Id = 3, Name = "ITechArt", Size = 0, Form = CompanyForm.AO },
              new Company { Id = 4, Name = "ISsoft", Size = 0, Form = CompanyForm.RYP }
            },
            Employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Alex",
                    MiddleName = "Mechislavovich",
                    LastName = "Yatsyna",
                    date = new System.DateTime(2021, 11, 20),
                    CompanyId = 1,
                    Position = Position.BA
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Ivan",
                    MiddleName = "Mechislavovich",
                    LastName = "Petrob",
                    date = new System.DateTime(2021, 12, 20),
                    CompanyId = 2,
                    Position = Position.TESTER
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Petr",
                    MiddleName = "Ivanovich",
                    LastName = "Ivanov",
                    date = new System.DateTime(2022, 1, 20),
                    CompanyId = 2,
                    Position = Position.DEVELOPER
                }
            }
        };
    }
}
