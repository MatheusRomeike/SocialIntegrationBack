using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class i18n
    {
        public static readonly List<string> SUPPORTED_LANGUAGES = new List<string> { "en-US", "pt-BR" };
        public const string DEFAULT_LANGUAGE = "en-US";

        public const string Email_Or_Password_Invalid = "Email_Or_Password_Invalid";
        public const string Email_Already_Registered = "Email_Already_Registered";
    }
}
