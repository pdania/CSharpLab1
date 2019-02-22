using System.Windows;
using Lab1ParkhomenkoCSharp2019.ViewModels;

namespace Lab1ParkhomenkoCSharp2019
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
