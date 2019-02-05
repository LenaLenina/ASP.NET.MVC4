using HttpClientSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HttpClientSample.Controllers
{
    public class TasksController : ApiController
    {
        // Получение всех задач
        public IEnumerable<Task> Get()
        {
            return TasksDataSource.All;
        }

        // Создание новой задачи
        public HttpResponseMessage Post([FromBody]Task task)
        {
            try
            {
                int id = TasksDataSource.All.Max(x => x.ID);
                task.ID = id + 1;
                TasksDataSource.All.Add(task);
                return Request.CreateResponse(HttpStatusCode.Created, task);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // Обновление задачи по id
        public HttpResponseMessage Put(int id, [FromBody]Task task)
        {
            Task oldTask = TasksDataSource.All.Where(x => x.ID == id).FirstOrDefault();
            if (oldTask == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                oldTask.Name = task.Name;
                oldTask.IsCompleted = task.IsCompleted;

                return Request.CreateResponse(HttpStatusCode.OK, task);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // Удаление задачи по id
        public HttpResponseMessage Delete(int id)
        {
            Task toDelete = TasksDataSource.All.Where(x => x.ID == id).FirstOrDefault();
            if (toDelete == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                TasksDataSource.All.Remove(toDelete);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
