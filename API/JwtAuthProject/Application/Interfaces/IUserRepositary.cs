using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IUserRepositary
    {
        Task<User> GetByUserAsync(string username);
        Task AddUserAsync(User user);     
       
    }
}
