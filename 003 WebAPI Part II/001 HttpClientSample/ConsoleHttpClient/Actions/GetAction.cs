using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleHttpClient
{
    class GetAction : Action
    {
        public override void Invoke()
        {
            // http://msdn.microsoft.com/ru-ru/library/system.net.http.httpclient.aspx
            // Класс для отправки HTTP запросов и получения HTTP ответов от ресурса с заданым URI
            HttpClient client = new HttpClient();
            
            // Большая часть методов HttpClient возвращают объект типа Task.
            // Так как данное приложения консольное - мы блокируем поток до получения ответа от сервера.
            HttpResponseMessage response = client.GetAsync(Program.URI).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // JavaScriptSerializer форматтер для сериализации и десериализации JSON. Находится в сборке System.Web.Extensions
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                string resposeText = response.Content.ReadAsStringAsync().Result;
                IEnumerable<Task> tasks = jsSerializer.Deserialize<IEnumerable<Task>>(resposeText);

                foreach (Task item in tasks)
                {
                    Console.WriteLine("{0, 3} - {1, 20} {2, 10}", item.ID, item.Name, item.IsCompleted);
                }

            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Program.PrintError("404. Not Found");
            }
        }
    }
}


