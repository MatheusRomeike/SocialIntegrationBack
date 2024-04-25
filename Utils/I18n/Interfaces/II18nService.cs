using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.I18n.Interfaces
{
    public interface II18nService
    {
        string Locale { get; }
        ITranslation Current { get; }
        void Load(string locale);
        string GetErrorMessage(Type exceptionType);
    }
}
