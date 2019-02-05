using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _002_TPL
{
    class Program
    {
        // В данном примере метод SlowOperation будет выполняться в отдельном потоке.
        
        static void Main(string[] args)
        {
            // Task.Factory.StartNew<int>(метод) - Создание задачи и немедленный ее запуск.
            // Метод связанный с задачей будет возвращать значение типа int.
            // Для получения результата работы асинхронной задачи необходимо обратиться к свойству Result класса Task

            Console.WriteLine("Метод Main запущен в потоке {0}", Thread.CurrentThread.ManagedThreadId);

            Task<int> task = Task.Factory.StartNew<int>(SlowOperation);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            // Если на момент вызова task.Result задача еще не завершилась основной поток будет заблокирован до момента
            // заверения задачи.

            Console.WriteLine("Результат выполнения медленной операции: {0}", task.Result);
            Console.WriteLine("Метод Main завершился в потоке {0}", Thread.CurrentThread.ManagedThreadId);
        }

        static int SlowOperation()
        {
            Console.WriteLine("Медленная операция запущена в потоке {0}", Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(2000);

            Console.WriteLine("Медленная операция в потоке {0} завершена.", Thread.CurrentThread.ManagedThreadId);

            return 123;
        }
    }
}
