using ITHelpdesk.Application.Interfaces;
using ITHelpdesk.Domain.Entities;
using ITHelpdesk.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGithubService _githubService;
        private readonly IGoogleService _googleService;

        public EmployeeService(
            IUnitOfWork unitOfWork,
            IGithubService githubService,
            IGoogleService googleService)
        {
            _unitOfWork = unitOfWork;
            _githubService = githubService;
            _googleService = googleService;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _unitOfWork.Employee.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _unitOfWork.Employee.GetAllAsync();
        }

        public async Task<IEnumerable<Employee>> FindEmployeeAsync(Expression<Func<Employee, bool>> filter)
        {
            return await _unitOfWork.Employee.FindAsync(filter);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            await _unitOfWork.Employee.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            var existing = await _unitOfWork.Employee.GetByIdAsync(employee.Id);
            if (existing == null) return false;

            existing.Name = employee.Name;
            existing.Email = employee.Email;
            existing.GithubUsername = employee.GithubUsername;

            await _unitOfWork.Employee.UpdateAsync(existing);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.Employee.GetByIdAsync(id);
            if (employee == null) return false;
            await _unitOfWork.Employee.DeleteAsync(employee.Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddEmployeeAsCollaboratorAsync(int employeeId, string repoName)
        {
            var employee = await GetEmployeeByIdAsync(employeeId);
            if (employee == null || string.IsNullOrWhiteSpace(employee.GithubUsername))
                return false;

            var result = await _githubService.AddCollaboratorAsync(repoName, employee.GithubUsername, "push");
            return result;
        }

        public async Task<string> GenerateGmailForEmployee(int employeeId)
        {
            var employee = await GetEmployeeByIdAsync(employeeId);
            if (employee == null) return null;

            var generatedEmail = await _googleService.CreateGoogleAccountAsync(employee.Name);

            employee.Email = generatedEmail;
            await UpdateEmployeeAsync(employee);

            return generatedEmail;
        }

    }
}
