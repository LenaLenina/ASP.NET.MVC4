using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace _04_BrowserOverriding.App_Start
{
    public static class DisplayModesConfig
    {
        public static void RegisterModes()
        {
            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode("iPhone")
                {
                    // обратите внимание: вместо поиска в текущем значении заголовка User-Agent
                    // идет поиск в переопределенном заголовке, который можно получить с помщью GetOverriddenUserAgent()
                    ContextCondition = x => x.GetOverriddenUserAgent().Contains("iPhone")
                });
        }
    }
}