using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;

namespace ConsoleHttpClient
{
    class PutAction : Action
    {
        public override void Invoke()
        {
            HttpClient client = new HttpClient();

            Console.WriteLine("Введите id задачи для изменения");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите новое имя задачи:");

            Task t = new Task();
            t.Name = Console.ReadLine();

            Console.Write("Введите значение IsComplited [true | false]:");
            t.IsCompleted = Convert.ToBoolean(Console.ReadLine());

            HttpResponseMessage response = client.PutAsync<Task>(Program.URI + "/" + id, t, new JsonMediaTypeFormatter()).Result;

            if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Элемент изменен.");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Program.PrintError("404. Not Found");
            }
        }
    }
}
