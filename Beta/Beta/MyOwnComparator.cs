using System;
using System.Collections.Generic;

namespace Beta
{
    public class MyOwnComparator: IEqualityComparer<student>
    {
        public bool Equals(student x, student y)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals(
                    $"{x.firstname} {x.lastname} {x.indexNumber}",
                    $"{y.firstname} {y.lastname} {y.indexNumber}");
        }

        public int GetHashCode(student s)
        {
            return StringComparer
                .CurrentCultureIgnoreCase
                .GetHashCode($"{s.firstname} {s.lastname} {s.indexNumber}");
        }
    }
}
