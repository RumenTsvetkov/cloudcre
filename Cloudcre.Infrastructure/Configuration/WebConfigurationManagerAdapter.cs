﻿using System.Collections.Specialized;
using System.Configuration;

namespace Cloudcre.Infrastructure.Configuration
{
    /// <summary>
    /// Class that wraps the functionality within the Web Configuration Manager class
    /// </summary>
    public class WebConfigurationManagerAdapter : IConfigurationManager
    {
        /// <summary>
        /// Provides access to the AppSettings in the configuration file
        /// </summary>
        public NameValueCollection AppSettings
        {
            get
            {
                return System.Web.Configuration.WebConfigurationManager.AppSettings;
            }
        }

        public ConnectionStringSettingsCollection ConnectionStrings
        {
            get { return System.Web.Configuration.WebConfigurationManager.ConnectionStrings; }
        }

        /// <summary>
        /// Provides access to any specific section within the configuration file
        /// </summary>
        /// <typeparam name="T">The type associated with the section</typeparam>
        /// <param name="sectionName">Name of the section to return</param>
        /// <returns>The section specified</returns>
        public T GetSection<T>(string sectionName)
        {
            return (T)System.Web.Configuration.WebConfigurationManager.GetSection(sectionName);
        }
    }
}
