using ITHelpdesk.Domain.Entities;
using ITHelpdesk.Infrastructure.Context;
using ITHelpdesk.Infrastructure.Repositories.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Infrastructure.Repositories.Interface
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
