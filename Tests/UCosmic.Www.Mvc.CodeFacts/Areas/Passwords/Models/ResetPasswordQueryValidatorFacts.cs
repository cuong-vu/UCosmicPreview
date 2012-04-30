﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Should;
using UCosmic.Domain.Email;
using UCosmic.Domain.People;
using UCosmic.Impl;

namespace UCosmic.Www.Mvc.Areas.Passwords.Models
{
    // ReSharper disable UnusedMember.Global
    public class ResetPasswordQueryValidatorFacts
    // ReSharper restore UnusedMember.Global
    {
        [TestClass]
        public class TheClass
        {
            [TestMethod]
            public void Validates_ResetPasswordQuery()
            {
                var request = new HttpRequest(null, "http://www.site.com", null);
                HttpContext.Current = new HttpContext(request, new HttpResponse(null));
                var container = SimpleDependencyInjector.Bootstrap();

                var validator = container.GetInstance<IValidator<ResetPasswordQuery>>();

                validator.ShouldNotBeNull();
                validator.ShouldBeType<ResetPasswordQueryValidator>();
            }
        }

        [TestClass]
        public class TheTokenProperty
        {
            private const string PropertyName = "Token";

            [TestMethod]
            public void IsInvalidWhen_IsEmpty()
            {
                var validated = new ResetPasswordQuery
                {
                    Token = Guid.Empty,
                };
                var validator = new ResetPasswordQueryValidator(null);

                var results = validator.Validate(validated);

                results.IsValid.ShouldBeFalse();
                results.Errors.Count.ShouldBeInRange(1, int.MaxValue);
                var error = results.Errors.SingleOrDefault(e => e.PropertyName == PropertyName);
                error.ShouldNotBeNull();
                // ReSharper disable PossibleNullReferenceException
                error.ErrorMessage.ShouldEqual(String.Format(
                    ValidateEmailConfirmation.FailedBecauseTokenWasEmpty,
                        validated.Token));
                // ReSharper restore PossibleNullReferenceException
            }

            [TestMethod]
            public void IsInvalidWhen_MatchesNoEntity()
            {
                var validated = new ResetPasswordQuery
                {
                    Token = Guid.NewGuid(),
                };
                var queryProcesor = new Mock<IProcessQueries>(MockBehavior.Strict);
                queryProcesor.Setup(m => m
                    .Execute(It.Is(ConfirmationQueryBasedOn(validated))))
                    .Returns(null as EmailConfirmation);
                var validator = new ResetPasswordQueryValidator(queryProcesor.Object);

                var results = validator.Validate(validated);

                results.IsValid.ShouldBeFalse();
                results.Errors.Count.ShouldBeInRange(1, int.MaxValue);
                var error = results.Errors.SingleOrDefault(e => e.PropertyName == PropertyName);
                error.ShouldNotBeNull();
                // ReSharper disable PossibleNullReferenceException
                error.ErrorMessage.ShouldEqual(String.Format(
                    ValidateEmailConfirmation.FailedBecauseTokenMatchedNoEntity,
                        validated.Token));
                // ReSharper restore PossibleNullReferenceException
            }

            [TestMethod]
            public void IsValidWhen_MatchesEntity()
            {
                var validated = new ResetPasswordQuery
                {
                    Token = Guid.NewGuid(),
                };
                var queryProcesor = new Mock<IProcessQueries>(MockBehavior.Strict);
                queryProcesor.Setup(m => m
                    .Execute(It.Is(ConfirmationQueryBasedOn(validated))))
                    .Returns(new EmailConfirmation());
                var validator = new ResetPasswordQueryValidator(queryProcesor.Object);

                var results = validator.Validate(validated);

                var error = results.Errors.SingleOrDefault(e => e.PropertyName == PropertyName);
                error.ShouldBeNull();
            }
        }

        private static Expression<Func<GetEmailConfirmationQuery, bool>> ConfirmationQueryBasedOn(ResetPasswordQuery validated)
        {
            return q => q.Token == validated.Token;
        }
    }
}