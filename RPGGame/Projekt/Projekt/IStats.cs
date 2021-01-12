
using System.Collections.Generic;

namespace Projekt
{
    interface IStats
    {
        List<int> GetStats();
        int GetStat(string key);
    }
}
