using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emp.Providers;

namespace Emp.Models
{
    public class Repository : IRepository
    {
        private readonly EmployeeTableContext _employeeTableContext;
        public Repository(EmployeeTableContext employeeTableContext)
        {
            _employeeTableContext = employeeTableContext;
        }

        public Emptable Add(Emptable emp)
        {
            _employeeTableContext.Emptable.Add(emp);   
            _employeeTableContext.SaveChanges();
            return emp;
        }

        public Emptable Find(int Id)
        {
            var emprecord = _employeeTableContext.Emptable.Find(Id);
            return emprecord;
        }

        public List<EmployeeDetails> GetEmpdetailsbyEmpId(int Empid)
        {
            List<EmployeeDetails> employeeList = (from e in _employeeTableContext.Emptable
                                            join d in _employeeTableContext.DeptTable on e.DeptId equals d.DeptId
                                            where e.EmpId == Empid && e.IsActive==true
                                            select new EmployeeDetails()
                                            {
                                                EmpId = e.EmpId,
                                                DeptId = e.DeptId,
                                                EmpName = e.EmpName,
                                                DeptName = d.DeptName,
                                                DateOfBirth = e.DateOfBirth,
                                                EmailId = e.EmailId,
                                                Gender = e.Gender,
                                                Address = e.Address,
                                                PinCode = e.PinCode,
                                                IsActive=e.IsActive,
                                            }).ToList();
            return employeeList;
        }

        public List<EmployeeDetails> GetEmpbyDeptId(int deptid)
        {

            List<EmployeeDetails> employeeList = (from e in _employeeTableContext.Emptable
                                join d in _employeeTableContext.DeptTable on e.DeptId equals d.DeptId
                                where e.DeptId==deptid && e.IsActive == true
                                                  select new EmployeeDetails()
                                {
                                    EmpId=e.EmpId,
                                    DeptId=e.DeptId,
                                    EmpName=e.EmpName,
                                    DeptName=d.DeptName,
                                    DateOfBirth=e.DateOfBirth,
                                    EmailId=e.EmailId,
                                    Gender=e.Gender,
                                    Address=e.Address,
                                    PinCode=e.PinCode,
                                    IsActive=e.IsActive,
                                }).ToList();
            return employeeList;
            //return _employeeTableContext.Emptable.ToList();
        }

        public List<EmployeeDetails> GetEmployees()
        {

            List<EmployeeDetails> employeeList = (from e in _employeeTableContext.Emptable
                                                  join d in _employeeTableContext.DeptTable on e.DeptId equals d.DeptId
                                                  where  e.IsActive == true
                                                  select new EmployeeDetails()
                                                  {
                                                      EmpId=e.EmpId,
                                                      DeptId=e.DeptId,
                                                      EmpName = e.EmpName,
                                                      DeptName = d.DeptName,
                                                      DateOfBirth = e.DateOfBirth,
                                                      EmailId = e.EmailId,
                                                      Gender = e.Gender,
                                                      Address = e.Address,
                                                      PinCode = e.PinCode,
                                                      IsActive=e.IsActive,
                                                  }).ToList();
            return employeeList;
            //return _employeeTableContext.Emptable.ToList();
        }

        public Emptable DeleteEmployee(int Id)
        {
            var empEntity = Find(Id);
            empEntity.IsActive=false;
            _employeeTableContext.SaveChanges();
            return empEntity;
            
        }

        public Emptable Update(Emptable emp)
        {
            var empEntity = Find(emp.EmpId);
            empEntity.EmpName = emp.EmpName;
            empEntity.EmpId = emp.EmpId;
            empEntity.EmailId = emp.EmailId;
            empEntity.Gender = emp.Gender;
            empEntity.PinCode = emp.PinCode;
            empEntity.Address = emp.Address;
            empEntity.DateOfBirth = emp.DateOfBirth;
            empEntity.DeptId = emp.DeptId;
            _employeeTableContext.SaveChanges();
            return empEntity;
        }
        public List<EmployeeDetails> GetinactiveEmployees()
        {

            List<EmployeeDetails> employeeList = (from e in _employeeTableContext.Emptable
                                                  join d in _employeeTableContext.DeptTable on e.DeptId equals d.DeptId
                                                  where e.IsActive == false
                                                  select new EmployeeDetails()
                                                  {
                                                      EmpId = e.EmpId,
                                                      DeptId = e.DeptId,
                                                      EmpName = e.EmpName,
                                                      DeptName = d.DeptName,
                                                      DateOfBirth = e.DateOfBirth,
                                                      EmailId = e.EmailId,
                                                      Gender = e.Gender,
                                                      Address = e.Address,
                                                      PinCode = e.PinCode,
                                                      IsActive = e.IsActive,
                                                  }).ToList();
            return employeeList;
            //return _employeeTableContext.Emptable.ToList();
        }
    }
}
