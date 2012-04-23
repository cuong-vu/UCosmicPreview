﻿using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using Should;

namespace UCosmic.Www.Mvc.Areas.People.Controllers
{
    // ReSharper disable UnusedMember.Global
    public class PersonInfoRouterFacts
    // ReSharper restore UnusedMember.Global
    {
        [TestClass]
        public class TheByEmailRoute
        {
            [TestMethod]
            public void Inbound_WithPost_MapsToPostAction()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.ByEmail(null);
                var url = PersonInfoRouter.ByEmail.Route.ToAppRelativeUrl();

                url.WithMethod(HttpVerbs.Post).ShouldMapTo(action);
            }

            [TestMethod]
            public void Inbound_WithNonPost_MapsToNothing()
            {
                var url = PersonInfoRouter.ByEmail.Route.ToAppRelativeUrl();

                url.WithMethodsExcept(HttpVerbs.Post).ShouldMapToNothing();
            }

            [TestMethod]
            public void Outbound_ForPostAction_MapsToUrl()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.ByEmail(null);
                var url = PersonInfoRouter.ByEmail.Route.ToAppRelativeUrl();

                OutBoundRoute.Of(action).InArea(MVC.People.Name).WithMethod(HttpVerbs.Post)
                    .AppRelativeUrl().ShouldEqual(url);
            }

            [TestMethod]
            public void Defaults_WithPostAction_MapToNothing()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.ByEmail(null);

                action.DefaultAreaRoutes(MVC.People.Name).ShouldMapToNothing();
            }

        }

        [TestClass]
        public class TheByGuidRoute
        {
            [TestMethod]
            public void Inbound_WithPost_MapsToPostAction()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.ByGuid();
                var url = PersonInfoRouter.ByGuid.Route.ToAppRelativeUrl();

                url.WithMethod(HttpVerbs.Post).ShouldMapTo(action);
            }

            [TestMethod]
            public void Inbound_WithNonPost_MapsToNothing()
            {
                var url = PersonInfoRouter.ByGuid.Route.ToAppRelativeUrl();

                url.WithMethodsExcept(HttpVerbs.Post).ShouldMapToNothing();
            }

            [TestMethod]
            public void Outbound_ForPostAction_MapsToUrl()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.ByGuid();
                var url = PersonInfoRouter.ByGuid.Route.ToAppRelativeUrl();

                OutBoundRoute.Of(action).InArea(MVC.People.Name).WithMethod(HttpVerbs.Post)
                    .AppRelativeUrl().ShouldEqual(url);
            }

            [TestMethod]
            public void Defaults_WithPostAction_MapToNothing()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.ByGuid();

                action.DefaultAreaRoutes(MVC.People.Name).ShouldMapToNothing();
            }

        }

        [TestClass]
        public class TheWithEmailRoute
        {
            [TestMethod]
            public void Inbound_WithPost_MapsToPostAction()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.WithEmail();
                var url = PersonInfoRouter.WithEmail.Route.ToAppRelativeUrl();

                url.WithMethod(HttpVerbs.Post).ShouldMapTo(action);
            }

            [TestMethod]
            public void Inbound_WithNonPost_MapsToNothing()
            {
                var url = PersonInfoRouter.WithEmail.Route.ToAppRelativeUrl();

                url.WithMethodsExcept(HttpVerbs.Post).ShouldMapToNothing();
            }

            [TestMethod]
            public void Outbound_ForPostAction_MapsToUrl()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.WithEmail();
                var url = PersonInfoRouter.WithEmail.Route.ToAppRelativeUrl();

                OutBoundRoute.Of(action).InArea(MVC.People.Name).WithMethod(HttpVerbs.Post)
                    .AppRelativeUrl().ShouldEqual(url);
            }

            [TestMethod]
            public void Defaults_WithPostAction_MapToNothing()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.WithEmail();

                action.DefaultAreaRoutes(MVC.People.Name).ShouldMapToNothing();
            }

        }

        [TestClass]
        public class TheWithFirstNameRoute
        {
            [TestMethod]
            public void Inbound_WithPost_MapsToPostAction()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.WithFirstName();
                var url = PersonInfoRouter.WithFirstName.Route.ToAppRelativeUrl();

                url.WithMethod(HttpVerbs.Post).ShouldMapTo(action);
            }

            [TestMethod]
            public void Inbound_WithNonPost_MapsToNothing()
            {
                var url = PersonInfoRouter.WithFirstName.Route.ToAppRelativeUrl();

                url.WithMethodsExcept(HttpVerbs.Post).ShouldMapToNothing();
            }

            [TestMethod]
            public void Outbound_ForPostAction_MapsToUrl()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.WithFirstName();
                var url = PersonInfoRouter.WithFirstName.Route.ToAppRelativeUrl();

                OutBoundRoute.Of(action).InArea(MVC.People.Name).WithMethod(HttpVerbs.Post)
                    .AppRelativeUrl().ShouldEqual(url);
            }

            [TestMethod]
            public void Defaults_WithPostAction_MapToNothing()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.WithFirstName();

                action.DefaultAreaRoutes(MVC.People.Name).ShouldMapToNothing();
            }

        }

        [TestClass]
        public class TheWithLastNameRoute
        {
            [TestMethod]
            public void Inbound_WithPost_MapsToPostAction()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.WithLastName();
                var url = PersonInfoRouter.WithLastName.Route.ToAppRelativeUrl();

                url.WithMethod(HttpVerbs.Post).ShouldMapTo(action);
            }

            [TestMethod]
            public void Inbound_WithNonPost_MapsToNothing()
            {
                var url = PersonInfoRouter.WithLastName.Route.ToAppRelativeUrl();

                url.WithMethodsExcept(HttpVerbs.Post).ShouldMapToNothing();
            }

            [TestMethod]
            public void Outbound_ForPostAction_MapsToUrl()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.WithLastName();
                var url = PersonInfoRouter.WithLastName.Route.ToAppRelativeUrl();

                OutBoundRoute.Of(action).InArea(MVC.People.Name).WithMethod(HttpVerbs.Post)
                    .AppRelativeUrl().ShouldEqual(url);
            }

            [TestMethod]
            public void Defaults_WithPostAction_MapToNothing()
            {
                Expression<Func<PersonInfoController, ActionResult>> action =
                    controller => controller.WithLastName();

                action.DefaultAreaRoutes(MVC.People.Name).ShouldMapToNothing();
            }

        }
    }
}