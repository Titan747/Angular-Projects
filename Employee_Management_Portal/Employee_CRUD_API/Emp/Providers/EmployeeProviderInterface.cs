using Emp.Entities;
using Emp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.Providers
{
    public interface EmployeeProviderInterface
    {
        List<EmployeeDetails> GetEmployeesbyDepartmentId(int id);
        List<EmployeeDetails> GetAllEmployees();
        List<EmployeeDetails> GetEmployeesByEmpId(int id);
        EmployeeDetails UpdateEmployee(EmployeeDetails employeeDetails);
        EmployeeDetails CreateEmployee(EmployeeDetails employeeDetails);
        EmployeeDetails DeleteEmployees(int id);
        List<EmployeeDetails> InactiveEmployees();
    }
}