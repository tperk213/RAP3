using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAPFinal;
using RAPFinal.Models;

namespace RAPFinal.Utils
{
    class SearchTree
    {
        private Dictionary<Char, SearchTree> children;
        private List<Researcher> data;


        public SearchTree()
        {
            children = new Dictionary<char, SearchTree>();
            data = new List<Researcher>();
        }
        public void InsertIntoTree(Researcher insertData)
        {
            //first itteration
            for (int i = 0; i < insertData.FullName.Length; i++)
            {
                InsertIntoTree(insertData, insertData.FullName.Substring(i));
            }
            //check if longer the 1 char
        }
        public void InsertIntoTree(Researcher insertData, String currentData)
        {
            //check for end case
            if (currentData.Length == 0)
            {
                data.Add(insertData);
                return;
            }
            //check letter in children
            char current = currentData[0];
            currentData = currentData.Substring(1);
            if (!children.ContainsKey(current))
            {
                children[current] = new SearchTree();
            }

            children[current].InsertIntoTree(insertData, currentData);
        }
        public List<Researcher> Search(String textToBeFound)
        {
            List<Researcher> matches = new List<Researcher>();
            //exit condition
            if (textToBeFound.Length == 0)
            {
                matches = returnAll();
                return matches;
            }
            //more to be searched
            char current = textToBeFound[0];
            textToBeFound = textToBeFound.Substring(1);
            if (!children.ContainsKey(current))
            {
                return matches;
            }
            return children[current].Search(textToBeFound);

        }

        public List<Researcher> returnAll()
        {
            List<Researcher> matches = new List<Researcher>();
            //exit condition
            if (children.Count == 0)
            {
                matches.AddRange(data);
            }
            foreach (var child in children)
            {
                matches.AddRange(child.Value.returnAll());
            }

            List<Researcher> finalMatches = new List<Researcher>();
            finalMatches.AddRange(matches.Distinct());
            return finalMatches;
            //returns all the results from this node onwards
        }

        public void Clear()
        {
            children.Clear();
            data.Clear();
        }
    }
}
