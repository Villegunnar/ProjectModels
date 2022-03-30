using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Services
{
    public class ProjectRepository : IProgramRepository<Project>
    {
        private ProjectDbContext _appContext;
        public ProjectRepository(ProjectDbContext appContext) 
        {
            _appContext = appContext;
        }
        public async Task<Project> Add(Project newEntity)
        {
            var result = await _appContext.Projects.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        } //klar

        public async Task<Project> Delete(int id)
        {
            var result = await _appContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                _appContext.Projects.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }//klar

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _appContext.Projects.ToListAsync();
        } //klar

        public Task<Project> GetEmpWithProject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetEmpWithTime(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetEmpWithTimeSpecWeek(int empId, int weekId)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectWithEmp(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetSingel(int id)
        {
            return await _appContext.Projects
             .FirstOrDefaultAsync(p => p.Id == id);
        }//klar

        public async Task<Project> Update(Project Entity)
        {
            var result = await _appContext.Projects.FirstOrDefaultAsync(p => p.Id == Entity.Id);
            if (result != null)
            {

                result.ProjectName = Entity.ProjectName;
           

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }//klar
    }
}
