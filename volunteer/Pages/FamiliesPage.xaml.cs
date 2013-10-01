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
            System.Windows.Data.CollectionViewSource familyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("familyViewSource")));
            _context.Families.Load();
            familyViewSource.Source = _context.Families.Local;
        }
    }
}
