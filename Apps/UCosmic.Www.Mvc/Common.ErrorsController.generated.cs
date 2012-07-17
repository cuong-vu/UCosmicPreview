// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace UCosmic.Www.Mvc.Areas.Common.Controllers {
    public partial class ErrorsController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ErrorsController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult FileUploadTooLarge() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.FileUploadTooLarge);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.JsonResult LogAjaxError() {
            return new T4MVC_JsonResult(Area, Name, ActionNames.LogAjaxError);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ErrorsController Actions { get { return MVC.Common.Errors; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Common";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Errors";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Errors";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string NotFound = "not-found";
            public readonly string FileUploadTooLarge = "file-upload-too-large";
            public readonly string NotAuthorized = "not-authorized";
            public readonly string BadRequest = "bad-request";
            public readonly string Unexpected = "unexpected";
            public readonly string Throw = "throw";
            public readonly string LogAjaxError = "log-ajax-error";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string NotFound = "not-found";
            public const string FileUploadTooLarge = "file-upload-too-large";
            public const string NotAuthorized = "not-authorized";
            public const string BadRequest = "bad-request";
            public const string Unexpected = "unexpected";
            public const string Throw = "throw";
            public const string LogAjaxError = "log-ajax-error";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string bad_request = "~/Areas/Common/Views/Errors/bad-request.cshtml";
            public readonly string file_upload_too_large = "~/Areas/Common/Views/Errors/file-upload-too-large.cshtml";
            public readonly string not_authorized = "~/Areas/Common/Views/Errors/not-authorized.cshtml";
            public readonly string not_found = "~/Areas/Common/Views/Errors/not-found.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_ErrorsController: UCosmic.Www.Mvc.Areas.Common.Controllers.ErrorsController {
        public T4MVC_ErrorsController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult NotFound() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.NotFound);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult FileUploadTooLarge(string path) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.FileUploadTooLarge);
            callInfo.RouteValueDictionary.Add("path", path);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult NotAuthorized(string url) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.NotAuthorized);
            callInfo.RouteValueDictionary.Add("url", url);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult BadRequest() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.BadRequest);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Unexpected() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Unexpected);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Throw() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Throw);
            return callInfo;
        }

        public override System.Web.Mvc.JsonResult LogAjaxError(UCosmic.Www.Mvc.Models.JQueryAjaxException model) {
            var callInfo = new T4MVC_JsonResult(Area, Name, ActionNames.LogAjaxError);
            callInfo.RouteValueDictionary.Add("model", model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
