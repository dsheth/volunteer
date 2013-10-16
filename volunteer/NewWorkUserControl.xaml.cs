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
    /// Interaction logic for NewWork.xaml
    /// </summary>
    public partial class NewWorkUserControl : UserControl
    {
        private Family _Family;
        private Task _Task;
        private Person _Person;
        private int _MinutesWorked = 0;
        private DateTime _DateOfWork = DateTime.Now;
        public NewWorkUserControl()
        {
            InitializeComponent();
        }

        private void RefreshFromDb()
        {
            var db = MainWindow.dbInstance();
            PeopleComboBox.ItemsSource = db.Persons.OrderBy(p => p.FirstName).ToList();
            FamiliesComboBox.ItemsSource = db.Families.OrderBy(f  => f.Name).ToList();
            TasksComboBox.ItemsSource = db.Tasks.OrderBy(t => t.Name).ToList();
        }
        private void NewWorkTab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true) { RefreshFromDb(); }
           
        }

        public Family Family { get { return _Family; } set { _Family = value; } }
        public Task Task { get { return _Task; } set { _Task = value; } }
        public Person Person { get { return _Person; } set { _Person = value; } }
        public int MinutesWorked { get { return _MinutesWorked; } set { _MinutesWorked = value; } }

        public DateTime DateOfWork { get { return _DateOfWork; } set { _DateOfWork = value; } }

        private void Click_AddWork(object sender, RoutedEventArgs e)
        {
            Work w = new Work();
            w.Family = _Family;
            w.Task = _Task;
            w.Person = _Person;
            w.DateOfWork = _DateOfWork;
            w.MinutesWorked = _MinutesWorked;

            var db = MainWindow.dbInstance();
            db.Works.Add(w);
            db.SaveChanges();
            ClearFields();
            RefreshFromDb();
          
        }

        private void ClearFields()
        {

            PeopleComboBox.SelectedIndex = -1;
            FamiliesComboBox.SelectedIndex = -1;
            TasksComboBox.SelectedIndex = -1;
            MinutesWorkedTextBox.Clear();
            DateOfWorkTextBox.SelectedDate = DateTime.Now;
        }

        private void Click_CancelWork(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshFromDb();
        }
    }
}
