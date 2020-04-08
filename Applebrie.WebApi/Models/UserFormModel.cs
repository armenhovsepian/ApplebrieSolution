using System.ComponentModel.DataAnnotations;

namespace Applebrie.WebApi.Models
{
    public class UserFormModel
    {
        public class UserTypeModel
        {
            [Range(1, int.MaxValue)]
            public int Id { get; set; }

        }

        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64)]
        public string LastName { get; set; }

        public UserTypeModel UserType { get; set; }
    }



}
