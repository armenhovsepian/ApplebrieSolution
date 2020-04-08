using System;
using System.Collections.Generic;

namespace Applebrie.Core.Entities
{
    public class UserType : BaseEntity
    {
        public string Name { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }


        public ICollection<User> Users { get; set; }

    }
}
