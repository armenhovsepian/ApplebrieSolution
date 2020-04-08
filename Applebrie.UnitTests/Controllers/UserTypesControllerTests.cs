using Applebrie.Core.Entities;
using Applebrie.Core.Interfaces;
using Applebrie.WebApi.Controllers;
using Applebrie.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Applebrie.UnitTests.Controllers
{
    [Category("UnitTests")]
    public class UserTypesControllerTests
    {
        private UserTypesController _controller;
        private Mock<IUserTypeRepository> _userTypeRepository;
        private Mock<IMapper> _mapper;

        private static CancellationToken _ct => CancellationToken.None;

        [SetUp]
        public void Setup()
        {
            _userTypeRepository = new Mock<IUserTypeRepository>();

            _mapper = new Mock<IMapper>();

            _controller = new UserTypesController(_userTypeRepository.Object, _mapper.Object);
        }

        [Test]
        public async Task GetUserType_UserTypeNotExists_ShouldReturnsNotFound()
        {
            _userTypeRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>(), _ct))
                .ReturnsAsync(default(UserType));

            var actionResult = await _controller.GetUserTypeAsync(It.IsAny<int>(), _ct);

            Assert.IsNull(actionResult.Value);
            Assert.IsInstanceOf<NotFoundResult>(actionResult.Result);
        }

        [Test]
        public async Task GetUserType_UserTypeExists_ShouldReturnsOK()
        {
            _userTypeRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>(), _ct))
                .ReturnsAsync(new UserType { Name = "ut" });

            var actionResult = await _controller.GetUserTypeAsync(It.IsAny<int>(), CancellationToken.None);

            Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);

        }

        [Test]
        public async Task CreateUserType_UserTypeCreated_ShouldReturnsCreatedAtActionResult()
        {
            _userTypeRepository.Setup(r => r.AddAsync(It.IsAny<UserType>(), _ct));

            var model = new UserTypeFormModel { Name = "user type 1" };
            var actionResult = await _controller.CreateUserTypeAsync(model, _ct);


            Assert.IsInstanceOf<CreatedAtActionResult>(actionResult);
            var result = actionResult as CreatedAtActionResult;
            Assert.AreEqual(result.ActionName, "GetUserTypeAsync");
        }

    }
}
