using Newtonsoft.Json;
using Testing4_ApiVk.Models;

namespace Testing4_ApiVk.Repositories
{
    public class UsersRepositoryMock : IUsersRepository
    {
        public string URL { get; set; }

        public User GetUserById(string id)
        {
            User user = new User();
            if (id == "261163818")
            {
                user = new User()
                {
                    id = "261163818",
                    first_name = "Денис",
                    last_name = "Иванов",
                    is_closed = false,
                    birthday = "28.2.1998"
                };
            }
            else if (id == "225915811")
            {
                user = new User()
                {
                    id = "86031446",
                    first_name = "Александр",
                    last_name = "Павличенко",
                    is_closed = false,
                    birthday = "12.9.2000"
                };
            }
            return user;
        }
    }
}