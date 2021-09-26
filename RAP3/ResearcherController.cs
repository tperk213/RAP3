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
        private List<Researcher> masterResearcherList;
        private ObservableCollection<Researcher> viewableResearcherList;


        public ResearcherController()
        {
            viewableResearcherList = new ObservableCollection<Researcher>();
            masterResearcherList = DatabaseAdapter.LoadResearchers();
            
            foreach (var curRes in masterResearcherList)
            {
                viewableResearcherList.Add(curRes);
            }

        }

        

        public ObservableCollection<Researcher> GetResearchers()
        {
            return viewableResearcherList;
        }

        public void FilterByLevel(EmploymentLevel requestedLevel)
        {
            viewableResearcherList.Clear();
            
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

        }

    }
}
