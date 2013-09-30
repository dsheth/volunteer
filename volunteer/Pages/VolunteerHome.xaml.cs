﻿using System;
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
            FamiliesPage fp = new FamiliesPage();
            this.NavigationService.Navigate(fp);
        }
    }
}
