using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Applebrie.Core.Entities
{
    public class UserType : BaseEntity
    {
        public UserType()
        {
            Users = new Collection<User>();
        }
        public string Name { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }


        public virtual ICollection<User> Users { get; set; }

    }
}
