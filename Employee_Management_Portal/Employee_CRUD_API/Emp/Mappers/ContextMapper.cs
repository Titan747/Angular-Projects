using AutoMapper;
using Emp.Entities;
using Emp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.Mappers
{
    public static class ContextMapper

    {
        public static DepartmentDetails ToDepartmentDetailsEntity(this DeptTable deptTable)
        {
            var deptDetails = new DepartmentDetails();
            deptDetails.DeptName = deptTable.DeptName;
            deptDetails.DeptId = deptTable.DeptId;
            deptDetails.CreatedByEmail = deptTable.CreatedByEmail;
            deptDetails.CreatedByName = deptTable.CreatedByName;
            deptDetails.IsActive = deptTable.IsActive;
            return deptDetails;
        }

        public static EmployeeDetails ToEmployeeDetailsEntity(this Emptable emptable)
        {
            var empDetails = new EmployeeDetails();
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
        public static List<EmployeeDetails> ToEmployeeDetailsEntities(this List<Emptable> emptable)
        {
            List<EmployeeDetails> employeedetails = new List<EmployeeDetails>();
            foreach(var emp in emptable)
            {
                employeedetails.Add(emp.ToEmployeeDetailsEntity());
                
            }
            return employeedetails;
        }
        public static List<DepartmentDetails> ToDepartmentDetailsEntities(this List<DeptTable> depttable)
        {
            List<DepartmentDetails> departmentdetails = new List<DepartmentDetails>();
            foreach (var dept in depttable)
            {
                departmentdetails.Add(dept.ToDepartmentDetailsEntity());

            }
            return departmentdetails;
        }
    }
}