using Grifindo_Toys.Data;
using Grifindo_Toys.Models;
using System.Collections.Generic;
using System.Linq;


namespace Grifindo_Toys.DAL
{
    public class Salary:DbContext
    {
        public static List<UserModels> GetUserData()
        {
            var employeeProfile = _Context.EmployeeProfiles.ToList();
            var userRoleModelsList = employeeProfile.Select(userRole => new UserModels
            {
                UserId = userRole.EmpId,
                FullName = userRole.FullName
            }).ToList();
            return userRoleModelsList;
        }

        public static SalaryDetails GetEmployeeSalaryDetails(int employeeId)
        {
            SalaryDetails salary = new SalaryDetails();
            var list = _Context.EmployeeProfiles.First(x => x.EmpId == employeeId);
            salary.MonthlySalary = list.MonthlySalary;
            salary.OverTimeRate = list.OverTimeRate;
            salary.Allowances = list.Allowances;
            return salary;  
        }


        
    }
}
