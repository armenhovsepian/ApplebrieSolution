using Applebrie.Core.Entities;

namespace Applebrie.Core.Specifications
{
    public class UserFilterSpecification : BaseSpecification<User>
    {
        public UserFilterSpecification(int skip, int take, int? userTypeId) 
            : base(user => (!userTypeId.HasValue || user.UserTypeId == userTypeId))
        {
            AddInclude(u => u.UserType);
            ApplyPaging(skip, take);
        }
    }
}
