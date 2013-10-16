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
using System.Data.Entity;

namespace volunteer
{
    /// <summary>
    /// Interaction logic for WorksUserControl.xaml
    /// </summary>
    public partial class WorksUserControl : UserControl
    {
        public WorksUserControl()
        {
            InitializeComponent();
        }

        private void RefreshFromDb()
        {
            var db = MainWindow.dbInstance();

            var worksList = db.Works.Include(w => w.Person).
                Include(w => w.Task).Include(w => w.Family).OrderBy(w => w.DateOfWork).
                ToList();
            
            WorksStackPanel.DataContext = worksList;
            PeopleComboBox.ItemsSource = db.Persons.ToList();
            FamiliesComboBox.ItemsSource = db.Families.ToList();
            TasksComboBox.ItemsSource = db.Tasks.ToList();
        }

        private void WorksTab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true) { RefreshFromDb(); }
        }
    }
}
