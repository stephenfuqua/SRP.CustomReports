using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Microsoft.Win32;
using SRP.CustomReports.WPF.Entities;
using SRP.CustomReports.WPF.Queries;

namespace SRP.CustomReports.WPF
{
    /// <summary>
    /// Interaction logic for BuildReport.xaml
    /// </summary>
    public partial class BuildReport : Window
    {
        private readonly SrpContext _db;

        public BuildReport()
        {
            InitializeComponent();
            _db = InitializeDatabaseConnection();
            InitializeClusterComboBox();

            SrpContext InitializeDatabaseConnection()
            {
                var srpMdf = Path.Combine(Properties.Settings.Default.PathToSrp,"SRP.mdf");
                var connectionString = $"Data Source=(localdb)\\SRP;Initial Catalog={srpMdf};Integrated Security=SSPI";

                return new SrpContext(connectionString);
            }

            void InitializeClusterComboBox()
            {
                Clusters.ItemsSource = _db.Clusters.ToList();
                Clusters.DisplayMemberPath = nameof(Cluster.Name);
                Clusters.SelectedValuePath = nameof(Cluster.Id);
            }
        }

        private void GetYouthContinuum_Click(object sender, RoutedEventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            const string resourceName = "SRP.CustomReports.WPF.Queries.YouthContinuum.sql";
            
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                var queryText = reader.ReadToEnd();

                var clusterId = Clusters.SelectedValue;

                var youth =_db.SqlQuery<YouthContinuum>(queryText, new SqlParameter("ClusterId", clusterId));

                
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV|*.csv"
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, YouthContinuum.ListToString(youth));
                }

            }
        }
    }

}
