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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static volunteer_dbEntities db = new volunteer_dbEntities();
        public MainWindow()
        {
            InitializeComponent();
        }
        void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }
        public static volunteer_dbEntities dbInstance() { return db; }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            db = new volunteer_dbEntities();
            Tabs.Visibility = Visibility.Hidden;
            Tabs.Visibility = Visibility.Visible;
          
        }
    }
    
}
