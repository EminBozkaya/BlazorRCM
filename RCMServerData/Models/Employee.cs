using Core.Model;
using System;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class Employee : BaseDomain
    {
        public Employee()
        {
            this.EmployeeMoneyFlows = new HashSet<EmployeeMoneyFlow>();
            this.EmployeeRollCalls = new HashSet<EmployeeRollCall>();
            this.ExpenseFlows = new HashSet<ExpenseFlow>();
        }

        public int EId { get; set; }
        public Nullable<short> BId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public string IDnumber { get; set; }
        public byte PositionId { get; set; }
        public Nullable<byte> WorkTypeId { get; set; }
        public byte SalaryTypeId { get; set; }
        public decimal Fee { get; set; }
        public string? Phone { get; set; }
        public string? SecondaryPhone { get; set; }
        public string? Adress { get; set; }
        public string? Mail { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string? Gender { get; set; }
        public System.DateTime HireDate { get; set; }
        public Nullable<System.DateTime> FireDate { get; set; }
        public string? Note { get; set; }
        public bool IsActive { get; set; }

        public virtual PositionType? PositionType { get; set; }
        public virtual SalaryType? SalaryType { get; set; }
        public virtual WorkType? WorkType { get; set; }
        public virtual ICollection<EmployeeMoneyFlow> EmployeeMoneyFlows { get; set; }
        public virtual ICollection<EmployeeRollCall> EmployeeRollCalls { get; set; }
        public virtual ICollection<ExpenseFlow> ExpenseFlows { get; set; }
        
    }
}
