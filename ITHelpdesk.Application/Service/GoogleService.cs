using ITHelpdesk.Application.Interfaces;
using ITHelpdesk.Domain.Entities;
using ITHelpdesk.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Application.Service
{
    public class GoogleService : IGoogleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GoogleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> CreateGoogleAccountAsync(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be empty.", nameof(fullName));
            }

            var nameParts = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length < 2)
            {
                throw new ArgumentException("Full name must contain at least first name and last name.");
            }

            string firstName = nameParts.Last().ToLower();  
            string lastName = nameParts.First().ToLower();
            string baseEmail = $"{firstName}.{lastName}@seta-international.vn";

            // check if email already exists
            string email = baseEmail;
            IEnumerable<Employee> employees= await _unitOfWork.Employee.FindAsync(e=> e.Email== email);
            int count = employees.Count();

            //generate email
            email = count > 0? 
                $"{firstName}.{lastName}{count:D2}@seta-international.vn" 
                :
                $"{firstName}.{lastName}@seta-international.vn";
            
            return email;
        }
    }
}
