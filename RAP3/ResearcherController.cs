using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RAP3
{
    class ResearcherController
    {
        //DatabaseAdapter referece
        private List<Researcher> masterResearcherList;
        private ObservableCollection<Researcher> viewableResearcherList;
        private SearchTree tree;

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

        public void FilterByLevel(EmploymentLevel requestedLevel)
        {
            viewableResearcherList.Clear();
            tree.Clear();
            if( requestedLevel != EmploymentLevel.All)
            {
                var filtered = from researcher in masterResearcherList where researcher.Level == requestedLevel select researcher;

                filtered.ToList().ForEach(viewableResearcherList.Add);
                // Filter the reasearchers by the level indicated in the dropdown box should be an event handler
            }
            else
            {
                masterResearcherList.ForEach(viewableResearcherList.Add);
            }

            viewableResearcherList.ToList().ForEach(tree.InsertIntoTree);

        }

        public void FilterByName(String name)
        {
            viewableResearcherList.Clear();
            var filtered = tree.Search(name);
            filtered.ToList().ForEach(viewableResearcherList.Add);
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
