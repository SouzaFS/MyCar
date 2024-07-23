namespace MyCarUnitTests.UnitTests
{
    public class UpdateUserTest
    {
        [Fact]
        public async Task UpdateUserSuccess_ShouldResultUpdated()
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
            mockBaseRepository.Setup(a => a.UpdateAsync(It.IsAny<UserModel>())).ReturnsAsync(user);
            var userService = new UserService();

            var fieldInfo = typeof(UserService).GetField("_baseRepository", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(userService, mockBaseRepository.Object);

            //Act
            var serviceResult = await userService.UpdateUser(1, userDTO);
            var expectedResult = user;

            //Assert
            Assert.NotNull(user);
            Assert.Equal(expectedResult, serviceResult);

        }

        [Fact]
        public async Task UpdateUserFailed_ShouldResultNull()
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
            mockBaseRepository.Setup(a => a.UpdateAsync(It.IsAny<UserModel>())).ReturnsAsync(user);
            var userService = new UserService();

            var fieldInfo = typeof(UserService).GetField("_baseRepository", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(userService, mockBaseRepository.Object);

            //Act
            UserModel serviceResult = await userService.UpdateUser(1, userDTO);

            //Assert
            Assert.Null(serviceResult);
        }
    }
}