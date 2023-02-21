namespace Northwind.Shared.Common.Errors;

public class Error : IEquatable<Error>
{
    public string Code { get; }

    public string Message { get; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error None => new(string.Empty, string.Empty);

    public static implicit operator string(Error error) => error?.Code ?? string.Empty;

    public static bool operator ==(Error left, Error right)
    {
        if (left is null & right is null) return true;
        if (left is null || right is null) return false;

        return left.Equals(right);
    }

    public static bool operator !=(Error left, Error right) => !(left == right);

    public bool Equals(Error? other)
    {        
        if (other is null) return false;

        return Code == other.Code && Message == other.Message;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (obj is not Error error) return false;

        return Equals(error);
    }

    public override int GetHashCode() => HashCode.Combine(Code, Message);
}
