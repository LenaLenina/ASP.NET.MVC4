using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ValidationMessageHandler.Handlers
{
    public class ValidationMessageHandler : DelegatingHandler
    {
        protected async override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (true) // проверка данных полученых в запросе (параметр request)
            {
                HttpResponseMessage message = new HttpResponseMessage();
                message.Content = new StringContent("Response From ValidationMessageHandler");

                //// Создание Task без указания делегата.
                //var taskSource = new TaskCompletionSource<HttpResponseMessage>();
                //taskSource.SetResult(message);
                return message;
            }
            else
            {
                return await base.SendAsync(request, cancellationToken);
            }

        }
    }
}