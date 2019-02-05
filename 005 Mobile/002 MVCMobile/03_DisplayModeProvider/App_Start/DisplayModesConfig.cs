using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace _03_DisplayModeProvider.App_Start
{
    public static class DisplayModesConfig
    {
        public static void RegisterModes()
        {

            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode("iPad")
                {
                    // ContextCondition - условие, которое определяет применимость режима отображения для данного запроса
                    ContextCondition = context => context.Request.UserAgent.Contains("iPad")
                });

            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode("Silk") 
                {
                    ContextCondition = context => context.Request.UserAgent.Contains("Silk")
                });

        }
    }
}