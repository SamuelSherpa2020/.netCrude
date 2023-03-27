using System.ComponentModel.DataAnnotations;

namespace MvcCoreTutorial.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; } = string.Empty;


        [System.ComponentModel.DataAnnotations.Required]
        public int Age { get; set; }


        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
