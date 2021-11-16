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
    /// Interaction logic for ResearchListControl.xaml
    /// </summary>
    public partial class ResearcherListControl : UserControl
    {
        private ResearcherController researcherController;

        public event EventHandler SelectResearcherEvent;
        public ResearcherListControl()
        {
            researcherController = (ResearcherController)Application.Current.FindResource("researcherController");
            InitializeComponent();
                      
        }

        private void selectionOfResearcher(object sender, SelectionChangedEventArgs e)
        {
            SelectResearcherEvent?.Invoke(sender, e);
        }

        private void jobTitleSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Check for start up of the program
            if (ResearchersList == null)
            {
                researcherController.FilterByLevel((EmploymentLevel)Enum.Parse(typeof(EmploymentLevel), e.AddedItems[0].ToString()));
                return;
            }

            //Keep the current slected researcher if they are in the filtered list or select first option           
            Researcher currentlySelectedResearcher = (Researcher)ResearchersList.SelectedItem;
            researcherController.FilterByLevel((EmploymentLevel)Enum.Parse(typeof(EmploymentLevel), e.AddedItems[0].ToString()));
            if (ResearchersList.Items.Contains(currentlySelectedResearcher))
            {
                ResearchersList.SelectedItem = currentlySelectedResearcher;
            }
            else
            {
                ResearchersList.SelectedIndex = 0;
            }

          
        }

        private void FilterByName(object sender, TextChangedEventArgs e)
        {
            //Keep the current slected researcher if they are in the filtered list or select first option
            Researcher r = (Researcher)ResearchersList.SelectedItem;
            researcherController.FilterByName(NameFilter.Text);
            if (ResearchersList.Items.Contains(r))
            {
                ResearchersList.SelectedItem = r;
            }
            else
            {
                ResearchersList.SelectedIndex = 0;
            }

        }
    }
}
