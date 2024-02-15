using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Task_Manager.Commands;
using Task_Manager.Models;
using Task_Manager.Services;

namespace Task_Manager.ViewModels;

public class MainPageViewModel : NotificationService
{
    private ObservableCollection<MyProccessClass>? processes = new();
    private string runNewTaskName;

    public ObservableCollection<MyProccessClass> Processes { get => processes!; set { processes = value; OnPropertyChanged(); } }

    public string RunNewTaskName { get => runNewTaskName; set { runNewTaskName = value;OnPropertyChanged(); } }

    public ICommand RunNewTaskCommand { get; set; }
    public ICommand EndTaskCommand { get; set; }


    public ListView listView { get; set; }


    public MainPageViewModel(ListView listView)
    {
        foreach (var item in Process.GetProcesses())
        {
            MyProccessClass proccessClass= new MyProccessClass()
            {
                Id = item.Id,
                MachineName = Environment.MachineName,
                ProcesssName = item.ProcessName,

            };
            processes.Add(proccessClass);

        }
        this.listView = listView;
        RunNewTaskCommand = new RelayCommand(RunNewTask);
        EndTaskCommand = new RelayCommand(EndTask);
    }

    private void EndTask(object? obj)
    {
        int id = Convert.ToInt32(listView.SelectedValue);
        if (id != null)
        {
            Process.GetProcessById(id).Kill();

        }
        else
            MessageBox.Show("You must select something from list");
    }

    private void RunNewTask(object? obj)
    {
        if (RunNewTaskName != null)
        {
            try
            {
                Process.Start(RunNewTaskName);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        else
            MessageBox.Show("NULL");
    }
}
