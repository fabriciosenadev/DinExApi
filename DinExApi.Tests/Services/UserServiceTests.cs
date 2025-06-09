using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DinExApi.Business.Services;
using DinExApi.Business.Interfaces;
using DinExApi.Domain.Models;
using DinExApi.Infrastructure.Enums;
using Moq;
using Xunit;

namespace DinExApi.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private readonly Mock<ICategoryService> _categoryServiceMock = new Mock<ICategoryService>();
        private readonly Mock<ICategoryUserService> _categoryUserServiceMock = new Mock<ICategoryUserService>();
        private readonly UserService _service;

        public UserServiceTests()
        {
            _service = new UserService(
                _userRepositoryMock.Object,
                _categoryServiceMock.Object,
                _categoryUserServiceMock.Object
            );
        }

        [Fact]
        public async Task AddAsync_SuccessfulRegistration_DoesNotThrow()
        {
            var user = new User { Id = 1, Email = "test@example.com" };
            _userRepositoryMock.Setup(r => r.AddAsync(user)).ReturnsAsync(1);

            await _service.AddAsync(user);

            _userRepositoryMock.Verify(r => r.AddAsync(user), Times.Once);
        }

        [Fact]
        public async Task AddAsync_WhenRepositoryFails_ThrowsException()
        {
            var user = new User { Id = 1, Email = "test@example.com" };
            _userRepositoryMock.Setup(r => r.AddAsync(user)).ReturnsAsync(0);

            await Assert.ThrowsAsync<Exception>(() => _service.AddAsync(user));
        }

        [Fact]
        public async Task ComposeUserCreation_ReturnsUserAndAddsRelations()
        {
            var user = new User { Id = 5, Email = "test@example.com" };
            var categories = new List<Category> { new Category { Id = 1 }, new Category { Id = 2 } };

            _userRepositoryMock.Setup(r => r.AddAsync(user)).ReturnsAsync(1);
            _categoryServiceMock.Setup(s => s.FindAllStandardAsync()).ReturnsAsync(categories);
            _categoryUserServiceMock
                .Setup(s => s.ComposeRelationCreationAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(ErrorCode.Empty);

            var result = await _service.ComposeUserCreation(user) as User;

            Assert.NotNull(result);
            _userRepositoryMock.Verify(r => r.AddAsync(user), Times.Once);
            _categoryUserServiceMock.Verify(
                s => s.ComposeRelationCreationAsync(It.IsAny<int>(), user.Id),
                Times.Exactly(categories.Count)
            );
        }
    }
}
