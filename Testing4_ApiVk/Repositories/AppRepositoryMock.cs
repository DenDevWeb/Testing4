using Testing4_ApiVk.Models;


namespace Testing4_ApiVk.Repositories
{
    public class AppRepositoryMock : IAppRepository
    {
        public string URL { get; set; }
        public AppVk GetAppById(string id)
        {
            AppVk app = new AppVk();
            if (id == "4063926")
            {
                app = new AppVk()
                {
                    id = "4063926",
                    genre = "Головоломка",
                    members_count = 1853250
                }; 
            }
            else if (id == "4063927")
            {
                app = new AppVk()
                {
                    id = "4063927",
                    genre = "Стратегия",
                    members_count = 300
                }; 
            }
            else if (id == "4063928")
            {
                app = new AppVk()
                {
                    id = "4063928",
                    genre = "Гонка",
                    members_count = 700000
                }; 
            }
            return app;
        }
    }
}