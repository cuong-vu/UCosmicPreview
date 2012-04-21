﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using FluentValidation.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Should;
using UCosmic.Domain;
using UCosmic.Domain.People;
using UCosmic.Www.Mvc.Areas.My.Models;
using UCosmic.Www.Mvc.Controllers;

namespace UCosmic.Www.Mvc.Areas.My.Controllers
{
    // ReSharper disable UnusedMember.Global
    public class ChangeEmailSpellingControllerFacts
    // ReSharper restore UnusedMember.Global
    {
        [TestClass]
        public class TheClass
        {
            [TestMethod]
            public void IsDecoratedWith_Authorize()
            {
                var attribute = Attribute.GetCustomAttribute(typeof(ChangeEmailSpellingController), typeof(AuthorizeAttribute));

                attribute.ShouldNotBeNull();
                attribute.ShouldBeType<AuthorizeAttribute>();
            }
        }

        [TestClass]
        public class TheGetMethod
        {
            [TestMethod]
            public void IsDecoratedWith_HttpGet()
            {
                Expression<Func<ChangeEmailSpellingController, ActionResult>> method = m => m.Get(1);

                var attributes = method.GetAttributes<ChangeEmailSpellingController, ActionResult, HttpGetAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
            }

            [TestMethod]
            public void IsDecoratedWith_OpenTopTab_UsingHome()
            {
                Expression<Func<ChangeEmailSpellingController, ActionResult>> method = m => m.Get(1);

                var attributes = method.GetAttributes<ChangeEmailSpellingController, ActionResult, OpenTopTabAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
                attributes[0].TabName.ShouldEqual(TopTabName.Home);
            }

            [TestMethod]
            public void IsDecoratedWith_ActionName_UsingChangeSpelling()
            {
                Expression<Func<ChangeEmailSpellingController, ActionResult>> method = m => m.Get(1);

                var attributes = method.GetAttributes<ChangeEmailSpellingController, ActionResult, ActionNameAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
                attributes[0].Name.ShouldEqual("change-email-spelling");
            }

            [TestMethod]
            public void IsDecoratedWith_ReturnUrlReferrer_UsingMyProfile()
            {
                Expression<Func<ChangeEmailSpellingController, ActionResult>> method = m => m.Get(1);

                var attributes = method.GetAttributes<ChangeEmailSpellingController, ActionResult, ReturnUrlReferrerAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
                attributes[0].Fallback.ShouldEqual(ProfileRouter.Get.Route);
            }

            [TestMethod]
            public void ExecutesQuery_ForEmailAddress_ByUserNameAndNumber()
            {
                const int number = 2;
                const string userName = "user@domain.tld";
                var scenarioOptions = new ScenarioOptions
                {
                    PrincipalIdentityName = userName,
                };
                Expression<Func<GetMyEmailAddressByNumberQuery, bool>> emailAddressByUserNameAndNumberQuery =
                    q => q.Principal.Identity.Name == userName && q.Number == number;
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(It.Is(emailAddressByUserNameAndNumberQuery)))
                    .Returns(new EmailAddress());

                controller.Get(number);

                scenarioOptions.MockQueryProcessor.Verify(m => m.Execute(
                    It.Is(emailAddressByUserNameAndNumberQuery)),
                        Times.Once());
            }

            [TestMethod]
            public void Returns404_WhenEmailAddress_CannotBeFound()
            {
                const int number = 2;
                const string userName = "user@domain.tld";
                var scenarioOptions = new ScenarioOptions
                {
                    PrincipalIdentityName = userName,
                };
                Expression<Func<GetMyEmailAddressByNumberQuery, bool>> emailAddressByUserNameAndNumberQuery =
                    q => q.Principal.Identity.Name == userName && q.Number == number;
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(It.Is(emailAddressByUserNameAndNumberQuery)))
                    .Returns(null as EmailAddress);

                var result = controller.Get(number);

                result.ShouldNotBeNull();
                result.ShouldBeType<HttpNotFoundResult>();
            }

            [TestMethod]
            public void ReturnsPartialView_WhenEmailAddress_IsFound()
            {
                const int number = 2;
                const string userName = "user@domain.tld";
                var scenarioOptions = new ScenarioOptions
                {
                    PrincipalIdentityName = userName,
                };
                Expression<Func<GetMyEmailAddressByNumberQuery, bool>> emailAddressByUserNameAndNumberQuery =
                    q => q.Principal.Identity.Name == userName && q.Number == number;
                var controller = CreateController(scenarioOptions);
                scenarioOptions.MockQueryProcessor.Setup(m => m.Execute(It.Is(emailAddressByUserNameAndNumberQuery)))
                    .Returns(new EmailAddress());

                var result = controller.Get(number);

                result.ShouldNotBeNull();
                result.ShouldBeType<PartialViewResult>();
                var partialViewResult = (PartialViewResult)result;
                partialViewResult.Model.ShouldNotBeNull();
                partialViewResult.Model.ShouldBeType<ChangeEmailSpellingForm>();
            }
        }

        [TestClass]
        public class ThePutMethod
        {
            [TestMethod]
            public void IsDecoratedWith_HttpPut()
            {
                Expression<Func<ChangeEmailSpellingController, ActionResult>> method = m => m.Put(null);

                var attributes = method.GetAttributes<ChangeEmailSpellingController, ActionResult, HttpPutAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
            }

            [TestMethod]
            public void IsDecoratedWith_UnitOfWork()
            {
                Expression<Func<ChangeEmailSpellingController, ActionResult>> method = m => m.Put(null);

                var attributes = method.GetAttributes<ChangeEmailSpellingController, ActionResult, UnitOfWorkAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
            }

            [TestMethod]
            public void IsDecoratedWith_OpenTopTab_UsingHome()
            {
                Expression<Func<ChangeEmailSpellingController, ActionResult>> method = m => m.Put(null);

                var attributes = method.GetAttributes<ChangeEmailSpellingController, ActionResult, OpenTopTabAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
                attributes[0].TabName.ShouldEqual(TopTabName.Home);
            }

            [TestMethod]
            public void IsDecoratedWith_ActionName_UsingChangeSpelling()
            {
                Expression<Func<ChangeEmailSpellingController, ActionResult>> method = m => m.Put(null);

                var attributes = method.GetAttributes<ChangeEmailSpellingController, ActionResult, ActionNameAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
                attributes[0].Name.ShouldEqual("change-email-spelling");
            }

            [TestMethod]
            public void Returns404_WhenModel_IsNull()
            {
                var controller = CreateController();

                var result = controller.Put(null);

                result.ShouldNotBeNull();
                result.ShouldBeType<HttpNotFoundResult>();
            }

            [TestMethod]
            public void Returns404_WhenPersonUserName_IsNotEqualTo_UserIdentityName()
            {
                const string userIdentityName = "user@domain.tld";
                const string personUserName = "user@domain2.tld";
                var scenarioOptions = new ScenarioOptions
                {
                    PrincipalIdentityName = userIdentityName,
                };
                var model = new ChangeEmailSpellingForm
                {
                    PersonUserName = personUserName,
                };
                var controller = CreateController(scenarioOptions);

                var result = controller.Put(model);

                result.ShouldNotBeNull();
                result.ShouldBeType<HttpNotFoundResult>();
            }

            [TestMethod]
            public void ReturnsPartialView_WhenModelState_IsInvalid()
            {
                const string userIdentityName = "user@domain.tld";
                const string personUserName = "user@domain.tld";
                var scenarioOptions = new ScenarioOptions
                {
                    PrincipalIdentityName = userIdentityName,
                };
                var model = new ChangeEmailSpellingForm
                {
                    PersonUserName = personUserName,
                };
                var controller = CreateController(scenarioOptions);
                controller.ModelState.AddModelError("error", "message");

                var result = controller.Put(model);

                result.ShouldNotBeNull();
                result.ShouldBeType<PartialViewResult>();
                var partialViewResult = (PartialViewResult)result;
                partialViewResult.Model.ShouldNotBeNull();
                partialViewResult.Model.ShouldBeType<ChangeEmailSpellingForm>();
                partialViewResult.Model.ShouldEqual(model);
            }

            [TestMethod]
            public void ExecutesCommand_WhenAction_IsValid()
            {
                const int number = 2;
                const string personUserName = "user@domain.tld";
                const string newValue = "User@domain.tld";
                const string principalIdentityName = "user@domain.tld";
                var scenarioOptions = new ScenarioOptions
                {
                    PrincipalIdentityName = principalIdentityName,
                };
                var model = new ChangeEmailSpellingForm
                {
                    Number = number,
                    PersonUserName = personUserName,
                    Value = newValue,
                    ReturnUrl = "https://www.site.com/"
                };
                var controller = CreateController(scenarioOptions);
                var builder = ReuseMock.TestControllerBuilder();
                var principal = principalIdentityName.AsPrincipal();
                builder.HttpContext.User = principal;
                builder.InitializeController(controller);
                Expression<Func<ChangeMyEmailSpellingCommand, bool>> commandDerivedFromModel =
                    command =>
                    command.Number == number &&
                    command.Principal == principal &&
                    command.NewValue == newValue
                ;
                scenarioOptions.MockCommandHandler.Setup(m => m.Handle(It.Is(commandDerivedFromModel)));

                controller.Put(model);

                scenarioOptions.MockCommandHandler.Verify(m =>
                    m.Handle(It.Is(commandDerivedFromModel)),
                        Times.Once());
            }

            [TestMethod]
            public void FlashesSuccessMessage_WhenCommand_ChangedState()
            {
                const int number = 2;
                const string personUserName = "user@domain.tld";
                const string newValue = "User@domain.tld";
                const string principalIdentityName = "user@domain.tld";
                var scenarioOptions = new ScenarioOptions
                {
                    PrincipalIdentityName = principalIdentityName,
                };
                var model = new ChangeEmailSpellingForm
                {
                    Number = number,
                    PersonUserName = personUserName,
                    Value = newValue,
                    ReturnUrl = "https://www.site.com/"
                };
                var controller = CreateController(scenarioOptions);
                var builder = ReuseMock.TestControllerBuilder();
                var principal = principalIdentityName.AsPrincipal();
                builder.HttpContext.User = principal;
                builder.InitializeController(controller);
                Expression<Func<ChangeMyEmailSpellingCommand, bool>> commandDerivedFromModel =
                    command =>
                    command.Number == number &&
                    command.Principal == principal &&
                    command.NewValue == newValue
                ;
                scenarioOptions.MockCommandHandler.Setup(m => m.Handle(It.Is(commandDerivedFromModel)))
                    .Callback((ChangeMyEmailSpellingCommand command) => command.ChangedState = true);

                controller.Put(model);

                controller.TempData.ShouldNotBeNull();
                var message = controller.TempData.FeedbackMessage();
                message.ShouldNotBeNull();
                message.ShouldEqual(string.Format(ChangeEmailSpellingController.SuccessMessageFormat, model.Value));
            }

            [TestMethod]
            public void FlashesNoChangesMessage_WhenCommand_ChangedState()
            {
                const int number = 2;
                const string personUserName = "user@domain.tld";
                const string newValue = "User@domain.tld";
                const string principalIdentityName = "user@domain.tld";
                var scenarioOptions = new ScenarioOptions
                {
                    PrincipalIdentityName = principalIdentityName,
                };
                var model = new ChangeEmailSpellingForm
                {
                    Number = number,
                    PersonUserName = personUserName,
                    Value = newValue,
                    ReturnUrl = "https://www.site.com/"
                };
                var controller = CreateController(scenarioOptions);
                var builder = ReuseMock.TestControllerBuilder();
                var principal = principalIdentityName.AsPrincipal();
                builder.HttpContext.User = principal;
                builder.InitializeController(controller);
                Expression<Func<ChangeMyEmailSpellingCommand, bool>> commandDerivedFromModel =
                    command =>
                    command.Number == number &&
                    command.Principal == principal &&
                    command.NewValue == newValue
                ;
                scenarioOptions.MockCommandHandler.Setup(m => m.Handle(It.Is(commandDerivedFromModel)));

                controller.Put(model);

                controller.TempData.ShouldNotBeNull();
                var message = controller.TempData.FeedbackMessage();
                message.ShouldNotBeNull();
                message.ShouldEqual(ChangeEmailSpellingController.NoChangesMessage);
            }

            [TestMethod]
            public void ReturnsRedirect_ToModelReturnUrl_AfterCommandIsExecuted()
            {
                const int number = 2;
                const string personUserName = "user@domain.tld";
                const string newValue = "User@domain.tld";
                const string principalIdentityName = "user@domain.tld";
                var scenarioOptions = new ScenarioOptions
                {
                    PrincipalIdentityName = principalIdentityName,
                };
                var model = new ChangeEmailSpellingForm
                {
                    Number = number,
                    PersonUserName = personUserName,
                    Value = newValue,
                    ReturnUrl = "https://www.site.com/"
                };
                var controller = CreateController(scenarioOptions);
                var builder = ReuseMock.TestControllerBuilder();
                var principal = principalIdentityName.AsPrincipal();
                builder.HttpContext.User = principal;
                builder.InitializeController(controller);
                Expression<Func<ChangeMyEmailSpellingCommand, bool>> commandDerivedFromModel =
                    command =>
                    command.Number == number &&
                    command.Principal == principal &&
                    command.NewValue == newValue
                ;
                scenarioOptions.MockCommandHandler.Setup(m => m.Handle(It.Is(commandDerivedFromModel)));

                var result = controller.Put(model);

                result.ShouldNotBeNull();
                result.ShouldBeType<RedirectResult>();
                var redirectResult = (RedirectResult) result;
                redirectResult.Url.ShouldEqual(model.ReturnUrl);
                redirectResult.Permanent.ShouldBeFalse();
            }
        }

        [TestClass]
        public class TheValidateValueMethod
        {
            [TestMethod]
            public void IsDecoratedWith_HttpPost()
            {
                Expression<Func<ChangeEmailSpellingController, ActionResult>> method = m => m.ValidateValue(null);

                var attributes = method.GetAttributes<ChangeEmailSpellingController, ActionResult, HttpPostAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
            }

            [TestMethod]
            public void IsDecoratedWith_OutputCache()
            {
                Expression<Func<ChangeEmailSpellingController, ActionResult>> method = m => m.ValidateValue(null);

                var attributes = method.GetAttributes<ChangeEmailSpellingController, ActionResult, OutputCacheAttribute>();
                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
            }

            [TestMethod]
            public void ViewModelArgument_IsDecoratedWith_CustomizeValidator_ForValueProperty()
            {
                Expression<Func<ChangeEmailSpellingController, JsonResult>> methodExpression = m => m.ValidateValue(null);
                var methodCallExpression = (MethodCallExpression)methodExpression.Body;
                var methodInfo = methodCallExpression.Method;
                var methodArg = methodInfo.GetParameters().Single();
                var attributes = methodArg.GetCustomAttributes(typeof(CustomizeValidatorAttribute), false);

                attributes.ShouldNotBeNull();
                attributes.Length.ShouldEqual(1);
                attributes[0].ShouldNotBeNull();
                attributes[0].ShouldBeType<CustomizeValidatorAttribute>();
                var customizeValidator = (CustomizeValidatorAttribute) attributes[0];
                customizeValidator.Properties.ShouldEqual(ChangeEmailSpellingForm.ValuePropertyName);
            }

            [TestMethod]
            public void ReturnsTrue_WhenModelStateIsValid()
            {
                var model = new ChangeEmailSpellingForm();
                var controller = CreateController();

                var result = controller.ValidateValue(model);

                result.ShouldNotBeNull();
                result.ShouldBeType<JsonResult>();
                result.JsonRequestBehavior.ShouldEqual(JsonRequestBehavior.DenyGet);
                result.Data.ShouldEqual(true);
            }

            [TestMethod]
            public void ReturnsErrorMessage_WhenModelStateIsInvalid_ForValueProperty()
            {
                const string errorMessage = "Here is your error message.";
                var model = new ChangeEmailSpellingForm();
                var controller = CreateController();
                controller.ModelState.AddModelError(ChangeEmailSpellingForm.ValuePropertyName, errorMessage);

                var result = controller.ValidateValue(model);

                result.ShouldNotBeNull();
                result.ShouldBeType<JsonResult>();
                result.JsonRequestBehavior.ShouldEqual(JsonRequestBehavior.DenyGet);
                result.Data.ShouldEqual(errorMessage);
            }
        }

        private class ScenarioOptions
        {
            internal Mock<IProcessQueries> MockQueryProcessor { get; set; }
            internal Mock<IHandleCommands<ChangeMyEmailSpellingCommand>> MockCommandHandler { get; set; }
            internal string PrincipalIdentityName { get; set; }
        }

        private static ChangeEmailSpellingController CreateController(ScenarioOptions scenarioOptions = null)
        {
            scenarioOptions = scenarioOptions ?? new ScenarioOptions();

            scenarioOptions.MockQueryProcessor = new Mock<IProcessQueries>(MockBehavior.Strict);

            scenarioOptions.MockCommandHandler = new Mock<IHandleCommands<ChangeMyEmailSpellingCommand>>(MockBehavior.Strict);

            var services = new ChangeEmailSpellingServices(scenarioOptions.MockQueryProcessor.Object, scenarioOptions.MockCommandHandler.Object);

            var controller = new ChangeEmailSpellingController(services);

            var builder = ReuseMock.TestControllerBuilder();

            builder.HttpContext.User = null;
            if (!string.IsNullOrWhiteSpace(scenarioOptions.PrincipalIdentityName))
            {
                var principal = scenarioOptions.PrincipalIdentityName.AsPrincipal();
                builder.HttpContext.User = principal;
            }

            builder.InitializeController(controller);

            return controller;
        }
    }
}