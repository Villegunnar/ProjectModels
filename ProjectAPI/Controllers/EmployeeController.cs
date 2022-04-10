using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Services;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IProgramRepository<Employee> _employeeRepo;

        public EmployeeController(IProgramRepository<Employee> empRepo)
        {
            _employeeRepo = empRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await _employeeRepo.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await _employeeRepo.GetSingel(id);
                if (result == null)
                {
                    return NotFound($"Employee with Id: '{id}' could not be found in the database");
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve singel employee from database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateNewEmployee(Employee newUser)
        {
            try
            {
                if (newUser == null)
                {
                    return BadRequest();
                }

                var createdUser = await _employeeRepo.Add(newUser);

                return CreatedAtAction(nameof(GetEmployee), new { id = createdUser.Id }, createdUser);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var deletePro = await _employeeRepo.GetSingel(id);
                if (deletePro == null)
                {
                    return NotFound($"Employee with Id: '{id}' could not be found in the database");
                }

                return await _employeeRepo.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete employee from database.");
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee pro)
        {
            try
            {
                if (id != pro.Id)
                {
                    return BadRequest("User ID dosnt exists.");
                }

                var proToUpdate = await _employeeRepo.GetSingel(id);
                if (proToUpdate == null)
                {
                    return NotFound($"Employee with Id: '{id}' could not be found in the database");
                }
                return await _employeeRepo.Update(pro);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update employee in database.");
            }
        }

        [HttpGet]
        [Route("GetEmpWithTime/{id}")]
        public async Task<ActionResult<Employee>> GetEmpWithTime(int id)
        {
            try
            {
                var result = await _employeeRepo.GetEmpWithTime(id);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound($"User with Id: '{id}' could not be found in the database");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to find users Timereport");
            }

        }

    }
}
