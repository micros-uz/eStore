using eStore.Logic;
using eStore.Web.UI.Areas.Account.Controllers;
using eStore.Web.UI.Areas.Admin.Controllers;
using eStore.Web.UI.Areas.Store.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using WrapIoC;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(eStore.Web.UI.Logic.ControllerFactoryInitializer), "Init")]

namespace eStore.Web.UI.Logic
{
    public class ControllerFactoryInitializer
    {
        public static void Init()
        {
            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
            IoC.Current.Register<IController, HomeController>("home");
            IoC.Current.Register<IController, GenreController>("genre");
            IoC.Current.Register<IController, AuthorController>("author");
            IoC.Current.Register<IController, BookController>("book");
            IoC.Current.Register<IController, SearchController>("search");
            IoC.Current.Register<IController, SqlController>("sql");
            IoC.Current.Register<IController, AccountController>("account");
            IoC.Current.Register<IController, UserController>("user");
            IoC.Current.Register<IController, CartController>("cart");
            IoC.Current.Register<IController, CheckoutController>("сheckout");
            IoC.Current.Register<IController, eStore.Web.UI.Controllers.ErrorController>("error");
            IoC.Current.Register<IController, LogController>("log");
            IoC.Current.Register<IController, BlogController>("blog");
            IoC.Current.Register<IController, ForumController>("forum");

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator), new HttpControllerActivator(IoC.Current));

        }
    }
}