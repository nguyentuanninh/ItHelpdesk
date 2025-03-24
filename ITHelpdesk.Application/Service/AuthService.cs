using AutoMapper;
using ITHelpdesk.Application.DTOs.Authen;
using ITHelpdesk.Application.Interfaces;
using ITHelpdesk.Domain.Entities;
using ITHelpdesk.Infrastructure.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace ITHelpdesk.Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly string secretKey;


        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            secretKey = configuration.GetSection("ApiSettings:Secret").Value;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDTO)
        {
            var user = (await _unitOfWork.Employee.FindAsync(u => u.Username.ToLower() == loginRequestDTO.UserName.ToLower())).FirstOrDefault();

            if (user == null)
            {
                return new LoginResponseDto() { Token = "", Id = 0 };
            }

            // Check if the account is disabled
            if (!user.IsActive)
            {
                return new LoginResponseDto() { Token = "", Id = -1 };
            }

            bool isValid = BCrypt.Net.BCrypt.Verify(loginRequestDTO.Password, user.Password);

            if (!isValid)
            {
                return new LoginResponseDto() { Token = "", Id = 0 };
            }

            // Generate JWT Token

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", user.Id.ToString()),
                    new Claim("username", user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToString().ToLower())
                }),
                Expires = DateTime.Now.AddHours(240),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new LoginResponseDto() { Token = tokenHandler.WriteToken(token), Id = user.Id };
        }

        public async Task<bool> Register(RegisterRequestDto registerRequestDTO)
        {
            var user = _mapper.Map<Employee>(registerRequestDTO);

            // Check if the username already exists
            var existingUser = (await _unitOfWork.Employee.FindAsync(u => u.Username.ToLower() == registerRequestDTO.Username.ToLower())).FirstOrDefault();
            if (existingUser != null)
            {
                return false;
            }

            // Hash the password
            user.Password = BCrypt.Net.BCrypt.HashPassword(registerRequestDTO.Password);

            await _unitOfWork.Employee.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

    }
}
