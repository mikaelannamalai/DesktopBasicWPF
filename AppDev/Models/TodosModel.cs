using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev.Models
{
    public class TodosModel
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}




/*        try
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

*/
/*Task.Run(() => GetDbEmp());
{
    try
    {
        _fbclient = new FirebaseClient("https://employee-39933-default-rtdb.firebaseio.com/");
    }
    catch
    {
        MessageBox.Show("No Internet or Connection Problem");
    }

}*/