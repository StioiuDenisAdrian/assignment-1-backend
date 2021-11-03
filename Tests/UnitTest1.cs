using assignment_1_backend.Repositories.Interfaces;
using assignment_1_backend.Services;
using assignment_1_backend.Services.Interfaces;
using Moq;
using System;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {

        private IAccountService accountService;
        private Mock<IUserRepository> userRepository;

        [Fact]
        public void Test1()
        {
            userRepository = new Mock<IUserRepository>();
            accountService = new AccountService(userRepository.Object);
            Assert.True(accountService.GetCurrentUser("admin") != null);
        }
    }
}
