using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using DemoProjectWPF.Properties;
using Haley.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace DemoProjectWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly string _connectionStringToServer = "Server=.\\SQLEXPRESS;Database=DemoProject;Trusted_Connection=true;TrustServerCertificate=true;";
        
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                LangUtils.Register(Assembly.GetAssembly(GetType()), "DemoProjectWPF.LangResources.Language",
                    TranslationOverride);
                ChangeCulture(Settings.Default.langCode);
                
                SqlConnection sqlConnection = new SqlConnection(_connectionStringToServer);
                sqlConnection.OpenAsync();

                if (Environment.ExitCode == 0)
                {
                    sqlConnection.CloseAsync();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }


            base.OnStartup(e);
        }

        protected object TranslationOverride(string key, string value, CultureInfo cultureinfo)
        {
            return value;
        }

        public static void ChangeCulture(string langCode)
        {
            LangUtils.ChangeCulture(langCode);
        }
    }
}