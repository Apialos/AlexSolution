using System.ComponentModel.DataAnnotations;

namespace MyBusiness.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }
    }
}