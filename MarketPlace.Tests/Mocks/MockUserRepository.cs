using Market.Domain.Entities;
using Market.Domain.Enums;
using Market.Domain.Interfaces.IRepositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Tests.Mocks
{
    public class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var userRepository = new Mock<IUserRepository>();
            List<ApplicationUser> users = new List<ApplicationUser>()
            {

                new ApplicationUser()
                {
                    Id = 1,
                    UserName = "User One",
                    Email = "userone@yopmail.com",
                    UserId = "3er406ef-aece-41ba-999a-0f86434a3201",
                    CreatedDate = DateTime.Now,
                    Status = Status.Active,
                    StatusDesc = Status.Active.ToString()
                },
                new ApplicationUser()
                {
                    Id = 2,
                    UserName = "User Two",
                    Email = "usertwo@yopmail.com",
                    UserId = "4ce543ea-aece-41ba-999a-0f86432a3201",
                    CreatedDate = DateTime.Now,
                    Status = Status.Active,
                    StatusDesc = Status.Active.ToString()
                }
            };

            var user = new ApplicationUser()
            {
                Id = 1,
                UserName = "User One",
                Email = "userone@yopmail.com",
                UserId = "3er406ef-aece-41ba-999a-0f86434a3201",
                CreatedDate = DateTime.Now,
                Status = Status.Active,
                StatusDesc = Status.Active.ToString()
            };

            var newUser = new ApplicationUser
            {
                Id = 3,
                UserName = "User Three",
                Email = "userthree@yopmail.com",
                UserId = "4ce406ea-aece-41ba-999a-0f86434a3201",
                CreatedDate = DateTime.Now,
                Status = Status.Active,
                StatusDesc = Status.Active.ToString()
            };
            //orders.Add(newOrder);

            //userRepository.Setup(c => c.GetAllAsync().Result).Returns(users);
            userRepository.Setup(c => c.GetByIdAsync(It.IsAny<int>()).Result).Returns((int id) => users.FirstOrDefault(c => c.Id == id));
            userRepository.Setup(c => c.GetUserByEmail(It.IsAny<string>()).Result).Returns((string email) => users.FirstOrDefault(c => c.Email == email));
            userRepository.Setup(c => c.GetUserByUserId(It.IsAny<string>()).Result).Returns((string userid) => users.FirstOrDefault(c => c.UserId == userid));
            userRepository.Setup(c => c.AddAsync(It.IsAny<ApplicationUser>())).Returns((Order order) =>
            {
                users.Add(newUser);
                return users;
            });
            /*orderRepository.Setup(c => c.UpdateAsync(It.IsAny<Order>())).Callback(() => { return; });
            orderRepository.Setup(c => c.DeleteAsync(It.IsAny<Order>())).Callback(() => { return; });*/
            return userRepository;
        }
    }
}
