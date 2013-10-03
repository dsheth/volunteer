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

namespace volunteer.Pages
{
    /// <summary>
    /// Interaction logic for FamiliesPage.xaml
    /// </summary>
    public partial class FamiliesPage : Page
    {
        private volunteer_dbEntities _context = new volunteer_dbEntities();
        public FamiliesPage()
        {
            InitializeComponent();
            var db = new volunteer_dbEntities();
            var familiesQuery = from family in db.Families
                                select new
                                    {
                                        FamilyName = family.Name,
                                        FamilyMaritalStatus = family.MaritalStatus,
                                        FamilyHoursRequired = family.HoursRequired
                                    };
            var familiesList = familiesQuery.ToList();
            familiesGrid.ItemsSource = familiesList;
            
        }
        protected void OnMouseDoubleClick(object sender, EventArgs args)
        {

            var row = sender as DataGridRow;
            if (row != null && row.IsSelected)
            {
                Console.WriteLine("double click");
                
            }
        }
    }

}
