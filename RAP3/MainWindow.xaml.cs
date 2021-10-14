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

namespace RAP3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResearcherListView.SelectResearcherEvent += LoadResearcherDetails;

            //Ammar
            ResearcherDetailsViewContent.SelectPublicationEvent += LoadPublicationDetails;

        }

        // 
        private void LoadResearcherDetails(object sender, EventArgs e)
        {
            ResearcherDetailsViewContent.SelectResearcher(sender, e);
        }

        private void LoadPublicationDetails(object sender, EventArgs r)
        {
            PublicationViewContent.SelectPublication(sender, r);
        }

        private void ResearcherDetailsViewContent_Loaded()
        {

        }
        /* private void Button_Click(object sender, RoutedEventArgs e)
{
    Window2 win2 = new Window2();
    win2.Show();
}*/
    }
}
