using JwtExample.Dtos;
using JwtExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtExample.Services
{
    public interface IUserRepositoryService
    {
        UserDto GetUser(UserModel userModel);
    }
}
