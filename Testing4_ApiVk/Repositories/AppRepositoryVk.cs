using Testing4_ApiVk.WebClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Testing4_ApiVk.Models;

namespace Testing4_ApiVk.Repositories
{
    public class AppRepositoryVk : IAppRepository
    {
        private string accessToken =
            "0de83f380e4f2e5bbef1ebb445c30f6dc0f55f0a407e2d8a32b2c76bca34263ac012c11f867144adf0f40";
        public string URL { get; set; }
        
        public AppVk GetAppById(string id)
        {
            string request = $"{URL}apps.get?app_id={id}&access_token={accessToken}&v=5.103";
            WebClient.WebClient webHelper = new WebClient.WebClient();
            string json = webHelper.SendRequest(request, "GET");
            return Parse(json);
        }

        private AppVk Parse(string json)
        {
            JObject userJObject = JObject.Parse(json);
            JToken appInfo = userJObject["response"];
            AppVk app = new AppVk();
            app.id = appInfo["items"][0]["id"].ToString();
            app.genre = appInfo["items"][0]["genre"].ToString();
            app.members_count = (int)appInfo["items"][0]["members_count"];
            return app;
        }
    }
}