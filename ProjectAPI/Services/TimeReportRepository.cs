using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Services
{
    public class TimeReportRepository : IProgramRepository<TimeReport>
    {

        private ProjectDbContext _appContext;
        public TimeReportRepository(ProjectDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<TimeReport> Add(TimeReport newEntity)
        {
            var result = await _appContext.TimeReports.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        } //Klar

        public async Task<TimeReport> Delete(int id)
        {
            var result = await _appContext.TimeReports.FirstOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                _appContext.TimeReports.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }//Klar

        public async Task<IEnumerable<TimeReport>> GetAll()
        {
            return await _appContext.TimeReports.ToListAsync();
        }//Klar



        public async Task<TimeReport> GetSingel(int id)
        {
            return await _appContext.TimeReports
               .FirstOrDefaultAsync(p => p.Id == id);
        }//Klar

        public async Task<TimeReport> Update(TimeReport Entity)
        {
            var result = await _appContext.TimeReports.FirstOrDefaultAsync(p => p.Id == Entity.Id);
            if (result != null)
            {

                result.WeekNumber = Entity.WeekNumber;
                result.ProjectId = Entity.ProjectId;
                result.EmployeeId = Entity.EmployeeId;
                result.HoursWorked = Entity.HoursWorked;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }//Klar
    
        public async Task<IEnumerable<TimeReport>> GetEmpWithTime(int id)
        {

           
            var res = await _appContext.TimeReports.Include(e => e.Employee).Where(em => em.EmployeeId == id).ToListAsync();

            if (res != null)
            {
                return res;
            }
            return null;




        }//Klar

        public async Task<IEnumerable<TimeReport>> GetEmpWithProject(int id)
        {
            var res = await _appContext.TimeReports.Include(x => x.Project).Include(x => x.Employee).Where(x => x.ProjectId == id).ToListAsync();

            if (res != null)
            {
                return res;
            }
            return null;
        }//Klar

        public async Task<IEnumerable<TimeReport>> GetEmpWithTimeSpecWeek(int empId, int weekId)
        {
            var res = await _appContext.TimeReports.Include(x => x.Employee).Where(x => x.EmployeeId == empId).Where(x => x.WeekNumber == weekId).ToListAsync();

            if (res != null)
            {
                return res;
            }
            return null;
        }//Klar
    }
}
