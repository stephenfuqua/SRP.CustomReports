using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using SRP.CustomReports.WPF.Entities;
using SRP.CustomReports.WPF.Queries;

namespace SRP.CustomReports.WPF.Forms
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

                return new SrpContext();
            }

            void InitializeClusterComboBox()
            {
                Clusters.ItemsSource = _db.Clusters.ToList();
                Clusters.DisplayMemberPath = nameof(Cluster.ShortNameWithState);
                Clusters.SelectedValuePath = nameof(Cluster.Id);
            }
        }

        private void GetYouthContinuum_Click(object sender, RoutedEventArgs e)
        {
            var clusterId = (long)Clusters.SelectedValue;

            var youth = _db.YouthOnContinuum
                .Where(x => x.ClusterId == clusterId);


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
