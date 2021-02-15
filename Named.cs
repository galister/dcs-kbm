using System;

namespace KBM_88
{
    public class Named<T> : IEquatable<Named<T>>, IComparable<Named<T>> where T : IEquatable<T>, IComparable<T>
    {
        public string Name { get; }
        public T Thing { get; }
        
        public Named(string name, T thing)
        {
            Name = name;
            Thing = thing;
        }

        public bool Equals(Named<T> other)
        {
            return Name.Equals(other?.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public int CompareTo(Named<T> other)
        {
            return String.Compare(Name, other?.Name, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}