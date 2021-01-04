using System;
using System.IO;
using System.Reflection;

namespace SRP.CustomReports.WPF.Migrations.Views
{
    public static class ViewFile
    {
        public static string Read(string viewName)
        {
            var viewResource = $"SRP.CustomReports.WPF.Migrations.Views.{viewName}.sql";
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(viewResource))
            using (var reader = new StreamReader(stream ?? throw new InvalidOperationException($"Unable to access resource stream for {viewResource}")))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
