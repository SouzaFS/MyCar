namespace MyCarUnitTests.UnitTests
{
    public class GetAllUsersTest
    {

        [Fact]
        public async Task GetAllUsersSuccess_ShouldResultListOfUsers()
        {
            //Arrange
            var usersList = new List<UserModel>()
            {
                new UserModel{Id = 1, Email = "string1", Name = "string1", Surname = "string1", Password = "string1", Phone = "string1", Username = "string1", AdvertisingModel = null, UserRegisterModel = null},
                new UserModel{Id = 2, Email = "string2", Name = "string2", Surname = "string2", Password = "string2", Phone = "string2", Username = "string2", AdvertisingModel = null, UserRegisterModel = null}
            };

            var users = usersList.BuildMock();

            var mockBaseRepository = new Mock<IBaseRepository<UserModel>>();
            mockBaseRepository.Setup(rep => rep.GetAll()).Returns(users);

            var userService = new UserService();
            var fieldInfo = typeof(UserService).GetField("_baseRepository", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(userService, mockBaseRepository.Object);

            //Act
            var serviceResult = await userService.GetUsers();


            //Assert
            Assert.NotNull(users);
            Assert.Equal(users.ToList(), serviceResult);
        }

        [Fact]
        public async Task GetAllUsersFailed_ShouldResultEmpty()
        {
            var usersList = new List<UserModel>();

            var users = usersList.BuildMock();
            //Arrange
            var mockBaseRepository = new Mock<IBaseRepository<UserModel>>();
            mockBaseRepository.Setup(rep => rep.GetAll()).Returns(users);

            var userService = new UserService();
            var fieldInfo = typeof(UserService).GetField("_baseRepository", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(userService, mockBaseRepository.Object);

            //Act
            var serviceResult = await userService.GetUsers();


            //Assert
            Assert.NotNull(serviceResult);
            Assert.Empty(serviceResult);
        }

    }
}