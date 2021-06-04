using System.Windows;
using DogsExhibitionsSystem.ViewModels;

namespace DogsExhibitionsSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
