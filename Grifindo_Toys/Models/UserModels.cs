using System;

namespace Grifindo_Toys.Models
{
    public class UserModels: SalaryDetails
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public DateTime dob { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public int UserRoleId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
