public class EnUs : ITranslation
{
    public string Error => "Error";

    public string GetErrorMessage(Type type)
    {
        if (type == typeof(ArgumentNullException))
            return "Argument null";
        if (type == typeof(ArgumentException))
            return "Invalid argument";
        if (type == typeof(InvalidOperationException))
            return "Invalid operation";
        if (type == typeof(NotImplementedException))
            return "Method not implemented";
        if (type == typeof(NotSupportedException))
            return "Operation not supported";
        if (type == typeof(NullReferenceException))
            return "Null reference";
        if (type == typeof(FormatException))
            return "Invalid format";
        if (type == typeof(OverflowException))
            return "Overflow";
        if (type == typeof(InvalidCastException))
            return "Invalid cast";
        if (type == typeof(IndexOutOfRangeException))
            return "Index out of range";
        if (type == typeof(TimeoutException))
            return "Timeout";
        if (type == typeof(InvalidOperationException))
            return "Invalid operation";
        if (type == typeof(NotImplementedException))
            return "Method not implemented";
        if (type == typeof(NotSupportedException))
            return "Operation not supported";
        if (type == typeof(NullReferenceException))
            return "Null reference";
        if (type == typeof(FormatException))
            return "Invalid format";
        if (type == typeof(OverflowException))
            return "Overflow";
        if (type == typeof(InvalidCastException))
            return "Invalid cast";
        if (type == typeof(IndexOutOfRangeException))
            return "Index out of range";
        if (type == typeof(TimeoutException))
            return "Timeout";
        return "Error";
    }
}