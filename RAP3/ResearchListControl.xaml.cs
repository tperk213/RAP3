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
    /// Interaction logic for ResearchListControl.xaml
    /// </summary>
    public partial class ResearchListControl : UserControl
    {
        private ResearcherController researcherController;

        public ResearchListControl()
        {
            InitializeComponent();
            researcherController = (ResearcherController) Application.Current.FindResource("researcherController");
            researcherController.LoadResearchers();
            
        }

        private void selectionOfResearcher(object sender, SelectionChangedEventArgs e)
        {
            /*researcherDetails.DataContext = e.AddedItems[0];*/
        }



    }
}
