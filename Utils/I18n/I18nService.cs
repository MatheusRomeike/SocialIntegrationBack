using Utils.I18n.Interfaces;

public class DefaultI18nService : II18nService
{
    public string Locale { get; private set; } = "pt_BR";
    public ITranslation Current { get; private set; } = new PtBr();

    public void Load(string locale)
    {
        Locale = locale.ToLower();

        switch (Locale)
        {
            case "pt_br":
                Current = new PtBr();
                break;
            case "en_us":
                Current = new EnUs();
                break;
            default:
                Current = new PtBr();
                break;
        }
    }

    public string GetErrorMessage(Type exceptionType)
    {
        return Current.GetErrorMessage(exceptionType);
    }
}