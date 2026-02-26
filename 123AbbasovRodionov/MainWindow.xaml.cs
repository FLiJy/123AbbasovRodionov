using System;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace _123AbbasovRodionov
{
    public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new Pages.Page1());

        // Обработка закрытия с подтверждением
        Closing += MainWindow_Closing;
    }

    private void NavButton_Click(object sender, RoutedEventArgs e)
    {
        Button btn = sender as Button;
        string pageTag = btn?.Tag as string;

        switch (pageTag)
        {
            case "Page1":
                MainFrame.Navigate(new Pages.Page1());
                break;
            case "Page2":
                MainFrame.Navigate(new Pages.Page2());
                break;
            case "Page3":
                MainFrame.Navigate(new Pages.Page3());
                break;
        }
    }

    private void MainWindow_Closing(object sender,
                                    System.ComponentModel.CancelEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show(
            "Вы действительно хотите выйти из приложения?",
            "Подтверждение выхода",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

        e.Cancel = (result == MessageBoxResult.No);
    }
}
}