using System;
using System.Diagnostics.CodeAnalysis;

namespace iQuest.Terra
{
    public class Country : IEquatable<Country>, IComparable, IComparable<Country>
    {
        public string Name { get; }

        public string Capital { get; }

        public Country(string name, string capital)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Capital = capital ?? throw new ArgumentNullException(nameof(capital));
        }

        public override bool Equals(object obj)
        {
            if (obj is Country)
                return Equals((Country)obj);
            return base.Equals(obj);
        }

        public bool Equals(Country country)
        {
            if (ReferenceEquals(country, null)) return false;
            if (ReferenceEquals(country, this)) return true;

            return (string.Equals(Name, country.Name)) && (string.Equals(Capital, country.Capital));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Capital);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Country other = obj as Country;
            if (other == null)
                throw new ArgumentException("Invalid comparison");
            return CompareTo(other);
        }

        public int CompareTo([AllowNull] Country other)
        {
            if (other == null)
                return 1;

            int result = string.Compare(Name, other.Name);
            if (result == 0)
            {
                if (other.Capital == null)
                    result = Capital == null ? 1 : 0;
                else
                    result = Capital.CompareTo(other.Capital);
            }

            return result;
        }
    }
}