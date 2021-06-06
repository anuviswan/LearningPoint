using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsolatedFunctionApps.Dtos;

namespace IsolatedFunctionApps.Services
{
    public interface IMockDataService
    {
        UserDto CreateUser(string userName);
    }
}
