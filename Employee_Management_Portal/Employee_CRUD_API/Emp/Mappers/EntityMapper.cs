using System;
using Emp.Entities;
using Emp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emp.Mappers
{
    public static class EntityMapper
    {
        public static DeptTable ToDepartmentModel(this DepartmentDetails deptTable)
        {
            var deptDetails = new DeptTable();
            deptDetails.DeptName = deptTable.DeptName;
            deptDetails.DeptId = deptTable.DeptId;
            deptDetails.CreatedByEmail = deptTable.CreatedByEmail;
            deptDetails.CreatedByName = deptTable.CreatedByName;
            deptDetails.IsActive = deptTable.IsActive;
            return deptDetails;
        }
        public static Emptable ToEmployeeModel(this EmployeeDetails emptable)
        {
            var empDetails = new Emptable();
            empDetails.EmpName = emptable.EmpName;
            empDetails.EmpId = emptable.EmpId;
            empDetails.DeptId = emptable.DeptId;
            empDetails.EmailId = emptable.EmailId;
            empDetails.DateOfBirth = emptable.DateOfBirth;
            empDetails.Address = emptable.Address;
            empDetails.Gender = emptable.Gender;
            empDetails.PinCode = emptable.PinCode;
            empDetails.IsActive = emptable.IsActive;
            return empDetails;
        }
        public static List<Emptable> ToEmployeeModels(this List<EmployeeDetails> emptable)
        {
            List<Emptable> employeedetails = new List<Emptable>();
            foreach (var emp in emptable)
            {
                employeedetails.Add(emp.ToEmployeeModel());

            }
            return employeedetails;
        }
        public static List<DeptTable> ToDepartmentModels(this List<DepartmentDetails> depttable)
        {
            List<DeptTable> departmentdetails = new List<DeptTable>();
            foreach (var dept in depttable)
            {
                departmentdetails.Add(dept.ToDepartmentModel());

            }
            return departmentdetails;
        }
    }
}
