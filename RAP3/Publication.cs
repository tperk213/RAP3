using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP3
{
    class Publication
    {
       /* private Dictionary<PublicationLevel, String> ExpectedPublication = new Dictionary<PublicationLevel, String>
            {
                { PublicationLevel.A, "0.5"},
                { PublicationLevel.B, "1"},
                { PublicationLevel.C, "2" },
                { PublicationLevel.D, "3.2"},
                { PublicationLevel.E, "4" }
            };
       */
        public String Title { get; set; }
        public String Doi { get; set; }

        public String PublicationYear { get; set; }

        public String ThreeYearAvg { get; set; }

        public int NumberOfPublication { get; set; }

        public String Performance { get; set; }

        //get Performance

        
    }
}
