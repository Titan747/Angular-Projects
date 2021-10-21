using System;
using System.Collections.Generic;

namespace Emp.Models
{
    public partial class Emptable
    {
        public Emptable()
        {
            InverseCreatedByNavigation = new HashSet<Emptable>();
        }

        public int EmpId { get; set; }
        public int DeptId { get; set; }
        public string EmpName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }

        public virtual Emptable CreatedByNavigation { get; set; }
        public virtual DeptTable Dept { get; set; }
        public virtual ICollection<Emptable> InverseCreatedByNavigation { get; set; }
    }
}
