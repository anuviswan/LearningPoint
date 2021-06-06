using System;
using IsolatedFunctionApps.Dtos;

namespace IsolatedFunctionApps.Services
{
    public class MockDataService : IMockDataService
    {
        private readonly Random _randomGenerator = new Random();
        public UserDto CreateUser(string userName)
        {
            return new UserDto
            {
                Name = "Anu Viswan",
                Id = _randomGenerator.Next()
            };
        }
    }
}
