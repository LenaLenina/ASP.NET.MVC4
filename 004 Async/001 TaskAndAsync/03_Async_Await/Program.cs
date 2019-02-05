using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _003_Async_Await
{
    class Program
    {
        static void Main(string[] args)
        {
            // Первичный поток начинает выполнять метод SlowOperationAsync но на определенном этапе возвращает Task
            // и продолжает выполнять код метода Main. Точка в методе SlowOperationAsync, в которой первичный поток 
            // вернётся в метод Main - ключевое слово await.
            Task<int> task = SlowOperationAsync();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Результат выполнения медленной операции: {0}", task.Result);
            Console.WriteLine("Метод Main завершился в потоке {0}", Thread.CurrentThread.ManagedThreadId);
        }

        // Асинхронный метод. По соглашению, метод использующийся как асинхронный, в конце имени должен содержать слово Async
        // Возвращаемый тип метода обязательно должен быть Task или Task<T>.
        // Ключевое слово async перед возвращаемым типом, указывает на то, что поток, который войдет в этот метод,
        // на определенном этапе вернет Task не завершив метод до конца, оставшаяся часть метода будет выполнена потоком
        // который было создан через Task.
        static async Task<int> SlowOperationAsync()
        {
            Console.WriteLine("Медленная операция запущена в потоке {0}", Thread.CurrentThread.ManagedThreadId);

            // На данном этапе поток, который зашел в метод создаст и запустит задачу после чего вернется в Main.
            // По прохождению 2 секунд поток который был создан асинхронной задачей выполнит оставшийся код данного метода
            // в то время как первый поток будет продолжать работать в методе Main.
            // Ключевое слово await можно использовать только в методе помеченном ключевым словом async.
            await Task.Delay(2000);

            Console.WriteLine("Медленная операция в потоке {0} завершена.", Thread.CurrentThread.ManagedThreadId);

            return 123;
        }
    }
}