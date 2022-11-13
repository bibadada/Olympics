using System.Windows;
using Olympics.ViewModels;

namespace Olympics
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowViewModel();
            DataContext = vm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vm.Setup();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.AzzeraFiltri();
        }

        private void Button_Click_Avanti(object sender, RoutedEventArgs e)
        {
            vm.Avanti();
        }

        private void Button_Click_Indietro(object sender, RoutedEventArgs e)
        {
            vm.Indietro();
        }

        private void Button_Click_Ultima(object sender, RoutedEventArgs e)
        {
            vm.Ultima();
        }

        private void Button_Click_Prima(object sender, RoutedEventArgs e)
        {
            vm.Prima();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("E80 Prova Intermedia - Davide Regnani\n\nPublic Repo: github.com/bibadada/Olympics");
        }
    }
}
