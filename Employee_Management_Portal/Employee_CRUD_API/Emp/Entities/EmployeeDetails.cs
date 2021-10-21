using System;

namespace Emp.Models
{
    public class EmployeeDetails
    {
        public int EmpId { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string EmpName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PinCode
        {
            get; set;
        }
        public bool IsActive { get; set; }
    }
}