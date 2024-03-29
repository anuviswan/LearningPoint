﻿using JwtExample.Dtos;

namespace JwtExample.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, UserDto user);
    }
}
