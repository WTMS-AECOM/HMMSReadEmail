using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMMSReadEmail
{
    [Serializable]
    class Error : Exception
    {
        internal class MissingConfig : Exception
        {
            private static string message = " ";

            public MissingConfig(string configName) : base(message)
            {
                message = "The Configuration Key " + configName + " Is Missing";
            }

        }

        internal static Exception Failure(string v)
        {
            throw new NotImplementedException();
        }
    }
}
