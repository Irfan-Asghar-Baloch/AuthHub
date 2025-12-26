using System;
using System.Collections.Generic;
using System.Text;

namespace AuthHub.Application.Interfaces.Security
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string hashedPassword);
    }
}
