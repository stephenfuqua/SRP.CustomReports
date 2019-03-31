using System.Windows;

namespace SRP.CustomReports.WPF
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
            new FindPathToSrp().ShowDialog();
        }

        private void BuildReport_OnClick(object sender, RoutedEventArgs e)
        {
            new BuildReport().ShowDialog();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }
    }
}
