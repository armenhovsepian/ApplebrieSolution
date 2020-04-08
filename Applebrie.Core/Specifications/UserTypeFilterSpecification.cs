using Applebrie.Core.Entities;

namespace Applebrie.Core.Specifications
{
    public class UserTypeFilterSpecification : BaseSpecification<UserType>
    {
        public UserTypeFilterSpecification(int skip, int take)
        {
            ApplyPaging(skip, take);
        }
    }
}
