using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;

namespace FlexWebService
{
    public class WSConfig
    {
        private static WSConfig instance = null;
        public string ImagesDir { get; set; }
        public string PdfEngineDir { get; set; }
        public string LicFileLocation { get; set; }
        public string DeveloperKey { get; set; }

        private WSConfig()
        {
            // This will allow to read the Web Config from the current application
            Configuration webConfig = WebConfigurationManager.OpenWebConfiguration("~/");
            if (webConfig.AppSettings.Settings.Count > 0)
            {
                ImagesDir = GetParameter(webConfig, "ImagesDir");
                PdfEngineDir = GetParameter(webConfig, "PdfEngineDir");
                LicFileLocation = GetParameter(webConfig, "LicFileLocation");
                DeveloperKey = GetParameter(webConfig, "DeveloperKey");
            }
        }

        /// <summary>
        /// Get Parameter
        /// </summary>
        /// <param name="webConfig"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetParameter(Configuration webConfig, string key)
        {
            KeyValueConfigurationElement parmSetting = webConfig.AppSettings.Settings[key];
            return (parmSetting != null) ? parmSetting.Value : "";
        }

        /// <summary>
        /// Implemenets the Singleton Get Instance
        /// </summary>
        public static WSConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WSConfig();
                }
                return instance;
            }
        }
    }
}