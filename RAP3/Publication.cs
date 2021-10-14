using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RAP3
{
    

    public enum OutputType { Conference, Journal, Other };
    public class Publication
    {
        // Fields for values from database
        public string Doi { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public int PublicationYear { get; set; }
        public OutputType Type { get; set; }
        public string CiteAs { get; set; }
        public DateTime Available { get; set; }
        public int Age { get { return DateTime.Today.Year - PublicationYear; } }
    }


   
}
