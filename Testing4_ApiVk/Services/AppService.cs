using System;
using Testing4_ApiVk.Models;
using Testing4_ApiVk.Repositories;

namespace Testing4_ApiVk.Services
{
    public class AppService
    {
        private IAppRepository _appRepository;

        public AppService(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        public string GetPopularAppVk(string id)
        {
            AppVk app = _appRepository.GetAppById(id);
            string popular;
            if (app.members_count < 100000)
                popular = "Непопулярно";
            else if (app.members_count < 1000000)
                popular = "Популярно";
            else popular = "Очень популярно";
            return popular;
            //return CalculateAge(enteredDate);
        }
    }
}