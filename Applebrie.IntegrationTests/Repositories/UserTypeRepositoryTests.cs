using Applebrie.Core.Entities;
using Applebrie.Core.Interfaces;
using Applebrie.Infrastructure.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Applebrie.IntegrationTests.Repositories
{
    [Category("IntegrationTests")]
    public class UserTypeRepositoryTests : IntegrationTestBase
    {

        private IUserTypeRepository _userTypeRepository;

        [SetUp]
        public void Setup()
        {
            var context = GivenGlobalAppDbContext();
            _userTypeRepository = new UserTypeRepository(context);
        }

        [Test]
        public async Task CanCreatUserType()
        {
            var userType = new UserType { Name = "Test Type" };

            await _userTypeRepository.AddAsync(userType, CancellationToken.None);

            Assert.AreNotEqual(userType.Id, 0);
        }


        [Test]
        public async Task CanDeleteUserType()
        {
            var userType = await CreateUserTypeWithManyUsers();

            await _userTypeRepository.DeleteAsync(userType, CancellationToken.None);
            userType = await _userTypeRepository.GetByIdAsync(userType.Id, CancellationToken.None);

            Assert.IsNull(userType);
        }


        private async Task<UserType> CreateUserTypeWithManyUsers()
        {
            var userType = new UserType
            {
                Name = "Test Type",
                Users = new List<User>
                {
                    new User{FirstName = "firstname1", LastName = "lastname1"},
                    new User{FirstName = "firstname2", LastName = "lastname2"}
                }
            };

            await _userTypeRepository.AddAsync(userType, CancellationToken.None);
            return userType;
        }
    }
}
