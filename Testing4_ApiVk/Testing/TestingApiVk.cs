﻿using NUnit.Framework;
using Testing4_ApiVk.Models;
using Testing4_ApiVk.Services;
using Testing4_ApiVk.Repositories;

namespace Testing4_ApiVk.Testing
{
    public class TestingApiVk
    {
        [Test]
        public void GetUserFromRepositoryTest()//тес юзер репозитория с помощью мок сервера
        {
            IUsersRepository userRepository = new UsersRepositoryVk();
            userRepository.URL = "http://localhost:8080/method/";
            User user = userRepository.GetUserById("261163818");
            Assert.AreEqual("261163818", user.id);
            Assert.AreEqual("Денис", user.first_name);
            Assert.AreEqual("Иванов",user.last_name);
            Assert.AreEqual("28.2.1998",user.birthday);
            Assert.AreEqual(false,user.is_closed);
            
        }
        
        [Test]
        public void GetAppFromRepositoryTest() //тест app репозитория с помощью мок сервера
        {
            IAppRepository appRepository = new AppRepositoryVk();
            appRepository.URL = "http://localhost:8080/method/";
            AppVk app = appRepository.GetAppById("4063926");
            Assert.AreEqual("4063926", app.id);
            Assert.AreEqual("Головоломка", app.genre);
            Assert.AreEqual(1853250, app.members_count);
        }
        
        [Test]
        public void GetLeapYearFromServiceTest() //тест user сервиса с помощью мок репозитория
        {
            IUsersRepository userRepository = new UsersRepositoryMock();
            UserService userService = new UserService(userRepository);
            string leapYear = userService.CheckLeapYear("261163818");
            Assert.AreEqual("Невисокосный", leapYear);
            
            leapYear = userService.CheckLeapYear("225915811");
            Assert.AreEqual("Високосный", leapYear);
        }
        
        [Test]
        public void GetPopularAppFromServiceTest()//тест app сервиса с помощью мок репозитория
        {
            IAppRepository appRepository = new AppRepositoryMock();
            AppService appService = new AppService(appRepository);
            
            string popular = appService.GetPopularAppVk("4063926");
            Assert.AreEqual("Очень популярно", popular);
            
            popular = appService.GetPopularAppVk("4063927");
            Assert.AreEqual("Непопулярно", popular);
            
            popular = appService.GetPopularAppVk("4063928");
            Assert.AreEqual("Популярно", popular);
        }
        
        [Test]
        public void GetUserAndDefineLeapYearById()
        {
            IUsersRepository userRepository = new UsersRepositoryVk();
            userRepository.URL = "https://api.vk.com/method/";
            UserService userService = new UserService(userRepository);
            string leapYear = userService.CheckLeapYear("86031446");
            Assert.AreEqual("Невисокосный", leapYear);
            
            leapYear = userService.CheckLeapYear("225915811");
            Assert.AreEqual("Високосный", leapYear);
        }
        
        [Test]
        public void GetAppByAndPopularAppId()
        {
            IAppRepository appRepository = new AppRepositoryVk();
            appRepository.URL = "https://api.vk.com/method/";
            AppService appService = new AppService(appRepository);
            string popular = appService.GetPopularAppVk("4063926");
            Assert.AreEqual("Очень популярно", popular);
            
            popular = appService.GetPopularAppVk("5297630");
            Assert.AreEqual("Непопулярно", popular);
            
            popular = appService.GetPopularAppVk("4207803");
            Assert.AreEqual("Популярно", popular);
        }
    }
}