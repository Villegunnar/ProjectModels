using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Services
{
    public interface IProgramRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingel(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T Entity);
        Task<T> Delete(int id);
        Task<T> GetEmpWithTime(int id);
        Task<T> GetProjectWithEmp(int id);

        Task<T> GetEmpWithProject(int id);
        Task<T> GetEmpWithTimeSpecWeek(int empId, int weekId);





    }
}
