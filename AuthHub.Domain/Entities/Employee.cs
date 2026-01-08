using System;
using System.Collections.Generic;
using System.Text;

namespace AuthHub.Domain.Entities
{
    public class Employee
    {
        public long Id { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
    }

}
