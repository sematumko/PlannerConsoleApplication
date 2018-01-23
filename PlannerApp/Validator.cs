using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp
{
    static class Validator
    {
        public static bool addOrUpdateValidation(ref string _str) =>
            trim(ref _str).Length > 0 ? true :  false;

        public static bool removeOrFindValidation(string _str, out int _id)
        { 
            if (Int32.TryParse(trim(ref _str), out _id))
                if (_id > 0)
                    return true;

            return false;
        }
               
        private static string trim(ref string _str) => _str = _str.Trim(' ', '\t');
    }
}
