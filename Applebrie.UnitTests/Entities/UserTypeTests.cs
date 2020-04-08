using Applebrie.Core.Entities;
using FluentAssertions;
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

            userType.Users.Count.Should().Be(0);
        }
    }
}
