using AppDev.Models;
using Caliburn.Micro;
using Firebase.Database;
using Firebase.Database.Query;
using FireSharp.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Action = System.Action;

namespace AppDev.ViewModels
{
    public class EmployeeViewModel : BaseViewModel 
    {


        private int _id;
        private string _username;
        private string _name;
        private string _email;
        private string _phone;
        private string _website;
        private ObservableCollection<EmployeeModel> _dbEmployees = new ObservableCollection<EmployeeModel>();

        FirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "DKRlPb7gPbVVpAdrs9G0cfWt2Rshm6zGqjEcBT96",
            BasePath = "https://employee-39933-default-rtdb.firebaseio.com/"
        };
        FirebaseClient _fbclient;
        private ICommand _addUsersCommand;
        private ICommand _deleteUsersCommand;
        private ICommand _editUsersCommand;
        private ICommand _updateUsersCommand;
        private ICommand _showUsersCommand;

        public ObservableCollection<EmployeeModel> DbEmployees { get => _dbEmployees; set => _dbEmployees = value; }

        public FirebaseClient FBClient
        {
            get { return _fbclient; }
        }



        public int Id {
            get => _id; set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string UserName
        {
            get => _username; set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged("UserName");
                }
            }
        }
        public string Name { get => _name; set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Email { get => _email; set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Phone { get => _phone; set
            {
                if (value != _phone)
                {
                    _phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }
        public string Website { get => _website; set
            {
                if (value != _website)
                {
                    _website = value;
                    OnPropertyChanged("Website");
                }
            }
        }


        private EmployeeModel _selectedJSONEmployee;
        public BindableCollection<EmployeeModel> Users { get; set; }

        public EmployeeViewModel()
        {
            Users = new BindableCollection<EmployeeModel>();
            _ = GetEmployees();


            Task.Run(() => GetDbEmp());
            {
                try
                {
                    _fbclient = new FirebaseClient("https://employee-39933-default-rtdb.firebaseio.com/");
                }
                catch
                {
                    MessageBox.Show("No Internet or Connection Problem");
                }

            }
        }
        private async void GetDbEmp()
        {
            try
            {
                var temp = await FBClient.Child("Employees").OrderByKey().OnceAsync<EmployeeModel>();
                await App.Current.Dispatcher.BeginInvoke((Action)delegate () { DbEmployees.Clear(); });

                foreach (var e in temp)
                {
                    await App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                    {
                        DbEmployees.Add(new EmployeeModel
                        {
                            Key = e.Key,
                            id = e.Object.id,
                            username = e.Object.username,
                            name = e.Object.name,
                            phone = e.Object.phone,
                            website = e.Object.website
                        });
                    });
                }
            }
            catch (Exception ex) { }
        }


        public EmployeeModel SelectedJSONEmployee
        {
            get => _selectedJSONEmployee; set
            {
                if (value != _selectedJSONEmployee)
                {
                    _selectedJSONEmployee = value;
                    OnPropertyChanged("SelectedJSONEmployee");
                }
            }
        }

        public ICommand AddUsersCommand { get => _addUsersCommand; set => _addUsersCommand = value; }

        private async Task GetEmployees()
        {
            using (var httpClient = new HttpClient())
            {

                var todosJson = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/users/");
                var todoItems = JsonConvert.DeserializeObject<EmployeeModel[]>(todosJson);
                foreach (var item in todoItems)
                {
                    Users.Add(item);
                }
            }
        }



    }
}
