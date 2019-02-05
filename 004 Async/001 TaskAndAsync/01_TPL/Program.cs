using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _001_TPL
{
    class Program
    {
        // В данном примере все методы будут работать в контексте одного потока.

        static void Main(string[] args)
        {
            // синхронный вызов метода SlowOperation()
            int result = SlowOperation();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Результат выполнения медленной операции: {0}", result);
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
