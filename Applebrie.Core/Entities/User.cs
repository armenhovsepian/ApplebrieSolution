using System;

namespace Applebrie.Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }


        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

    }
}
