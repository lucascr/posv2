using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSV2
{
    class lv_names
    {
        /*
        public string this[string key]
        {
            get { return GetValue(key); }
            set { SetValue(key, value); }
        }
        */

        private readonly IDictionary<string, int> _yourDictionary = new Dictionary<string, int>();

        public int this[string key]
        {
            // returns value if exists
            get { return _yourDictionary[key]; }

            // updates if exists, adds if doesn't exist
            set { _yourDictionary[key] = value; }
        }
    }
}
