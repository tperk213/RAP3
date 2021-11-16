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
using RAPFinal;
using RAPFinal.Controllers;
using RAPFinal.Models;
using RAPFinal.Views;

namespace RAPFinal.Views
{
    /// <summary>
    /// Interaction logic for ResearcherDetailsView.xaml
    /// </summary>
    public partial class ResearcherDetailsView : UserControl
    {
        private ResearcherController researcherController;

        public event EventHandler SelectPublicationEvent;

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
                /*ResearchDetails.DataContext = r;
                PrePositions.ItemsSource = r.Positions;
                Performance.DataContext = r.Publications;
                PublicationLists.ItemsSource = r.Publications;
                Console.WriteLine(r);*/
                UpdateDetails((Researcher)e.AddedItems[0]);
            }

        }

        public void UpdateDetails(object re)
        {
            
            Researcher r = researcherController.GetResearcherDetails((Researcher)re);
            ResearchDetails.DataContext = r;
            PrePositions.ItemsSource = r.Positions;
            Performance.DataContext = r.Publications;
            PublicationLists.ItemsSource = r.Publications;
            if(r.Publications.Count > 0)
            {
                SelectionChangedEventArgs e = new SelectionChangedEventArgs(System.Windows.Controls.Primitives.Selector.SelectionChangedEvent, new List<Publication> { }, new List<Publication> { r.Publications[0]});
                selectionOfPublication(null, e);
                PublicationLists.SelectedIndex = 0;
            }
            Console.WriteLine(r);
        }

        private void selectionOfPublication(object sender, SelectionChangedEventArgs e)
        {
            /*researcherDetails.DataContext = e.AddedItems[0];*/
            SelectPublicationEvent?.Invoke(sender, e);
        }
    }
}
