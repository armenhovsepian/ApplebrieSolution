using Applebrie.Core.Entities;
using NUnit.Framework;

namespace Applebrie.UnitTests.Entities
{
    [Category("UnitTests")]
    public class UserTypeTests
    {

        [Test]
        public void UserTypesIsInitiallyEmpty()
        {
            var userType = new UserType();

            Assert.AreEqual(userType.Users.Count, 0);
        }
    }
}
