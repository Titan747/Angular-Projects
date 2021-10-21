using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.Models
{
    public interface IRepository
    {
        Emptable Add(Emptable emp);
        List<EmployeeDetails> GetEmpbyDeptId(int deptid);
        List<EmployeeDetails> GetEmployees();
        List<EmployeeDetails> GetEmpdetailsbyEmpId(int Empid);
        Emptable Find(int Id);
        Emptable DeleteEmployee(int Id);
        List<EmployeeDetails> GetinactiveEmployees();
        Emptable Update(Emptable emp);
    }
}
