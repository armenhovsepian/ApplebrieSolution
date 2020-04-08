using System.ComponentModel.DataAnnotations;

namespace Applebrie.WebApi.Models
{
    public class UserTypeFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }
    }
}
