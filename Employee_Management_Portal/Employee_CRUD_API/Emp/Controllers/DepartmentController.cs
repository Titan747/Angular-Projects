using Emp.Entities;
using Emp.Models;
using Emp.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public DepartmentProviderInterface _deptprovider { get; set; }

        public DepartmentController(DepartmentProviderInterface dept)
        {
            _deptprovider = dept;
        }


        [HttpGet(Name ="GetAllDept")]
        public IActionResult GetAllDept()
        {
            var departmentDetails = _deptprovider.GetAllDept();
            return Ok(departmentDetails);
        }


        [HttpGet("{id}", Name = "GetDeptById")]
        public IActionResult GetDeptById(int id)
        {
            DepartmentDetails departmentDetails = _deptprovider.GetDeptById(id);
            return Ok(departmentDetails);
        }

        [HttpPut("UpdateDepartment", Name ="UpdateDepartment")]
        public IActionResult UpdateDepartment( DepartmentDetails departmentDetail)
        {
            DepartmentDetails departmentDetails = _deptprovider.UpdateDepartment(departmentDetail);
            return Ok(departmentDetails);
        }

        [HttpPost("CreateDepartment",Name ="CreateDept")]
        public IActionResult CreateDept(DepartmentDetails departmentDetail)
        {
            DepartmentDetails departmentDetails = _deptprovider.CreateDept(departmentDetail);
            return Ok(departmentDetails);
        }


        [HttpDelete("{id}",Name ="DeleteDepartment")]
        public IActionResult DeleteDepartment(int id)
        {
            DepartmentDetails departmentDetails = _deptprovider.DeleteDepartment(id);
            return Ok(departmentDetails);
        }
    }
}
