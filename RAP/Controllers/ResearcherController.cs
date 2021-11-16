using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using RAPFinal;
using RAPFinal.Controllers;
using RAPFinal.Models;
using RAPFinal.Views;
using RAPFinal.Utils;
using System.Windows.Controls;

namespace RAPFinal.Controllers
{
   
    class ResearcherController
    {
        //DatabaseAdapter referece
        private List<Researcher> masterResearcherList;
        private ObservableCollection<Researcher> viewableResearcherList;
        private SearchTree tree;
        private EmploymentLevel filterLevel;
        private String filterName;

        private Researcher researcherDetails;
        public Researcher CurrentlySelected { get; private set; }

        public ResearcherController()
        {
            viewableResearcherList = new ObservableCollection<Researcher>();
            List<Researcher> researchers = DatabaseAdapter.LoadResearchers();
            masterResearcherList = researchers;
            tree = new SearchTree();

            foreach (var curRes in masterResearcherList)
            {
                viewableResearcherList.Add(curRes);
                tree.InsertIntoTree(curRes);
            }


        }

        public ObservableCollection<Researcher> GetResearchers()
        {
            return viewableResearcherList;
        }

        public void Filter()
        {
            viewableResearcherList.Clear();
            tree.Clear();

            IEnumerable<Researcher> filtered;
            //filter by level
            if (filterLevel != EmploymentLevel.All)
            {
                filtered = from researcher in masterResearcherList where researcher.Level == filterLevel select researcher;
                filtered.ToList().ForEach(viewableResearcherList.Add);
                // Filter the reasearchers by the level indicated in the dropdown box should be an event handler
            }
            else
            {
                masterResearcherList.ForEach(viewableResearcherList.Add);
            }

            viewableResearcherList.ToList().ForEach(tree.InsertIntoTree);

            //filter by name
            if ((filterName != null) && (filterName != ""))
            {
                viewableResearcherList.Clear();
                filtered = tree.Search(filterName);
                filtered.ToList().ForEach(viewableResearcherList.Add);
            }

           
        }
        public void FilterByLevel(EmploymentLevel requestedLevel)
        {
            filterLevel = requestedLevel;
            Filter();
        }

        public void FilterByName(String name)
        {
            filterName = name;
            Filter();
        }


        //fetch researcher details
        public Researcher GetResearcherDetails(Researcher researcher)
        {
            CurrentlySelected = researcher;

            researcherDetails = DatabaseAdapter.FetchFullResearcherDetails(CurrentlySelected);

            return researcherDetails;
        }


        //Calculate Tenure
        public void getTenure()
        {

        }

        //Calculate three year Average publications
        public void getThreeYearAvg()
        {

            ObservableCollection<Publication> publications = researcherDetails.Publications;

            //var threeYrCount = from publication in publications where 
        }


        //Calculate Performance
        public void getPerformance()
        {

        }
    }
}
