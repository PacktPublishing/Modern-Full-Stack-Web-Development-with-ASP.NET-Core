namespace Chapter5
{
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [StringLength(500, ErrorMessage = "Message is too long")]
        public string Message { get; set; }
    }

}


