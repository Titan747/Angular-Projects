using Emp.Entities;
using Emp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.Providers
{
    public interface DepartmentProviderInterface
    {
        List<DepartmentDetails> GetAllDept();
        DepartmentDetails GetDeptById(int id);
        DepartmentDetails UpdateDepartment(DepartmentDetails deptdetail);
        DepartmentDetails CreateDept(DepartmentDetails deptdetails);
        DepartmentDetails DeleteDepartment(int id);
    }
}