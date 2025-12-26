using AuthHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthHub.Application.Interfaces.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
