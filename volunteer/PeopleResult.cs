using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace volunteer
{
    class PeopleResult
    {
        private Person _person;
        private Family _family;


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
     
        public Person person
        {
            get
            { return _person; }
            set { _person = value; }
        }
    
    }

}
