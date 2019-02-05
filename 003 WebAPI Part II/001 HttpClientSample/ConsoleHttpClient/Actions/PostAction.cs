using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;

namespace ConsoleHttpClient
{
    class PostAction : Action
    {
        public override void Invoke()
        {
            HttpClient client = new HttpClient();
            
            Console.Write("Введите имя задачи:");

            Task t = new Task();
            t.Name = Console.ReadLine();
            t.IsCompleted = false;

            // Отправка POST запроса с указанием данных и форматтера для преобразования объекта для передачи по сети.
            HttpResponseMessage response = client.PostAsync<Task>(Program.URI, t, new JsonMediaTypeFormatter()).Result;

            if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Элемент создан");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Program.PrintError("404. Not Found");
            }
        }
    }
}
