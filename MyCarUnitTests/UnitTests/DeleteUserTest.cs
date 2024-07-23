using System.Linq.Expressions;

namespace MyCarUnitTests.UnitTests
{
    public class DeleteUserTest
    {

        [Fact]
        public async Task DeleteUserSucess_ShouldResultTrue()
        {
            //Arrange
            var userId = 1;

            var usersList = new List<UserModel>()
            {
                new UserModel{Id = 1, Email = "string1", Name = "string1", Surname = "string1", Password = "string1", Phone = "string1", Username = "string1", AdvertisingModel = null, UserRegisterModel = null},
                new UserModel{Id = 2, Email = "string2", Name = "string2", Surname = "string2", Password = "string2", Phone = "string2", Username = "string2", AdvertisingModel = null, UserRegisterModel = null}
            };

            var user = usersList.BuildMock();

            var mockBaseRepository = new Mock<IBaseRepository<UserModel>>();
            mockBaseRepository.Setup(rep => rep.GetByWhere(It.IsAny<Expression<Func<UserModel, bool>>>())).Returns(user);
            mockBaseRepository.Setup(rep => rep.DeleteAsync(It.IsAny<UserModel>())).Returns(Task.FromResult<UserModel>(null));

            var userService = new UserService();
            var fieldInfo = typeof(UserService).GetField("_baseRepository", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(userService, mockBaseRepository.Object);

            //Act
            var serviceResult = await userService.RemoveUserById(userId);


            //Assert
            mockBaseRepository.Verify(rep => rep.DeleteAsync(It.Is<UserModel>(u => u.Id == userId)), Times.Once);
            Assert.True(serviceResult);
        }

        [Fact]
        public async Task DeleteUserFailed_ShouldResultFalse()
        {
            var userId = 1;
            var usersList = new List<UserModel>();

            var user = usersList.BuildMock();
            //Arrange
            var mockBaseRepository = new Mock<IBaseRepository<UserModel>>();
            mockBaseRepository.Setup(rep => rep.GetByWhere(It.IsAny<Expression<Func<UserModel, bool>>>())).Returns(user);
            mockBaseRepository.Setup(rep => rep.DeleteAsync(It.IsAny<UserModel>())).Returns(Task.FromResult<UserModel>(null));

            var userService = new UserService();
            var fieldInfo = typeof(UserService).GetField("_baseRepository", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(userService, mockBaseRepository.Object);

            //Act
            var serviceResult = await userService.RemoveUserById(userId);


            //Assert
            mockBaseRepository.Verify(rep => rep.DeleteAsync(It.Is<UserModel>(u => u.Id == userId)), Times.Never);
            Assert.False(serviceResult);
        }

    }
}