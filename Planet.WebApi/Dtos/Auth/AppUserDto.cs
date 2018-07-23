using System.Collections.Generic;

namespace Planet.WebApi.Dtos.Auth
{
    public class AppUserDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string District { get; set; }

        public string Province { get; set; }

        public string Avatar { get; set; }

        public string BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public bool? Status { get; set; }

        public bool? Gender { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}