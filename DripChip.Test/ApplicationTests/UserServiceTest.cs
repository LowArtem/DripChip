using DripChip.Application.Dto;
using DripChip.Application.Services.Common;
using DripChip.Core.Entities;
using DripChip.Core.Interfaces;
using Moq;

namespace DripChip.Test.ApplicationTests;

public class UserServiceTest
{
    private static List<User> TestUsers = new()
    {
        new User(1, "Rory", "Cook", "willa75@hotmail.com", "password"),
        new User(2, "Ryan", "Green", "sallie.orn18@hotmail.com", "password"),
        new User(3, "Archie", "Ball", "blair_doyle@yahoo.com", "password"),
        new User(4, "Jean", "Lee", "donavon45@yahoo.com", "password"),
        new User(5, "Ricky", "Lopez", "lina_hammes97@hotmail.com", "password"),
        new User(6, "Michelle", "Brown", "rylan.hayes58@hotmail.com", "password"),
        new User(7, "Elizabeth", "Paul", "gianni.jaskolski20@gmail.com", "password"),
        new User(8, "William", "Morales", "vella8@hotmail.com", "password"),
        new User(9, "Frances", "West", "ines.windler70@yahoo.com", "password"),
        new User(10, "Frances", "Ball", "aliyah.swift1@hotmail.com", "password")
    };

    // Doesn't work. Seems like something is wrong with mock setup...
    // It somehow doesn't return given value but returns null instead.
    [Fact]
    public void GetInfo_Test()
    {
        var expected = new UserResponseDto.Info(2, "Ryan", "Green", "sallie.orn18@hotmail.com");
        
        var userRepoMock = new Mock<IRepository<User, int>>();
        userRepoMock
            .Setup(r => r.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(TestUsers[1]);

        var animalRepoMock = new Mock<IRepository<Animal, long>>();

        var userService = new UserService(userRepoMock.Object, animalRepoMock.Object);

        var test = userService.GetInfo(2).Result;
        
        userRepoMock.Verify();
        Assert.True(test.IsSuccess);
        Assert.Equal(expected, test.Value);
    }
}