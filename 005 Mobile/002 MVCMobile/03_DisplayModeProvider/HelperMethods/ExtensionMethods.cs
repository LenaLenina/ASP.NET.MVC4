using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_DisplayModeProvider.HelperMethods
{
    public static class ExtensionMethods
    {
        public static MvcHtmlString DrawBool(this HtmlHelper html, bool data)
        {
            if (data)
            {
                return new MvcHtmlString(
                    string.Format("<div style='width:16px; height:16px; background-image:url({0})'></div>", "/Content/plus.png"));
            }
            else
            {
                return new MvcHtmlString(
                   string.Format("<div style='width:16px; height:16px; background-image:url({0})'></div>", "/Content/minus.png"));
            }

        }
    }
}