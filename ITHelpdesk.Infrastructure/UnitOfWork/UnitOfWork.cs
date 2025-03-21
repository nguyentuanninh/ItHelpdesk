using ITHelpdesk.Infrastructure.Context;
using ITHelpdesk.Infrastructure.Repositories.Implement;
using ITHelpdesk.Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDBContext _context;

        public UnitOfWork(ApplicationDBContext context, IEmployeeRepository employeeRepository)
        {
            _context = context;
            Employee = employeeRepository;
        }

        public IEmployeeRepository Employee { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
