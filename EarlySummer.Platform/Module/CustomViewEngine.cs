using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EarlySummer.Platform.Module
{
    /// <summary>
    /// 自定义视图解析
    /// </summary>
    public class CustomViewEngine : IViewEngine
    {
        private List<string> viewLocationList = new List<string> {
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml"
        };
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return FindView(controllerContext, partialViewName, null, useCache);
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var viewLocations = new List<string>();
            //如果不是默认模块，则添加寻找视图的规则
            var controllerStr = controllerContext.Controller.ToString();
            if (controllerStr.Contains("."))
            {
                var controllerArr = controllerStr.Split('.');
                if (controllerArr.Length == 5)
                {
                    var viewLocation = string.Format("~/Views/{0}/{1}/{2}/{3}.cshtml", controllerArr[1], controllerArr[2], controllerArr[4], viewName);
                    var path = controllerContext.HttpContext.Request.MapPath(viewLocation);

                    return new ViewEngineResult(new CustomView(viewLocation), this);
                }
            }
            else
            {
                var controllerName = controllerContext.RouteData.GetRequiredString("controller");
                viewLocationList.ForEach(format => viewLocations.Add(string.Format(format, viewName, controllerName)));
            }
            return new ViewEngineResult(viewLocations);

        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
            IDisposable disposable = view as IDisposable;
            if (null != disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
