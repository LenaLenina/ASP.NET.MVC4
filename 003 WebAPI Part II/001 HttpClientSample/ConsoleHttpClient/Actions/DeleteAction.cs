using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ConsoleHttpClient
{
    class DeleteAction : Action
    {
        public override void Invoke()
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("Введите id для удаления:");

            int id = Convert.ToInt32(Console.ReadLine());

            // Отправка HTTP DELETE запроса
            HttpResponseMessage response = client.DeleteAsync(Program.URI + "/" + id).Result;

            // Провкрка статуса ответа
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Элемент удален");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Program.PrintError("404. Not Found");
            }
        }
    }
}
