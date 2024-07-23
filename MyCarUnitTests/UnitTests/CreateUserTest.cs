namespace MyCarUnitTests.UnitTests
{
    public class CreateUserTest
    {
        [Fact]
        public async Task CreateUserSuccess_ShouldResultCreated()
        {
            //Arrange
            var user = new UserModel()
            {
                Name = "NameTest",
                Id = 1,
                Surname = "SurnameTest",
                Username = "UsernameTest",
                AdvertisingModel = null,
                Email = "email@test.com",
                Password = "PasswordTest",
                Phone = "40029822",
                UserRegisterModel = null
            };
            var userDTO = UserMapper.FromModelToDTO(user);
            var mockBaseRepository = new Mock<IBaseRepository<UserModel>>();
            mockBaseRepository.Setup(a => a.CreateAsync(It.IsAny<UserModel>())).ReturnsAsync(user);
            var userService = new UserService();

            var fieldInfo = typeof(UserService).GetField("_baseRepository", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(userService, mockBaseRepository.Object);

            //Act
            var serviceResult = await userService.CreateUser(userDTO);
            var expectedResult = user;

            //Assert
            Assert.NotNull(user);
            Assert.Equal(expectedResult, serviceResult);

        }

        [Fact]
        public async Task CreateUserFailed_ShouldResultNull()
        {
            var user = new UserModel()
            {
                Name = null,
                Id = 0,
                Surname = null,
                Username = null,
                AdvertisingModel = null,
                Email = null,
                Password = null,
                Phone = null,
                UserRegisterModel = null
            };
            var userDTO = UserMapper.FromModelToDTO(user);
            //Arrange
            var mockBaseRepository = new Mock<IBaseRepository<UserModel>>();
            mockBaseRepository.Setup(a => a.CreateAsync(It.IsAny<UserModel>())).ReturnsAsync(user);
            var userService = new UserService();

            var fieldInfo = typeof(UserService).GetField("_baseRepository", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(userService, mockBaseRepository.Object);

            //Act
            UserModel serviceResult = await userService.CreateUser(userDTO);

            //Assert
            Assert.Null(serviceResult);
        }
    }
}