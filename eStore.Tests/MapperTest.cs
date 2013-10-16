using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using eStore.Domain.Store;
using eStore.Domain.Security;
using eStore.Web.UI.Areas.Account.ViewModels;
using System.Collections.Generic;

namespace eStore.Tests
{
    [TestClass]
    public class MapperTest
    {
        [TestMethod]
        public void RegisterModelToUserTest()
        {
            var model = new RegisterModel
            {
                Email = "www@mail.ru",
                Password = "111",
                PasswordConfirm = "111",
                RoleId = 2,
                Name = "user",
                Roles = new List<Role>()
            };

            Mapper.CreateMap<RegisterModel, User>();
            var user = Mapper.Map<RegisterModel, User>(model);

        }
    }
}
