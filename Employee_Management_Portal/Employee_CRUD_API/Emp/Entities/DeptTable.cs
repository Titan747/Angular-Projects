using System;
using System.Collections.Generic;

namespace Emp.Models
{
    public partial class DeptTable
    {
        public DeptTable()
        {
            Emptable = new HashSet<Emptable>();
        }

        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public string CreatedByEmail { get; set; }
        public string CreatedByName { get; set; }

        public virtual ICollection<Emptable> Emptable { get; set; }
    }
}
