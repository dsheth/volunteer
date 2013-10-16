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
    /// Interaction logic for NewPersonUserControl.xaml
    /// </summary>
    public partial class NewPersonUserControl : UserControl
    {

      
      
        public NewPersonUserControl()
        {
            InitializeComponent();
        }

        public Family Family { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        private void NewPersonTab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true) { RefreshFromDb(); }
        }

        private void RefreshFromDb()
        {
            var db = MainWindow.dbInstance();
            FamiliesComboBox.ItemsSource = db.Families.OrderBy(f => f.Name).ToList();
        }

        private void Click_NoAssociatedFamily(object sender, RoutedEventArgs e)
        {
            FamiliesComboBox.SelectedIndex = -1;
        }

        private void Click_AddPerson(object sender, RoutedEventArgs e)
        {
            var db = MainWindow.dbInstance();
            Person p = new Person();
            p.Family = Family;
            p.FirstName = FirstName;
            p.LastName = LastName;
            p.Email = Email;
            db.Persons.Add(p);
            db.SaveChanges();
            ClearFields();
        }

        private void Click_CancelAddPerson(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            EmailTextBox.Clear();
            FamiliesComboBox.SelectedIndex = -1;
        }

    }
}
