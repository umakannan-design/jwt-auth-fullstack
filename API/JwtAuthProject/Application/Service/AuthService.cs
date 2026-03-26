using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly JwtService _jwtService;
        private readonly IUserRepositary _repo;

        public AuthService(JwtService jwtService , IUserRepositary repo)
        {
            _jwtService = jwtService;
            _repo = repo;
        }
        //public async  Task<string> LoginAsync(LoginDTO dto)
        //{
        //    var user = await _repo.GetByUserAsync(dto.Username);
        //    if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
        //    {
        //        throw new Exception("Invalid Credencials");
        //    }
        //    return _jwtService.GenerateToken(user);
        //}

        public async Task<string> LoginAsync(LoginDTO dto)
        {
            var user = await _repo.GetByUserAsync(dto.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                return null;
            }

            return _jwtService.GenerateToken(user);
        }

        public async Task RegisterAsync(RegisterDTO dto)
        {
            var user = new User
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            await _repo.AddUserAsync(user);
        }
    }
}
