using System;

namespace Exquisite.BusinessLogic.UserManagement.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string[] Roles { get; set; }
    }
}
