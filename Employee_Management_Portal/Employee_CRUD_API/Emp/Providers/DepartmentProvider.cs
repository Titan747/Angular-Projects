using AutoMapper;
using Emp.Entities;
using Emp.Mappers;
using Emp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Emp.Providers
{
    public class DepartmentProvider : DepartmentProviderInterface
    {
        public IDeptRepository _deptrepository { get; set; }

        public DepartmentProvider(IDeptRepository dept)
        {
            _deptrepository = dept;
        }
        public DepartmentDetails GetDeptById(int id)
        {
            DepartmentDetails deptdetails = _deptrepository.Find(id).ToDepartmentDetailsEntity();
            return deptdetails;
        }
        public List<DepartmentDetails> GetAllDept()
        {
            var deptdetails = _deptrepository.GetAll().ToDepartmentDetailsEntities();
            return deptdetails;
        }
        public DepartmentDetails UpdateDepartment(DepartmentDetails deptdetail)
        {
            DepartmentDetails deptdetails = _deptrepository.Update(deptdetail.ToDepartmentModel()).ToDepartmentDetailsEntity();
            return deptdetails;
        }
        public DepartmentDetails CreateDept(DepartmentDetails deptdetail)
        {
            DepartmentDetails deptdetails = _deptrepository.Add(deptdetail.ToDepartmentModel()).ToDepartmentDetailsEntity();
            return deptdetails;
        }
        public DepartmentDetails DeleteDepartment(int id)
        {
            DepartmentDetails deptdetails = _deptrepository.DeleteDepartment(id).ToDepartmentDetailsEntity();
            return deptdetails;
        }
    }
}