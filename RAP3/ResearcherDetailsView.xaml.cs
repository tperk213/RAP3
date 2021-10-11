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

namespace RAP3
{

    /// <summary>
    /// Interaction logic for ResearcherDetailsView.xaml
    /// </summary>
    public partial class ResearcherDetailsView : UserControl
    {
        private ResearcherController researcherController;

       
        public ResearcherDetailsView()
        {
            InitializeComponent();
            researcherController = (ResearcherController)Application.Current.FindResource("researcherController");

        }

        public void SelectResearcher(object sender, EventArgs ea)
        {
            
            var e = (SelectionChangedEventArgs)ea;

            if (e.AddedItems.Count == 0)
            {
                ResearchDetails.DataContext = null;
            }
            else
            {
                //Researcher r = DatabaseAdapter.FetchFullResearcherDetails((Researcher)e.AddedItems[0]);
                Researcher r = researcherController.GetResearcherDetails((Researcher)e.AddedItems[0]);
                ResearchDetails.DataContext = r;
                PrePositions.ItemsSource = r.Positions;
                Performance.DataContext = r.Publications;
                PublicationLists.ItemsSource = r.Publications;
                Console.WriteLine(r);
            }
            
        }
    }
}
