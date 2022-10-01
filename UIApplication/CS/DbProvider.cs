using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
namespace FBApiApplication.CS
{
    public static class DbProvider
    {
        private static DbProviderFactory factory = null;
        public static DbProviderFactory Create()
        {
            if (factory == null)
            {
               
                factory = DbProviderFactories.GetFactory(System.Configuration.ConfigurationSettings.AppSettings["DbConnFactory"]);
            }

            return factory;
        }
    }
}
