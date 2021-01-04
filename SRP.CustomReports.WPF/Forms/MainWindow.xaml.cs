using System.Windows;

namespace SRP.CustomReports.WPF.Forms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Setup_Click(object sender, RoutedEventArgs e)
        {
            new Forms.FindPathToSrp().ShowDialog();
        }

        private void BuildReport_OnClick(object sender, RoutedEventArgs e)
        {
            new Forms.BuildReport().ShowDialog();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }
    }
}
