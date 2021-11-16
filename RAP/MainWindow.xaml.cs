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

namespace RAP
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
            ResearcherDetailsViewContent.SelectPublicationEvent += LoadPublicationDetails;

            //Select the first researcher of the list and update researcher details view
            ResearcherDetailsViewContent.UpdateDetails(ResearcherListView.ResearchersList.SelectedItem);

            //Select first publicaiton of the publication list and update publicaitons details view
            //PublicationViewContent.SetPublication(ResearcherDetailsViewContent.PublicationLists.SelectedItem);

        }

        private void LoadResearcherDetails(object sender, EventArgs e)
        {
            ResearcherDetailsViewContent.SelectResearcher(sender, e);
        }

        private void LoadPublicationDetails(object sender, EventArgs e)
        {
            PublicationViewContent.SelectPublication(sender, e);
        }

    }
}
