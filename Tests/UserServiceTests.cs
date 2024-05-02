using AutoMapper;
using BLL.DTO.Users;
using BLL.Services;
using DAL.Entities;
using DAL.Filters;
using DAL.Repositories.Contracts;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework.Internal;
using System.Security.Policy;

namespace Tests
{
    public class UserServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetFollowing()
        {
            User user1 = new User();
            user1.Id = "abc"; user1.Name = "Pepa"; user1.UserName = "pepik123";
            User user2 = new User();
            user2.Id = "abcde"; user2.Name = "Karel"; user2.UserName = "kaja1234";
            List<User> users = new List<User> { user1, user2 };

            GetFollowerDTO user1DTO = new();
            user1DTO.Id = "abc"; user1DTO.Name = "Pepa"; user1DTO.Username = "pepik123"; user1DTO.IsFollowed = true;
            GetFollowerDTO user2DTO = new();
            user2DTO.Id = "abcde"; user2DTO.Name = "Karel"; user2DTO.Username = "kaja1234"; user2DTO.IsFollowed = false;
            List<GetFollowerDTO> userDTOs = new List<GetFollowerDTO> { user1DTO, user2DTO };

            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(m => m.GetFollowing(It.IsAny<string>()).Result).Returns(users);
            mockUserRepo.Setup(m => m.IsFollowed(user1.Id).Result).Returns(true);
            mockUserRepo.Setup(m => m.IsFollowed(user2.Id).Result).Returns(false);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.UserRepository).Returns(mockUserRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<List<GetFollowerDTO>>(users)).Returns(userDTOs);

            var us = new UserService(mockUnitOfWork.Object, mockMapper.Object);

            Assert.That(us.GetFollowing("x").Result, Is.EquivalentTo(userDTOs));
        }

        [Test]
        public void GetFollowers()
        {
            User user1 = new User();
            user1.Id = "abc"; user1.Name = "Pepa"; user1.UserName = "pepik123";
            User user2 = new User();
            user2.Id = "abcde"; user2.Name = "Karel"; user2.UserName = "kaja1234";
            List<User> users = new List<User> { user1, user2 };

            GetFollowerDTO user1DTO = new();
            user1DTO.Id = "abc"; user1DTO.Name = "Pepa"; user1DTO.Username = "pepik123"; user1DTO.IsFollowed = true;
            GetFollowerDTO user2DTO = new();
            user2DTO.Id = "abcde"; user2DTO.Name = "Karel"; user2DTO.Username = "kaja1234"; user2DTO.IsFollowed = false;
            List<GetFollowerDTO> userDTOs = new List<GetFollowerDTO> { user1DTO, user2DTO };

            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(m => m.GetFollowers(It.IsAny<string>()).Result).Returns(users);
            mockUserRepo.Setup(m => m.IsFollowed(user1.Id).Result).Returns(true);
            mockUserRepo.Setup(m => m.IsFollowed(user2.Id).Result).Returns(false);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.UserRepository).Returns(mockUserRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<List<GetFollowerDTO>>(users)).Returns(userDTOs);

            var us = new UserService(mockUnitOfWork.Object, mockMapper.Object);

            Assert.That(us.GetFollowers("x").Result, Is.EquivalentTo(userDTOs));
        }

        [Test]
        public void ChangeSettings_Empty()
        {
            User user = new User();
            user.Id = "abc"; user.Name = "Pepa"; user.UserName = "pepik123"; user.Email = "pepa@okurka.com"; user.DailyGoalMs = 10000;

            ChangeUserSettingsDTO changeUserSettingsDTO = new();

            GetUserSettingsDTO getUserSettingsDTO = new GetUserSettingsDTO();
            getUserSettingsDTO.Name = "Pepa"; getUserSettingsDTO.Username = "pepik123"; getUserSettingsDTO.Email = "pepa@okurka.com"; getUserSettingsDTO.DailyGoal = 10000;

            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(m => m.GetCurrentUser()).Returns(user);

            var mockUserManager = MockUserManager(new List<User> { user });

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.UserRepository).Returns(mockUserRepo.Object);
            mockUnitOfWork.Setup(m => m.UserManager).Returns(mockUserManager.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<GetUserSettingsDTO>(user)).Returns(getUserSettingsDTO);

            var us = new UserService(mockUnitOfWork.Object, mockMapper.Object);

            Assert.That(us.ChangeSettings(changeUserSettingsDTO), Is.EqualTo(getUserSettingsDTO));
        }

        [Test]
        public void ChangeSettings_Username()
        {
            User user = new User();
            user.Id = "abc"; user.Name = "Pepa"; user.UserName = "pepik123"; user.Email = "pepa@okurka.com"; user.DailyGoalMs = 10000;

            ChangeUserSettingsDTO changeUserSettingsDTO = new();
            changeUserSettingsDTO.Username = "pepicek";

            GetUserSettingsDTO getUserSettingsDTO = new GetUserSettingsDTO();
            getUserSettingsDTO.Name = "Pepa"; getUserSettingsDTO.Username = "pepicek"; getUserSettingsDTO.Email = "pepa@okurka.com"; getUserSettingsDTO.DailyGoal = 10000;

            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(m => m.GetCurrentUser()).Returns(user);

            var mockUserManager = MockUserManager(new List<User> { user });

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.UserRepository).Returns(mockUserRepo.Object);
            mockUnitOfWork.Setup(m => m.UserManager).Returns(mockUserManager.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<GetUserSettingsDTO>(user)).Returns(getUserSettingsDTO);

            var us = new UserService(mockUnitOfWork.Object, mockMapper.Object);

            Assert.That(us.ChangeSettings(changeUserSettingsDTO), Is.EqualTo(getUserSettingsDTO));
        }

        [Test]
        public void ChangeSettings_Username_Dailygoal()
        {
            User user = new User();
            user.Id = "abc"; user.Name = "Pepa"; user.UserName = "pepik123"; user.Email = "pepa@okurka.com"; user.DailyGoalMs = 10000;

            ChangeUserSettingsDTO changeUserSettingsDTO = new();
            changeUserSettingsDTO.Username = "pepicek";
            changeUserSettingsDTO.DailyGoal = 500;

            GetUserSettingsDTO getUserSettingsDTO = new GetUserSettingsDTO();
            getUserSettingsDTO.Name = "Pepa"; getUserSettingsDTO.Username = "pepicek"; getUserSettingsDTO.Email = "pepa@okurka.com"; getUserSettingsDTO.DailyGoal = 500;

            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(m => m.GetCurrentUser()).Returns(user);

            var mockUserManager = MockUserManager(new List<User> { user });

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.UserRepository).Returns(mockUserRepo.Object);
            mockUnitOfWork.Setup(m => m.UserManager).Returns(mockUserManager.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<GetUserSettingsDTO>(user)).Returns(getUserSettingsDTO);

            var us = new UserService(mockUnitOfWork.Object, mockMapper.Object);

            Assert.That(us.ChangeSettings(changeUserSettingsDTO), Is.EqualTo(getUserSettingsDTO));
        }

        [Test]
        public void GetSettings()
        {
            User user = new User();
            user.Id = "abc"; user.Name = "Pepa"; user.UserName = "pepik123"; user.Email = "pepa@okurka.com"; user.DailyGoalMs = 10000;


            GetUserSettingsDTO getUserSettingsDTO = new GetUserSettingsDTO();
            getUserSettingsDTO.Name = "Pepa"; getUserSettingsDTO.Username = "pepik123"; getUserSettingsDTO.Email = "pepa@okurka.com"; getUserSettingsDTO.DailyGoal = 10000;

            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(m => m.GetCurrentUser()).Returns(user);


            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.UserRepository).Returns(mockUserRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<GetUserSettingsDTO>(user)).Returns(getUserSettingsDTO);

            var us = new UserService(mockUnitOfWork.Object, mockMapper.Object);

            Assert.That(us.GetSettings(), Is.EqualTo(getUserSettingsDTO));
        }

        [Test]
        public void GetUsers()
        {
            User user1 = new User();
            user1.Id = "abc"; user1.Name = "Pepa"; user1.UserName = "pepik123"; user1.ProfileImageUrl = "url";
            User user2 = new User();
            user2.Id = "abcde"; user2.Name = "Karel"; user2.UserName = "kaja1234"; user2.ProfileImageUrl = "url";
            List<User> users = new List<User> { user1, user2 };

            GetUserBriefDTO user1DTO = new();
            user1DTO.Id = "abc"; user1DTO.Name = "Pepa"; user1DTO.Username = "pepik123"; user1DTO.ProfileImageUrl = "url";
            GetUserBriefDTO user2DTO = new();
            user2DTO.Id = "abcde"; user2DTO.Name = "Karel"; user2DTO.Username = "kaja1234"; user2DTO.ProfileImageUrl = "url";
            List<GetUserBriefDTO> userDTOs = new List<GetUserBriefDTO> { user1DTO, user2DTO };

            GetUserBriefDTO user1DTOres = new();
            user1DTOres.Id = "abc"; user1DTOres.Name = "Pepa"; user1DTOres.Username = "pepik123"; user1DTOres.ProfileImageUrl = "url"; user1DTOres.IsFollowed = true;
            GetUserBriefDTO user2DTOres = new();
            user2DTOres.Id = "abcde"; user2DTOres.Name = "Karel"; user2DTOres.Username = "kaja1234"; user2DTOres.ProfileImageUrl = "url"; user2DTOres.IsFollowed = false;
            List<GetUserBriefDTO> usersDTOres = new List<GetUserBriefDTO> { user1DTOres, user2DTOres };

            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(m => m.GetUsers(It.IsAny<UserFilter>()).Result).Returns(users);
            mockUserRepo.Setup(m => m.IsFollowed(user1.Id).Result).Returns(true);
            mockUserRepo.Setup(m => m.IsFollowed(user2.Id).Result).Returns(false);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.UserRepository).Returns(mockUserRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<List<GetUserBriefDTO>>(users)).Returns(userDTOs);

            var us = new UserService(mockUnitOfWork.Object, mockMapper.Object);
            var res = us.GetUsers(new UserFilter()).Result;
            // Assert.That(us.GetUsers(new UserFilter()).Result, Is.EquivalentTo(usersDTOres));
            Assert.That(res.ElementAt(0).Id, Is.EqualTo(usersDTOres[0].Id));
            Assert.That(res.ElementAt(0).Name, Is.EqualTo(usersDTOres[0].Name));
            Assert.That(res.ElementAt(0).Username, Is.EqualTo(usersDTOres[0].Username));
            Assert.That(res.ElementAt(0).ProfileImageUrl, Is.EqualTo(usersDTOres[0].ProfileImageUrl));
            Assert.That(res.ElementAt(0).IsFollowed, Is.EqualTo(usersDTOres[0].IsFollowed));

            Assert.That(res.ElementAt(1).Id, Is.EqualTo(usersDTOres[1].Id));
            Assert.That(res.ElementAt(1).Name, Is.EqualTo(usersDTOres[1].Name));
            Assert.That(res.ElementAt(1).Username, Is.EqualTo(usersDTOres[1].Username));
            Assert.That(res.ElementAt(1).ProfileImageUrl, Is.EqualTo(usersDTOres[1].ProfileImageUrl));
            Assert.That(res.ElementAt(1).IsFollowed, Is.EqualTo(usersDTOres[1].IsFollowed));
        }

        [Test]
        public void GetUserPublicData()
        {
            User user = new User();
            user.Id = "abc"; user.Name = "Pepa"; user.UserName = "pepik123"; user.Email = "pepa@okurka.com"; user.DailyGoalMs = 10000;
            user.Followers = [new User { Id = "def" }, new User { Id = "ghi" }];
            user.Following = [new User { Id = "ghi" }];


            GetUserPublicDTO getUserPublicDTO = new GetUserPublicDTO();
            getUserPublicDTO.Id = "abc"; getUserPublicDTO.Name = "Pepa"; getUserPublicDTO.Username = "pepik123";

            GetUserPublicDTO resultDTO = new GetUserPublicDTO();
            resultDTO.Id = "abc"; resultDTO.Name = "Pepa"; resultDTO.Username = "pepik123"; resultDTO.IsFollowed = true; resultDTO.Following = 1; resultDTO.Followers = 2;

            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(m => m.GetUserWithStatsAndFollowers("abc").Result).Returns(user);
            mockUserRepo.Setup(m => m.IsFollowed("abc").Result).Returns(true);


            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(m => m.UserRepository).Returns(mockUserRepo.Object);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<GetUserPublicDTO>(user)).Returns(getUserPublicDTO);

            var us = new UserService(mockUnitOfWork.Object, mockMapper.Object);

            var res = us.GetUserPublicData("abc").Result;
            //Assert.That(res, Is.EqualTo(resultDTO));
            Assert.That(res.Id, Is.EqualTo(resultDTO.Id));
            Assert.That(res.Name, Is.EqualTo(resultDTO.Name));
            Assert.That(res.Username, Is.EqualTo(resultDTO.Username));
            Assert.That(res.IsFollowed, Is.EqualTo(resultDTO.IsFollowed));
            Assert.That(res.Following, Is.EqualTo(resultDTO.Following));
            Assert.That(res.Followers, Is.EqualTo(resultDTO.Followers));
        }

        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            return mgr;
        }
    }
}