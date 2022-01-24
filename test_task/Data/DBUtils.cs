using System.Collections.Generic;
using test_task.Models;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace test_task.Data
{
    public static class DBUtils
    {

        private const string connectionString = "Server=localhost\\MSSQLSERVER;Database=qulixtask;Trusted_Connection=True;";

        public static async Task<List<Company>> selectAllCompaniesOrOne(bool isSelectOne = false, int id = -1)
        {
            var sqlQuery = "";

            if (isSelectOne && id > 0)
                sqlQuery = $"Select * from Companies WHERE CompanyID = {id}";
            else
                sqlQuery = "Select * from Companies";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var companies = new List<Company>();

                var command = new SqlCommand(sqlQuery, connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {

                    while (await reader.ReadAsync())
                    {

                        object companyId = reader.GetValue(0);
                        object companyName = reader.GetValue(1);
                        object size = reader.GetValue(2);
                        object form = reader.GetValue(3);
                        companies.Add(new Company { Id = (int)companyId, Name = (string)companyName, Size = (int)size, Form = (CompanyForm)form });

                    }
                }

                await reader.CloseAsync();
                await connection.CloseAsync();
                return companies;
            }
        }

        public static async Task<List<Employee>> selectAllEmploeesOrOne(bool isSelectOne = false, int id = -1)
        {
            var sqlQuery = "";

            if (isSelectOne && id > 0)
                sqlQuery = $"Select * from Employees WHERE EmployeeID = {id}";
            else
                sqlQuery = "Select * from Employees";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var employees = new List<Employee>();
                
                var command = new SqlCommand(sqlQuery, connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {

                    while (await reader.ReadAsync())
                    {

                        object employeeId = reader.GetValue(0);
                        object companyId = reader.GetValue(1);
                        object firstName = reader.GetValue(2);
                        object lastName = reader.GetValue(3);
                        object middleName = reader.GetValue(4);
                        object position = reader.GetValue(5);
                        object date = reader.GetValue(6);
                        employees.Add(new Employee { EmployeeId = (int)employeeId, CompanyId = (int)companyId, FirstName = (string)firstName,
                        LastName = (string)lastName, MiddleName = (string)middleName, Position = (Position)position, date = (DateTime)date});

                    }
                }

                await reader.CloseAsync();
                await connection.CloseAsync();
                return employees;
            }
        }

        public static async Task<bool> insertCompany(Company company)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var commandStatus = false;
                
                await connection.OpenAsync();

                SqlCommand insertComp = new SqlCommand($"INSERT INTO Companies (Name,Size,Form)" +
                    $" VALUES({company.Name},{company.Size},{company.Form});", connection);
                
                if(await insertComp.ExecuteNonQueryAsync() > 0)
                {
                    commandStatus = true;   
                }

                await connection.CloseAsync();
                return commandStatus;

            }
        }

        public static async Task<bool> insertEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var commandStatus = false;

                await connection.OpenAsync();

                SqlCommand insertEmp = new SqlCommand($"INSERT INTO Employees (CompanyId, FirstName, LastName, MiddleName, Position, FirstDay) " +
                    $"VALUES({employee.CompanyId},{employee.FirstName},{employee.LastName},{employee.MiddleName},{employee.Position},{employee.date});", connection);

                if (await insertEmp.ExecuteNonQueryAsync() > 0)
                {
                    commandStatus = true;
                }

                await connection.CloseAsync();
                return commandStatus;

            }
        }

        public static async Task<bool> updateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var commandStatus = false;

                await connection.OpenAsync();

                SqlCommand updateEmp = new SqlCommand($"UPDATE Employees SET CompanyId = {employee.CompanyId}, " +
                    $"FirstName = {employee.FirstName}, LastName = {employee.LastName}, MiddleName = {employee.MiddleName}," +
                    $"Position = {employee.Position}, FirstDay = {employee.date} WHERE EmployeeID = {employee.EmployeeId};", connection);

                if (await updateEmp.ExecuteNonQueryAsync() > 0)
                {
                    commandStatus = true;
                }

                await connection.CloseAsync();
                return commandStatus;

            }
        }

        public static async Task<bool> updateCompany(Company company)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var commandStatus = false;

                await connection.OpenAsync();

                SqlCommand updateComp = new SqlCommand($"UPDATE Companies SET Name = {company.Name}, " +
                    $"Size = {company.Size}, Form = {company.Form} WHERE CompanyID = {company.Id};", connection);

                if (await updateComp.ExecuteNonQueryAsync() > 0)
                {
                    commandStatus = true;
                }

                await connection.CloseAsync();
                return commandStatus;

            }
        }

        public static async Task<bool> deleteCompany(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var commandStatus = false;

                await connection.OpenAsync();

                SqlCommand deleteComp = new SqlCommand($"DELETE FROM Companies WHERE CompanyID = {id};", connection);

                if (await deleteComp.ExecuteNonQueryAsync() > 0)
                {
                    commandStatus = true;
                }

                await connection.CloseAsync();
                return commandStatus;

            }
        }

        public static async Task<bool> deleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var commandStatus = false;

                await connection.OpenAsync();

                SqlCommand deleteEmp = new SqlCommand($"DELETE FROM Employees WHERE EmployeeID = {id};", connection);

                if (await deleteEmp.ExecuteNonQueryAsync() > 0)
                {
                    commandStatus = true;
                }

                await connection.CloseAsync();
                return commandStatus;

            }
        }


    }

}
