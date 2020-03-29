using System;

namespace HealthApp.Domain
{
    /// <summary>
    /// Issues on query when definning Guid Entities SQLite https://github.com/dotnet/efcore/issues/19651
    /// </summary>
    public abstract class Entity
	{
        public string Id { get; set; }

        public override bool Equals(object objToCompare)
        {
            var compareTo = objToCompare as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}
