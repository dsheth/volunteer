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

namespace volunteer
{
    /// <summary>
    /// Interaction logic for TasksUserControl.xaml
    /// </summary>
    public partial class TasksUserControl : UserControl
    {
        public TasksUserControl()
        {
            InitializeComponent();
        }
        
        private void RefreshFromDb()
        {
            var db = MainWindow.dbInstance();
            var tasksList = db.Tasks.OrderBy(t => t.Name).ToList();
            var addedTasks = db.Tasks.Local.Where(task => db.Entry(task).State == System.Data.Entity.EntityState.Added).ToList();
            tasksList.AddRange(addedTasks);
            TasksStackPanel.DataContext = tasksList;
        }

        private void TasksTab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true) { RefreshFromDb(); }
        }

        private void Add_New_Task(object sender, RoutedEventArgs e)
        {
            Task t = new Task();
            t.Name = NewTaskText.Text;
                    
            var db = MainWindow.dbInstance();
            db.Tasks.Add(t);
            NewTaskText.Clear();
            RefreshFromDb();
        }
    }
}
