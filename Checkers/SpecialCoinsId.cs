using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Assignment.Checkers
{
    internal class SpecialCoinsId
    {
        public static Dictionary<string, string> replacements = new Dictionary<string, string>()
        {
            { "bytecoin", "bytecoin-bcn" },
            { "golem", "golem-network-tokens" },
            { "iost", "iostoken" },
            { "metaverse etp", "metaverse" },
            { "nebulas", "nebulas-token" },
            { "polymath", "polymath-network" }
        };
    }
}
