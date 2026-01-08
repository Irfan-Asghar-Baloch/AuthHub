using AuthHub.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthHub.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<Response> AddAsync(IEmployeeService emp);
    }
}
