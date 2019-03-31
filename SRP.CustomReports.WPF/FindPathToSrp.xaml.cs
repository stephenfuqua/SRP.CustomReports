using System;
using System.Windows;
using Microsoft.Win32;

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

            var openFileDialog = new OpenFileDialog
            {
                Filter = "SRP.mdf|SRP.mdf",
                InitialDirectory = System.IO.Path.Combine(appDataPath,"SRP")
            };
            if (openFileDialog.ShowDialog() == true)
            {
                PathToSrp.Text = openFileDialog.FileName;
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
