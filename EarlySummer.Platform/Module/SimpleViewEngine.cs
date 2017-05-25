using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EarlySummer.Platform.Module
{
    /// <summary>
    /// 简单视图解析
    /// </summary>
    public class SimpleViewEngine:RazorViewEngine
    {
        public SimpleViewEngine()
        {
            ViewLocationFormats = new string[] {
                "~/Views/BusinessModules/{1}Modules/{1}/{0}.cshtml",
                "~/Views/BasicModules/{1}Modules/{1}/{0}.cshtml"
            };
        }
    }
}
