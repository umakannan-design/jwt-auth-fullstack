using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDTO dto);
        Task RegisterAsync(RegisterDTO dto);
    }
}
