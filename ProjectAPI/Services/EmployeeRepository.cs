using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Services
{
    public class EmployeeRepository : IProgramRepository<Employee>
    {
        private ProjectDbContext _appContext;
        public EmployeeRepository(ProjectDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Employee> Add(Employee newEntity) // klar
        {
            var result = await _appContext.Employees.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> Delete(int id)
        {
            var result = await _appContext.Employees.FirstOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                _appContext.Employees.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }// klar

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _appContext.Employees.ToListAsync();
        }// klar

        public Task<Employee> GetEmpWithProject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmpWithTime(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmpWithTimeSpecWeek(int empId, int weekId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetProjectWithEmp(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetSingel(int id)
        {
            return await _appContext.Employees
               .FirstOrDefaultAsync(p => p.Id == id);
        }// klar

        public async Task<Employee> Update(Employee Entity)
        {
            var result = await _appContext.Employees.FirstOrDefaultAsync(p => p.Id == Entity.Id);
            if (result != null)
            {

                result.FName = Entity.FName;
                result.LName = Entity.LName;
                result.Titel = Entity.Titel;
               

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }// klar
    }
}
