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
    /// Interaction logic for FamiliesUserControl.xaml
    /// </summary>
    public partial class FamiliesUserControl : UserControl
    {
       
        public FamiliesUserControl()
        {
            InitializeComponent();
           

        }
        protected void OnMouseDoubleClick(object sender, EventArgs args)
        {

            var row = sender as DataGridRow;
            if (row != null && row.IsSelected)
            {
                Console.WriteLine("double click");

            }
        }

        private void RefreshFromDb()
        {
            var familiesQuery = from familyDb in MainWindow.dbInstance().Families
                                select new FamiliesResult
                                {
                                    Family = familyDb,
                                    HoursCompleted = 20
                                };
            var familiesList = familiesQuery.ToList();
            FamiliesStackPanel.DataContext = familiesList;

        }

        void FamiliesTab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true) { RefreshFromDb(); }

        }
      
    }
}





