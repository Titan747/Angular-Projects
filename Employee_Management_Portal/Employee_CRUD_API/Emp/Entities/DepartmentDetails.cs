using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.Entities
{
    public class DepartmentDetails
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByEmail { get; set; }
        public string CreatedByName { get; set; }

    }
}
