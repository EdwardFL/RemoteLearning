using iQuest.Terra;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace iQuest.TerraPlus
{
    internal class CountryByCapitalComparer : Comparer<Country>
    {
        public override int Compare([AllowNull] Country x, [AllowNull] Country y)
        {
            if (object.ReferenceEquals(x, y))
                return 0;

            if (x == null)
                return -1;

            if (y == null)
                return 1;

            return x.Capital.CompareTo(y.Capital);
        }
    }
}