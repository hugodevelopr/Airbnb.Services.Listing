namespace Airbnb.Core.ValueObject;

public sealed class Address : IEquatable<Address>
{
    public string Country { get; }
    public string State { get; }
    public string City { get; }
    public string Street { get; }
    public string ZipCode { get; }

    public Address(string country, string state, string city, string street, string zipCode)
    {
        Country = country;
        State = state;
        City = city;
        Street = street;
        ZipCode = zipCode;
    }

    public bool Equals(Address? other)
    {
        if (other == null) return false;

        return Country == other.Country &&
               State == other.State &&
               City == other.City &&
               Street == other.Street &&
               ZipCode == other.ZipCode;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is Address other && Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;

            hash = hash * 23 + (Country?.GetHashCode() ?? 0);
            hash = hash * 23 + (State?.GetHashCode() ?? 0);
            hash = hash * 23 + (City?.GetHashCode() ?? 0);
            hash = hash * 23 + (Street?.GetHashCode() ?? 0);
            hash = hash * 23 + (ZipCode?.GetHashCode() ?? 0);

            return hash;
        }
    }

    public static bool operator ==(Address? left, Address? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Address? left, Address? right)
    {
        return !Equals(left, right);
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}, {ZipCode}";
    }
}