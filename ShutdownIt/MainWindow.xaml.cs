using MahApps.Metro.Controls;
using ShutdownIt.Helpers;
using System.Windows.Media;

namespace ShutdownIt
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.MainWindowViewModel();
            ThemeManagerHelper.CreateAppStyleBy(Color.FromArgb(255, 45, 45, 48), true, true);
        }
    }
}
