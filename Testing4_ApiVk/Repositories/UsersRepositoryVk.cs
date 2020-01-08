using Testing4_ApiVk.WebClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Testing4_ApiVk.Models;

namespace Testing4_ApiVk.Repositories
{
    public class UsersRepositoryVk : IUsersRepository
    {
        private string accessToken = "0de83f380e4f2e5bbef1ebb445c30f6dc0f55f0a407e2d8a32b2c76bca34263ac012c11f867144adf0f40";

        public string URL { get; set; }
        
        public User GetUserById(string id)
        {
            string request = $"{URL}users.get?user_ids={id}&fields=bdate&access_token={accessToken}&v=5.103";
            WebClient.WebClient webHelper = new WebClient.WebClient();
            string json = webHelper.SendRequest(request, "GET");
            return Parse(json);
        }

        private User Parse(string json)
        {
            JObject userJObject = JObject.Parse(json);
            User result;
            JToken userInfo = userJObject["response"][0];
            User user = new User();
            user.id = userInfo["id"].ToString();
            user.first_name = userInfo["first_name"].ToString();
            user.last_name = userInfo["last_name"].ToString();
            user.is_closed = (bool)userInfo["is_closed"];
            user.birthday = userInfo["bdate"].ToString();
            result = user;
            return result;
        }
    }
}