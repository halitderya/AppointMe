using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.DevxUI.Preferences
{
    public static class ApplyThemeSettings
    {
      
        

        public static void ApplyTheme(string NewTheme)
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None);
            var a = config.AppSettings;

        }
    }
}
