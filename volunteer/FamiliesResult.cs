using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace volunteer
{
    class FamiliesResult
    {


        public Family Family { get; set; }
        public int MinutesWorked { get; set; }

     

        public TimeSpan HoursWorked 
        { get
            {
                return TimeSpan.FromMinutes(MinutesWorked);
            } 
        }

    }

}
