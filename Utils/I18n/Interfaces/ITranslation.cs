public interface ITranslation
{
    string Error { get; }
    string GetErrorMessage(Type exceptionType);
}



