using AppDev.Models;
using Caliburn.Micro;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppDev.ViewModels
{
    internal class TodosViewModel : BaseViewModel
    {
        public BindableCollection<TodosModel> Todo { get; set; }

        public TodosViewModel()
        {
            Todo = new BindableCollection<TodosModel>();
            _ = GetTodos();

        }
        private async Task GetTodos()
        {
            using (var httpClient = new HttpClient())
            {

                var todosJson = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/todos");
                var todoItems = JsonConvert.DeserializeObject<TodosModel[]>(todosJson);
                foreach (var item in todoItems)
                {
                    Todo.Add(item);
                }
            }
        }



    }
}
