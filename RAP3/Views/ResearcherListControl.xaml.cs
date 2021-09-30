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
using RAP3;
using RAP3.Control;

namespace RAP3.View
{
    /// <summary>
    /// Interaction logic for ResearchListControl.xaml
    /// </summary>
    public partial class ResearchListControl : UserControl
    {
        private ResearcherController researcherController;

        public event EventHandler SelectResearcherEvent;
        public ResearchListControl()
        {
            InitializeComponent();
            researcherController = (ResearcherController) Application.Current.FindResource("researcherController");
            
        }

        private void selectionOfResearcher(object sender, SelectionChangedEventArgs e)
        {
            /*researcherDetails.DataContext = e.AddedItems[0];*/
            SelectResearcherEvent?.Invoke(sender, e);
        }

        private void jobTitleSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("DropDownSelection is :" + e.AddedItems[0]);
            researcherController.FilterByLevel((EmploymentLevel)Enum.Parse(typeof(EmploymentLevel), e.AddedItems[0].ToString()));

        }

        private void FilterByName(object sender, TextChangedEventArgs e)
        {
            researcherController.FilterByName(NameFilter.Text);
        }


    }
}
