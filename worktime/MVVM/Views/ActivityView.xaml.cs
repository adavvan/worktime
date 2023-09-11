using Microsoft.EntityFrameworkCore;
using MVVVM.Worktime.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Worktime.Core;
using Worktime.Data;

namespace Worktime.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ActivityView.xaml
    /// </summary>
    public partial class ActivityView : UserControl
    {

        //Gyűjtemények a Bindingokhoz
        public ObservableCollection<WorkTask>? WorkTasks { get; set; }
        public ObservableCollection<Activity>? Activities { get; set; }
        public ObservableCollection<Worker>? Workers { get; set; }

        public ActivityView()
        {

            //Inicializáljuk a gyűjteményeket
            WorkTasks = new ObservableCollection<WorkTask>();
            Activities = new ObservableCollection<Activity>();
            Workers = new ObservableCollection<Worker>();

            //Init
            InitializeComponent();
            InitWorkers();
            InitWorktimeBoxes();
            InitActivites();
            InitWorkTasks();
            DataContext = this; //Beállítjuk a bindinghoz
        }

        private void InitWorkTasks()
        {
            using (var context = new WorktimeContext())
            {
                // Lazy loading miatt includeolnunk kell a Workert és az Activity propertyket
                var tasks = context.WorkTasks.Include(wt => wt.Worker).Include(wt => wt.Activity).ToList();  

                foreach (var task in tasks)
                {
                    if (WorkTasks != null) WorkTasks.Add(task);
                }
            }
        }

        private void InitWorkers()
        {
            using (var context = new WorktimeContext())
            {
                var workers = context.Workers.ToList();  // Dolgozók lekérdezése
                foreach (var worker in workers)
                {
                    if (Workers != null) Workers.Add(worker);
                }
            }
        }

        private void InitWorktimeBoxes()
        {
            WorkHourComboBox.ItemsSource = Enumerable.Range(0, 24); // Óra combobox feltöltése 0-tól 23-ig
            int[] mins = { 0, 15, 30, 45 };
            WorkMinComboBox.ItemsSource = mins; // Perx combobox feltöltése a tömbbel
        }
        private void InitActivites()
        {
            using (var context = new WorktimeContext())
            {
                var activites = context.Activities.ToList();
                foreach (var activity in activites)
                {
                    if (Activities != null) Activities.Add(activity);
                }
            }
        }

        public void CreateActivity()
        {
            if (string.IsNullOrEmpty(ActivityTitleInput.Text.Trim())) //Ellenőrizzük, hogy nem üres e a dolgozó neve
            {
                MessageBoxController.ShowFail("Adjon meg egy tevékenység címet!");
                return;
            }
            try
            {
                using (WorktimeContext context = new WorktimeContext())
                {
                    Activity activity = new Activity()
                    {
                        Title = ActivityTitleInput.Text,
                    };
                    context.Activities.Add(activity);
                    context.SaveChanges();
                    if (Activities != null) Activities.Add(activity);
                    MessageBoxController.ShowSuccess("Tevékenység típus sikeresen hozzáadva!");
                }
            }
            catch (Exception e)
            {
                MessageBoxController.ShowFail("Hiba történt a tevékenység típus létrehozásakor: " + e.Message);
            }
            
        }

        private void RemoveActivity(string title)
        {
            using (WorktimeContext context = new WorktimeContext())
            {
                var activity = context.Activities.FirstOrDefault(activity => activity.Title == title);
                if (activity != null)
                {
                    context.Activities.Remove(activity);
                    context.SaveChanges();
                }
            }
        }


        private void AddWorkTask()
        {
            //Input ellenőrzés
            if (string.IsNullOrEmpty(WorkerComboBox.Text.Trim()))
            {
                MessageBoxController.ShowFail("Válassza ki a dolgozót!");
                return;
            }
            if (string.IsNullOrEmpty(ActivityComboBox.Text.Trim()))
            {
                MessageBoxController.ShowFail("Adjon meg egy tevékenység címet!");
                return;
            }
            if (!int.TryParse(WorkHourComboBox.Text, out int workHour) || workHour > 23 || workHour < 0)
            {
                MessageBoxController.ShowFail("A megadott óra formátuma helytelen!");
                return;
            }
            if (!int.TryParse(WorkMinComboBox.Text, out int workMin) || workMin < 0 || workMin > 59)
            {
                MessageBoxController.ShowFail("A megadott perc formátuma helytelen!");
                return;
            }
            if (workMin == 0 && workHour == 0)
            {
                MessageBoxController.ShowFail("Legalább az órát vagy a percet meg kell adni!");
                return;
            }
            try
            {
                using (WorktimeContext context = new WorktimeContext())
                {
                    //Lekérjük dolgozót és a tevékenységét
                    var worker = context.Workers.FirstOrDefault(worker => worker.Name == WorkerComboBox.Text);
                    var activity = context.Activities.FirstOrDefault(activity => activity.Title == ActivityComboBox.Text);

                    //Ellenőrizzül, hogy létezik e a dolgozó és a tevékenység az adatbázisban
                    if (worker == null)
                    {
                        MessageBoxController.ShowFail("Nem található a dolgozó az adatbázisban!");
                        return;
                    }
                    if (activity == null)
                    {
                        MessageBoxController.ShowFail("Nem található a tevékenység az adatbázisban!");
                        return;
                    }

                    //Létrehozzuk az a WordTaskot, majd elmentjük az adatbázisba
                    WorkTask workTask = new WorkTask()
                    {
                        Worker = worker,
                        Date = WorkTaskDate.DisplayDate,
                        WorkHour = workHour,
                        WorkMin = workMin,
                        Description = WorkTaskDescInput.Text,
                        Activity = activity
                    };
                    context.WorkTasks.Add(workTask);
                    context.SaveChanges();
                    if (WorkTasks != null) WorkTasks.Add(workTask);
                    MessageBoxController.ShowSuccess("Tevékenység sikeresen felvéve az adatbázisba!");
                }
            }
            catch (Exception e)
            {
                MessageBoxController.ShowFail("Hiba történt a tevékenység létrehozásakor: " + e.Message);
            }
        }

        private void AddActivityBtn_Click(object sender, RoutedEventArgs e) => CreateActivity();

        private void WorkTaskAddBtn_Click(object sender, RoutedEventArgs e) => AddWorkTask(); 
    }
}
