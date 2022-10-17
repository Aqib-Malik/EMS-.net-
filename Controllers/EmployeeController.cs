using EMS.EmployesData;
using EMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;

        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployee()
        {
            return Ok(_employeeData.GetEmployees());
        }


        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var emloyee= _employeeData.GetEmployee(id);
            if(emloyee != null)
            {
                return Ok(_employeeData.GetEmployee(id));

            }
            return NotFound($"Empoyee with Id:{id} not fond");
           
        }



        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id,
                employee);

        }


        [HttpDelete]
        [Route("api/[controller]")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var emloyee = _employeeData.GetEmployee(id);
            if (emloyee != null)
            {
                _employeeData.DeleteEmployee(emloyee);

            }
            return NotFound();


        }

    }
}
