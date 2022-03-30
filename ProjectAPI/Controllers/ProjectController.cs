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
    public class ProjectController : ControllerBase
    {
        private IProgramRepository<Project> _projectRepo;

        public ProjectController(IProgramRepository<Project> projRepo)
        {
            _projectRepo = projRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGetProjects()
        {
            try
            {
                return Ok(await _projectRepo.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            try
            {
                var result = await _projectRepo.GetSingel(id);
                if (result == null)
                {
                    return NotFound($"Project with Id: '{id}' could not be found in the database");
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve singel project from database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateNewProject(Project newProject)
        {
            try
            {
                if (newProject == null)
                {
                    return BadRequest();
                }

                var createdProject = await _projectRepo.Add(newProject);

                return CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, createdProject);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            try
            {
                var deletePro = await _projectRepo.GetSingel(id);
                if (deletePro == null)
                {
                    return NotFound($"Project with Id: '{id}' could not be found in the database");
                }

                return await _projectRepo.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete project from database.");
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project pro)
        {
            try
            {
                if (id != pro.Id)
                {
                    return BadRequest("Project ID dosnt exists.");
                }

                var proToUpdate = await _projectRepo.GetSingel(id);
                if (proToUpdate == null)
                {
                    return NotFound($"Project with Id: '{id}' could not be found in the database");
                }
                return await _projectRepo.Update(pro);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update project in database.");
            }
        }

    }
}
