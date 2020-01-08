using Testing4_ApiVk.Models;

namespace Testing4_ApiVk.Repositories
{
    public interface IAppRepository
    {
        AppVk GetAppById(string id);
        string URL { get; set; }
    }
}