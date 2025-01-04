using System.ComponentModel.DataAnnotations;

namespace Authentication.Models
{
    public class UserInputModel
    {

        [Required]

        [StringLength(100, MinimumLength = 5)]

        public string Username { get; set; }


        [Required]
        [EmailAddress]

        public string Email { get; set; }

    }

}
