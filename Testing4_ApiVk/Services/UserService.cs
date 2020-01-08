using System;
using Testing4_ApiVk.Models;
using Testing4_ApiVk.Repositories;

namespace Testing4_ApiVk.Services
{
    public class UserService
    {
        private IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public string CheckLeapYear(string id)
        {
            User yearUser = _usersRepository.GetUserById(id);
            int  year_birthday = DateTime.Parse(yearUser.birthday).Year;
            string isCheckYear = "Ошибка";
            if ((year_birthday % 4 == 0 && year_birthday % 100 != 0) || (year_birthday % 400 == 0))
            {
                isCheckYear = "Високосный";
            }
            else
            {
                isCheckYear = "Невисокосный";
            }
            return isCheckYear;
        }
    }
}