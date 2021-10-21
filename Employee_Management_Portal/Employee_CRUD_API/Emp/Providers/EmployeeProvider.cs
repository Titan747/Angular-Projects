using AutoMapper;
using Emp.Entities;
using Emp.Models;
using Emp.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.Providers
{
    public class EmployeeProvider:EmployeeProviderInterface
    {
        public IRepository _emprepository { get; set; }

        public EmployeeProvider(IRepository emp)
        {
            _emprepository = emp;
        }
        public List<EmployeeDetails> GetEmployeesbyDepartmentId(int id)
        {
            List<EmployeeDetails> empdetails = _emprepository.GetEmpbyDeptId(id);
            return empdetails;
        }
        public List<EmployeeDetails> GetAllEmployees()
        { 
            List<EmployeeDetails> empdetails = _emprepository.GetEmployees();
            return empdetails;
        }
        public List<EmployeeDetails> GetEmployeesByEmpId(int id)
        {
            List<EmployeeDetails> empdetails = _emprepository.GetEmpdetailsbyEmpId(id);
            return empdetails;
        }
        public EmployeeDetails UpdateEmployee(EmployeeDetails employeedetail)
        {
            EmployeeDetails empdetails=_emprepository.Update(employeedetail.ToEmployeeModel()).ToEmployeeDetailsEntity();
            return empdetails;
        }
        public EmployeeDetails CreateEmployee(EmployeeDetails employeedetails)
        {
            EmployeeDetails empdetails = _emprepository.Add(employeedetails.ToEmployeeModel()).ToEmployeeDetailsEntity();
            return empdetails;
        }
        public EmployeeDetails DeleteEmployees(int id)
        {
            EmployeeDetails empdetails = _emprepository.DeleteEmployee(id).ToEmployeeDetailsEntity();
            return empdetails;
        }
        public List<EmployeeDetails> InactiveEmployees()
        {
            List<EmployeeDetails> empdetails = _emprepository.GetinactiveEmployees();
            return empdetails;
        }
    }
}
