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
    public class TimeReportController : ControllerBase
    {
        private IProgramRepository<TimeReport> _timeReportRepo;

        public TimeReportController(IProgramRepository<TimeReport> timeRepRepo)
        {
            _timeReportRepo = timeRepRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGetTimeReports()
        {
            try
            {
                return Ok(await _timeReportRepo.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database.");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TimeReport>> GetTimeReport(int id)
        {
            try
            {
                var result = await _timeReportRepo.GetSingel(id);
                if (result == null)
                {
                    return NotFound($"Time report with Id: '{id}' could not be found in the database");
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve singel Time report from database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TimeReport>> CreateNewTimeReport(TimeReport newTimeReport)
        {
            try
            {
                if (newTimeReport == null)
                {
                    return BadRequest();
                }

                var createdTimeReport = await _timeReportRepo.Add(newTimeReport);

                return CreatedAtAction(nameof(GetTimeReport), new { id = createdTimeReport.Id }, createdTimeReport);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeReport>> DeleteTimeReport(int id)
        {
            try
            {
                var deleteTimerep = await _timeReportRepo.GetSingel(id);
                if (deleteTimerep == null)
                {
                    return NotFound($"Time report with Id: '{id}' could not be found in the database");
                }

                return await _timeReportRepo.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete Time report from database.");
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TimeReport>> UpdateTimeReport(int id, TimeReport timerep)
        {
            try
            {
                if (id != timerep.Id)
                {
                    return BadRequest("Time report ID dosnt exists.");
                }

                var repToUpdate = await _timeReportRepo.GetSingel(id);
                if (repToUpdate == null)
                {
                    return NotFound($"Time report with Id: '{id}' could not be found in the database");
                }
                return await _timeReportRepo.Update(repToUpdate);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update Time report in database.");
            }
        }
    }
}
