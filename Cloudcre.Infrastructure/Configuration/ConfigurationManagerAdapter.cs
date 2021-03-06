﻿using System.Collections.Specialized;
using System.Configuration;

namespace Cloudcre.Infrastructure.Configuration
{
    /// <summary>
    /// Class that wraps the functionality within the standard Configuration Manager class
    /// </summary>
    public class ConfigurationManagerAdapter : IConfigurationManager
    {
        /// <summary>
        /// Provides access to the AppSettings in the configuration file
        /// </summary>
        public NameValueCollection AppSettings
        {
            get
            {
                return ConfigurationManager.AppSettings;
            }
        }

        public ConnectionStringSettingsCollection ConnectionStrings
        {
            get { return ConfigurationManager.ConnectionStrings; }
        }

        /// <summary>
        /// Provides access to any specific section within the configuration file
        /// </summary>
        /// <typeparam name="T">The type associated with the section</typeparam>
        /// <param name="sectionName">Name of the section to return</param>
        /// <returns>The section specified</returns>
        public T GetSection<T>(string sectionName)
        {
            return (T)ConfigurationManager.GetSection(sectionName);
        }
    }
}
