using MVVVM.Worktime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Worktime.Core;
using Worktime.Data;

namespace Worktime.MVVM.Views
{
    /// <summary>
    /// Interaction logic for WorkersView.xaml
    /// </summary>
    public partial class WorkersView : UserControl
    {
        public WorkersView()
        {
            InitializeComponent();
        }

        private void CreateWorker()
        {
            if (string.IsNullOrEmpty(WorkerInput.Text.Trim())) //Ellenőrizzük, hogy nem üres e a dolgozó neve
            {
                MessageBoxController.ShowFail("Adjon meg egy nevet!");
                return;
            }
            try
            {
                using (WorktimeContext context = new WorktimeContext())
                {
                    Worker worker = new Worker() //Létrehozzuk a dolgozót és beállítjuk a nevét
                    {
                        Name = WorkerInput.Text
                    };
                    context.Workers.Add(worker); //Hozzáadjuk a dolgozót a dolgozók táblához
                    context.SaveChanges();
                    MessageBoxController.ShowSuccess("Dolgozó sikeresen létrehozva!");
                }
            }
            catch (Exception e)
            {
                MessageBoxController.ShowFail("Hiba történt a dolgozó létrehozásakor: " + e.Message);
                throw;
            }            
        }

        private void RemoveWorker(string name)
        {
            using (WorktimeContext context = new WorktimeContext())
            {
                var worker = context.Workers.FirstOrDefault(worker => worker.Name == name); //Megkeressük a dolgozót a neve alapján

                //Ha létezik a dolgozó töröljük
                if (worker != null)
                {
                    context.Workers.Remove(worker);
                    context.SaveChanges();
                }
            }
        }

        private void AddWorkerBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateWorker();
        }
    }
}
