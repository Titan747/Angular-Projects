using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.Models
{
    public interface IDeptRepository
    {
        DeptTable Add(DeptTable dept);
        List<DeptTable> GetAll();
        DeptTable Find(int Id);
        DeptTable DeleteDepartment(int Id);
        DeptTable Update(DeptTable dept);
    }
}
