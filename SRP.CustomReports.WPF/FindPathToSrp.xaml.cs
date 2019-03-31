using System;
using System.Windows;
using WK.Libraries.BetterFolderBrowserNS;

namespace SRP.CustomReports.WPF
{
    /// <summary>
    /// Interaction logic for FindPathToSrp.xaml
    /// </summary>
    public partial class FindPathToSrp : Window
    {
        public FindPathToSrp()
        {
            InitializeComponent();

            PathToSrp.Text = Properties.Settings.Default.PathToSrp;
        }


        private void FindFile_Click(object sender, RoutedEventArgs e)
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var openFileDialog = new BetterFolderBrowser
            {
                Title="Select folder containing SRP.mdf",
                RootFolder = System.IO.Path.Combine(appDataPath,"SRP"),

            };
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PathToSrp.Text = openFileDialog.SelectedFolder;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.PathToSrp = PathToSrp.Text;
            Properties.Settings.Default.Save();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
