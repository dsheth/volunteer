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
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;



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
            var db = MainWindow.dbInstance();



            var familiesQuery = from f in db.Families
                                from w in db.Works
                                .Where(z => z.FamilyId == f.Id).DefaultIfEmpty()

                                group new { f, w } by new { f } into g
                                orderby g.Key.f.Name
                                select new FamiliesResult
                                {
                                    Family = g.Key.f,
                                    MinutesWorked = g.Sum(y => (int?)y.w.MinutesWorked ?? 0)
                                    // MinutesWorked = 40
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





