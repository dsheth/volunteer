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
using volunteer.Pages;

namespace volunteer
{
    /// <summary>
    /// Interaction logic for VolunteerHome.xaml
    /// </summary>
    public partial class VolunteerHome : Page
    {
        public VolunteerHome()
        {
            InitializeComponent();
        }

        private void Work_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Families_Click(object sender, RoutedEventArgs e)
        {
            FamiliesPage fp = new FamiliesPage();
            var family = new Family();
            family.MaritalStatus = "Married";
            family.Name = "test family name";
            family.HoursRequired = 3;
            var db = new volunteer_dbEntities();
            db.Families.Add(family);
            db.SaveChanges();
            this.NavigationService.Navigate(fp);
        }
        private void Tasks_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Talents_Click(object sender, RoutedEventArgs e)
        {

        }
        private void People_Click(object sender, RoutedEventArgs e)
        { 
        }
    }
}
