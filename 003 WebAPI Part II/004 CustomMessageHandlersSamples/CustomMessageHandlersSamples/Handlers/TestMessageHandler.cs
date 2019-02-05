﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace CustomMessageHandlersSamples.Handlers
{
    // HTTP Message Handlers 
    // http://www.asp.net/web-api/overview/working-with-http/http-message-handlers


    // Данный HTTP обработчик сообщений добавлен в конвеер обработки запроса в фалй WebApiConfig
    public class TestMessageHandler : DelegatingHandler
    {
        protected async override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            Debug.WriteLine("Process request");
            
            // Запуск следующего обработчика в цепочке.
            var response = await base.SendAsync(request, cancellationToken);
            
            Debug.WriteLine("Process response");

            return response;
        }
    }
}