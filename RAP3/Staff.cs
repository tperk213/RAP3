using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP3
{
    class Staff : Researcher
    {
        public float ThreeYearAverage { get; set; }
        public float Performance { get; set; }

        public List<Researcher> Supervisions { get; set; }
    }
}
