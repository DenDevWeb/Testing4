using NUnit.Framework;
using Testing4_ApiVk.Models;
using Testing4_ApiVk.Repositories;

namespace Testing4_ApiVk.Testing
{
    public class TestingApiVk
    {
        [Test]
        public void GetUserFromRepositoryTest()//тестируем репозиторий с помощью мокСервера
        {
            IUsersRepository userRepository = new UsersRepositoryVk();
            userRepository.baseURL = "http://localhost:8080/method/";
            User user = userRepository.GetUserById("261163818");
            Assert.AreEqual("261163818", user.id);
            Assert.AreEqual("Денис", user.first_name);
            Assert.AreEqual("Иванов",user.last_name);
            Assert.AreEqual("28.2.1998",user.birthday);
            Assert.AreEqual(false,user.is_closed);
            
        }
    }
}