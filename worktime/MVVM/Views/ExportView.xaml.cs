using MVVVM.Worktime.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Worktime.Data;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using Worktime.Core;

namespace Worktime.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ExportView.xaml
    /// </summary>
    public partial class ExportView : UserControl
    {
        public ObservableCollection<Worker>? Workers { get; set; }

        public ExportView()
        {
            Workers = new ObservableCollection<Worker>();
            InitializeComponent();
            InitWorkers();
            DataContext = this; //Beállítjuk a bindinghoz
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

        private void ExportTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            ExportTasksBtn.IsEnabled = false; //Kikapcsoljuk az exportálás gombot amíg a riport elkészül
            try
            {
                using (var context = new WorktimeContext())
                { 
                    var tasks = context.WorkTasks
                        .Where(task => task.Date >= startDate.DisplayDate && task.Date <= endDate.DisplayDate) //Megkeressük azokat a taskokat amelyek a megadott 2 dátumon belül vannak 
                        .Include(task => task.Activity) //Includeoljuk az activtyket
                        .ToList();
                    var activites = context.Activities.ToList();

                    Dictionary<string, int> activityTimes = new Dictionary<string, int>(); //Dictionary a taskok és a hozzájuk tartozó idő tárolásához
                    foreach (var activity in activites)
                    {
                        activityTimes.Add(activity.Title, 0); //Feltöltjük a dictionaryt az activitykkel (task típusok)
                    }

                    foreach (var task in tasks)
                    {
                        activityTimes[task.Activity.Title] += task.WorkHour * 60 + task.WorkMin; //Hozzáadjuk a task típusokhoz a rájuk fordított időt percben
                    }

                    //Új excel munkafüzetet hozunk létre
                    var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("TaskRiport");

                    //Feltöltjük az első sort
                    worksheet.Cell(1, 1).Value = "Tevékenység";
                    worksheet.Cell(1, 2).Value = "Eltöltött idő (perc)";

                    int i = 2;
                    foreach (var activity in activityTimes)
                    {
                        if (activity.Value == 0) continue; //Csak azokat a taskokat vesszük figyelembe amelyeken dolgoztak
                        worksheet.Cell(i, 1).Value = activity.Key;
                        worksheet.Cell(i, 2).Value = activity.Value;
                        i++; //Következő sor
                    }
                    workbook.SaveAs($"taskRiport_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx"); //DateTimeot használunk a filenévnél hogy kerüljük a név ütközést
                    MessageBoxController.ShowSuccess("Riport sikeresen létrehozva!");
                }
            }
            catch (Exception exception)
            {
                MessageBoxController.ShowFail("Hiba történt a riport létrehozásakor: " + exception.Message);
            }
            ExportTasksBtn.IsEnabled = true;
            
        }

        private void ExportWorkerTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            //Input ellenőrzés
            if (string.IsNullOrEmpty(WorkerComboBox.Text.Trim()))
            {
                MessageBoxController.ShowFail("Válassza ki a dolgozót!");
                return;
            }
            ExportWorkerTasksBtn.IsEnabled = false; //Kikapcsoljuk az exportálás gombot amíg a riport elkészül
            try
            {
                using (var context = new WorktimeContext())
                {
                    var tasks = context.WorkTasks
                        .Include(task => task.Worker) //Includeoljuk a dolgozókat
                        .Where(task => task.Worker.Name == WorkerComboBox.Text && task.Date >= startDateWorker.DisplayDate && task.Date <= endDateWorker.DisplayDate) //Kiválasztjuk a megadott dolgozó taskjait
                        .ToList();
                    var activites = context.Activities.ToList();

                    Dictionary<string, int> activityTimes = new Dictionary<string, int>(); //Dictionary a taskok és a hozzájuk tartozó idő tárolásához
                    foreach (var activity in activites)
                    {
                        activityTimes.Add(activity.Title, 0); //Feltöltjük a dictionaryt az activitykkel (task típusok)
                    }

                    foreach (var task in tasks)
                    {
                        activityTimes[task.Activity.Title] += task.WorkHour * 60 + task.WorkMin; //Hozzáadjuk a task típusokhoz a rájuk fordított időt percben
                    }

                    //Új excel munkafüzetet hozunk létre
                    var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("WorkerRiport");

                    //Feltöltjük az első sort
                    worksheet.Cell(1, 1).Value = "Tevékenység";
                    worksheet.Cell(1, 2).Value = "Eltöltött idő (perc)";

                    int i = 2;
                    foreach (var activity in activityTimes)
                    {
                        if (activity.Value == 0) continue; //Csak azokat a taskokat vesszük figyelembe amelyeken dolgoztak
                        worksheet.Cell(i, 1).Value = activity.Key;
                        worksheet.Cell(i, 2).Value = activity.Value;
                        i++; //Következő sor
                    }
                    workbook.SaveAs($"{WorkerComboBox.Text}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx"); //DateTimeot használunk a filenévnél hogy kerüljük a név ütközést
                    MessageBoxController.ShowSuccess("Riport sikeresen létrehozva!");
                }
            }
            catch (Exception exception)
            {
                MessageBoxController.ShowFail("Hiba történt a riport létrehozásakor: " + exception.Message);
            }
            ExportWorkerTasksBtn.IsEnabled = true;
        }
    }
}
