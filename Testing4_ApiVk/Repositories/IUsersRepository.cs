﻿using Testing4_ApiVk.Models;

namespace Testing4_ApiVk.Repositories
{
    public interface IUsersRepository
    {
        User GetUserById(string id);
        string URL { get; set; }
    }
}