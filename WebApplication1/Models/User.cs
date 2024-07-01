using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int Age { get; set; }
        private const int PhoneLength = 11;
        public bool IsValid(string Number)
        {
            if (Number.Length != PhoneLength) return false;
            return true;
        }
    }
}
