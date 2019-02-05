using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HttpClientSample.Models
{
    public class TasksDataSource
    {
        private static List<Task> _tasks = null;

        public static List<Task> All
        {
            get 
            {
                if (_tasks == null)
                {
                    _tasks = new List<Task>();
                    _tasks.Add(new Task() { ID = 1, Name = "Купить молоко", IsCompleted = false });
                    _tasks.Add(new Task() { ID = 2, Name = "Спасти мир", IsCompleted = false });
                    _tasks.Add(new Task() { ID = 3, Name = "Изучить MVC Web API", IsCompleted = false });
                }
                return _tasks;
            }
        }
    }
}