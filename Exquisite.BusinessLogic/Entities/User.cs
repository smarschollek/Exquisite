using System;

namespace Exquisite.BusinessLogic.Entities
{
    internal class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string[] Roles { get; set; }
    }
}
