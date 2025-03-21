using ITHelpdesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<IEnumerable<Employee>> FindEmployeeAsync(Expression<Func<Employee, bool>> filter);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<bool> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);

        Task<bool> AddEmployeeAsCollaboratorAsync(int employeeId, string repoName);
        Task<string> GenerateGmailForEmployee(int employeeId);
    }
}
