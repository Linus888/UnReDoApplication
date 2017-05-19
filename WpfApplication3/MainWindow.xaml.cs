using System.Windows;
using WpfApplication3.ViewModel;

namespace WpfApplication3
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = this.DataContext as MainViewModel;
            textBox1.Text = vm.TextBoxText;
        }
    }
}
