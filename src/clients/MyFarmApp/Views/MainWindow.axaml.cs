using Avalonia.Controls;
using MyFarmApp.ViewModels;

namespace MyFarmApp.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel mainViewModel)
    {
        InitializeComponent();
        DataContext = mainViewModel;
    }
}