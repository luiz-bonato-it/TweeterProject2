using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace TwitterProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato de e-mail inválido!")]
        public string Email { get; set; }
        [Required]
        public string Descricao { get; set; }

    }
}