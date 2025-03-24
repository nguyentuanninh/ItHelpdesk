using ITHelpdesk.Application.DTOs.Authen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDTO);
        Task<bool> Register(RegisterRequestDto registerRequestDTO);

    }
}
