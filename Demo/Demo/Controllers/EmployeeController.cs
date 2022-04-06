using Demo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly DepartmentFactory departmentFactory;
        private readonly FactoryType factoryType;
        public EmployeeController(AppDbContext dbContext, DepartmentFactory departmentFactory, FactoryType factoryType)
        {
            this.dbContext = dbContext;
            this.departmentFactory = departmentFactory;
            this.factoryType = factoryType;
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee emp)
        {
            if (emp.Id == 0)
            {
                await dbContext.employees.AddAsync(emp);
                await dbContext.SaveChangesAsync();
                return Ok(emp);
            }
            return BadRequest("Error in Adding Employee");
        }
        [HttpGet()]
        public async Task<ActionResult> GetEmployees(int? id)
        {
            if (id == null)
            {
                var result = await dbContext.employees.Include(x => x.Department).ToListAsync();
                await dbContext.SaveChangesAsync();
                return Ok(result);
            }
            else if (id != null)
            {
                var result = await dbContext.employees.Include(x => x.Department).Where(x => x.Id == id).ToListAsync();
                return Ok(result);
            }
            return NotFound("Data Not found");
        }
        [HttpPut("EditEmployee/{id}")]
        public async Task<IActionResult> EditEmployee(int id, [FromBody] Employee emp)
        {
            if (id == emp.Id)
            {
                dbContext.employees.Update(emp);
                await dbContext.SaveChangesAsync();
                return Ok(emp);
            }
            return BadRequest("Error in Updation of Employee");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await dbContext.employees.FindAsync(id);
            if (employee != null)
            {
                employee.Status = true;
                dbContext.employees.Update(employee);
                await dbContext.SaveChangesAsync();
                return Ok("Employee Delete Successfully");
            }
            return NotFound("Employee Can not Deleted");
        }
        [HttpGet("OvertimePayFactory")]
        public async Task<ActionResult> OvertimePay(int id, int hour)
        {
            if (id != 0)
            {
                var deptname = await dbContext.employees.Include(x => x.Department).Where(x => x.Id == id).Select(x => x.Department.DepartmentName).FirstOrDefaultAsync();
                var result = departmentFactory.Getobj(deptname);
                var overtimepay = result.MyOverTimePay(hour);
                return Ok(overtimepay);
            }
            return NotFound("Data Not found");
        }
        [HttpGet("OvertimePayAbstractFactory")]
        public async Task<ActionResult> OvertimePayAbstractFactory(int id, int hour, string factorytype)
        {
            if (id != 0)
            {
                var obj = factoryType.getfactorytype(factorytype);
                var deptname = await dbContext.employees.Include(x => x.Department).Where(x => x.Id == id).Select(x => x.Department.DepartmentName).FirstOrDefaultAsync();
                var result = obj.GetFactory(deptname);
                var overtimepay = result.MyOverTimePay(hour);
                return Ok(overtimepay);
            }
            return NotFound("Data Not found");
        }
    }
}
