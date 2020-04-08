namespace Applebrie.Core.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        //[Required]
        //[StringLength(64)]
        public string FirstName { get; set; }

        //[Required]
        //[StringLength(64)]
        public string LastName { get; set; }

        public UserTypeDto UserType { get; set; }
    }
}
