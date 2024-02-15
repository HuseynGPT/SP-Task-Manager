using Microsoft.Xaml.Behaviors.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Services;

namespace Task_Manager.Models
{
    public class MyProccessClass : NotificationService
    {
        private int ıd;
        private string? processsName;
        private string? machineName;

        public int Id { get => ıd; set { ıd = value; OnPropertyChanged(); } }
        public string ProcesssName { get => processsName!; set { processsName = value; OnPropertyChanged(); } }
        public string MachineName { get => machineName!; set { machineName = value; OnPropertyChanged(); } }

    }
}
