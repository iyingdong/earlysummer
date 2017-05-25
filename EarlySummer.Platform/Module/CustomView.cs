using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.WebPages;

namespace EarlySummer.Platform.Module
{
    internal class CustomView : IView
    {
        public string ViewPath { get; private set; }

        public CustomView(string viewPath)
        {
            this.ViewPath = viewPath;
        }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            try
            {
                Type viewType = BuildManager.GetCompiledType(ViewPath);
                object instance = Activator.CreateInstance(viewType);
                WebViewPage page = (WebViewPage)instance as WebViewPage;

                page.VirtualPath = ViewPath;
                page.ViewContext = viewContext;
                page.ViewData = viewContext.ViewData;

                page.InitHelpers();

                WebPageContext pageContext = new WebPageContext(viewContext.HttpContext, null, null);
                WebPageRenderingBase startPage = StartPage.GetStartPage(page, "_ViewStart", new string[] { "cshtml" });
                page.ExecutePageHierarchy(pageContext, writer, startPage);
            }
            catch (Exception ex)
            {
                viewContext.RequestContext.HttpContext.Response.Write(ex.Message);
            }
        }
    }
}
