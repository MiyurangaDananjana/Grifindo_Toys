using Grifindo_Toys.Data;
using Grifindo_Toys.Models;
using System.Collections.Generic;
using System.Linq;

namespace Grifindo_Toys.DAL
{
    public class User : DbContext
    {
        public static bool AddNewUserData(UserModels userModels)
        {
            EmployeeProfile employee = new EmployeeProfile
            {
                FullName = userModels.FullName,
                Dob = userModels.dob,
                Address = userModels.Address,
                UserName = userModels.UserName,
                Password = userModels.Password,
                UserRole = userModels.UserRoleId,
                MonthlySalary = userModels.MonthlySalary,
                OverTimeRate = userModels.OverTimeRate,
                Allowances = userModels.Allowances
            };
            _Context.EmployeeProfiles.Add(employee);
            _Context.SaveChanges();
            return true;
        }

        public static List<UserRoleModels> GetUserRole()
        {
            var userRoles = _Context.UserRoles.ToList();
            var userRoleModelsList = userRoles.Select(userRole => new UserRoleModels
            {
                RoleId = userRole.RoleId,
                RoleName = userRole.RoleName

            }).ToList();
            return userRoleModelsList;
        }

        public static List<UserModels> GetUserDetail()
        {
            List<UserModels> users = new List<UserModels>();
            var list = (from EmployeeDetails in _Context.EmployeeProfiles
                        join userRole in _Context.UserRoles on EmployeeDetails.UserRole equals userRole.RoleId
                        select new
                        {
                            UserId = EmployeeDetails.EmpId,
                            FullName = EmployeeDetails.FullName,
                            dob = EmployeeDetails.Dob,
                            Address = EmployeeDetails.Address,
                            UserName = EmployeeDetails.UserName,
                            Role = userRole.RoleName,
                            MonthlySalary = EmployeeDetails.MonthlySalary,
                            OverTimeRate = EmployeeDetails.OverTimeRate,
                            Allowances = EmployeeDetails.Allowances
                        });
            foreach(var item in list)
            {
                UserModels userModls = new UserModels();
                userModls.UserId = item.UserId;
                userModls.FullName = item.FullName;
                userModls.dob = item.dob;
                userModls.Address = item.Address;
                userModls.UserName = item.UserName;
                userModls.Role = item.Role;
                userModls.MonthlySalary = (decimal)item.MonthlySalary;
                userModls.OverTimeRate = (decimal)item.OverTimeRate;
                userModls.Allowances = (decimal)item.Allowances;
                users.Add(userModls);
            }
            return users;
        }

        internal static bool Login(string userName, string password)
        {
            var isEmployee = _Context.EmployeeProfiles.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            if (isEmployee != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
