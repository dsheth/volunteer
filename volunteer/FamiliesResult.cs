using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace volunteer
{
    class FamiliesResult
    {
        private int _hoursCompleted;
        private Family _family;

        public int HoursCompleted
        {
            get
            {
                return _hoursCompleted;
            }
            set
            {
                _hoursCompleted = value;
            }
        }

        public Family Family
        {
            get
            {
                return _family;
            } 
            set
            {
                _family = value;
            }
        }
    }

}
