using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.Models
{
    public class DeptRepository : IDeptRepository
    {
        private readonly EmployeeTableContext _employeeTableContext;
        public DeptRepository(EmployeeTableContext employeeTableContext)
        {
            _employeeTableContext = employeeTableContext;
        }

        public DeptTable Add(DeptTable dept)
        {
            _employeeTableContext.DeptTable.Add(dept);
            _employeeTableContext.SaveChanges();
            return dept;
        }

        public DeptTable Find(int Id)
        {
            var deptrecord = _employeeTableContext.DeptTable.Find(Id);
            return deptrecord;
        }

        public List<DeptTable> GetAll()
        {
            return _employeeTableContext.DeptTable.Where(d => d.IsActive == true).ToList();

        }

        public DeptTable DeleteDepartment(int Id)
        {
            var deptEntity = Find(Id);
            deptEntity.IsActive = false;
            _employeeTableContext.SaveChanges();
            return deptEntity;
        }

        public DeptTable Update(DeptTable dept)
        {
            var deptEntity = Find(dept.DeptId);
            deptEntity.DeptName = dept.DeptName;
            _employeeTableContext.SaveChanges();
            return deptEntity;
        }
    }
}
