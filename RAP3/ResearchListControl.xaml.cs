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
            researcherController = new ResearcherController();
            researcherController.LoadResearchers();
            PopulateResearcherList();
        }
        
        private void PopulateResearcherList()
        {
            List<string> researcher_names = researcherController.GetAllNames();
            foreach(string name in researcher_names)
            {
                ResearchersList.Items.Add(name);
            }
        }

    }
}
