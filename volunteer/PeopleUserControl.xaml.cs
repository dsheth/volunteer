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
    /// Interaction logic for PeopleUserControl.xaml
    /// </summary>
    public partial class PeopleUserControl : UserControl
    {
        public PeopleUserControl()
        {
            InitializeComponent();
        }

        private void RefreshFromDb()
        {
            var db = MainWindow.dbInstance();
   
            var peopleList = db.Persons.Include(p => p.Family).ToList();
            PeopleGrid.DataContext = peopleList;
   
            var families = from f in db.Families select f;
            families = families.OrderBy(f => f.Name);
            FamiliesComboBox.ItemsSource = families.ToList();
           
        }

    
        private void PeopleTab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true) { RefreshFromDb(); }
        }

        private void Click_NoAssociatedFamily(object sender, RoutedEventArgs e)
        {
            FamiliesComboBox.SelectedIndex = -1;
        }
    }
}
