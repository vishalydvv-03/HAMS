using HAMS.Data;
using HAMS.Domain.Models.Department;
using HAMS.Domain.Models.DepartmentModels;
using HAMS.Services.DepartmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HAMS.API.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService service;

        public DepartmentController(IDepartmentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadDepartment>>> GetAllDepartments()
        {
            var data = await service.GetAllDepartmentAsync();
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReadDepartment>> GetDepartmentById(int id)
        {
            var data = await service.GetDepartmentByIdAsync(id);
            if(data == null)
            {
                return NotFound("No Department with this Id Exists");
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(AddDepartment dept)
        {
            var result = await service.AddDepartmentAsync(dept);
            if (result == false)
            {
                return Conflict("Department with this Name Already exists");
            }
            return Ok("New Department Added Successfully");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDepartment(int id, AddDepartment dept)
        {
            var result = await service.UpdateDepartmentAsync(id, dept);
            if (result == false)
            {
                return NotFound("No Such Department Exist");
            }
            return Ok("Department Updated Successfully");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var result = await service.DeleteDepartmentAsync(id);
            if (result == false)
            {
                return NotFound("No Such Department Exist");
            }
            return Ok("Department Removed Successfully");
        }
    }
}
