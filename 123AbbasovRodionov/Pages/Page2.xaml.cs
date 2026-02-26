using System;
using System.Windows;
using System.Windows.Controls;

namespace _123AbbasovRodionov.Pages
{
    public partial class Page2 : Page
{
    public Page2()
    {
        InitializeComponent();
        RbX2.IsChecked = true; // По умолчанию
    }

    private void Calculate_Click(object sender, RoutedEventArgs e)
    {
        TxtError.Text = "";

        // Валидация ввода
        if (string.IsNullOrWhiteSpace(TxtX.Text))
        {
            TxtError.Text = "Поле 'x' не заполнено!";
            return;
        }

        if (!double.TryParse(TxtX.Text, out double x))
        {
            TxtError.Text = "Неверный формат числа!";
            return;
        }

        try
        {
            double result = 0;

            if (RbSh.IsChecked == true)
            {
                // sh(x) = (e^x - e^(-x)) / 2
                result = Math.Sinh(x);
            }
            else if (RbX2.IsChecked == true)
            {
                // x²
                result = x * x;
            }
            else if (RbExp.IsChecked == true)
            {
                // e^x
                result = Math.Exp(x);
            }

            TxtResult.Text = result.ToString("F6");
        }
        catch (Exception ex)
        {
            TxtError.Text = $"Ошибка: {ex.Message}";
        }
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        TxtX.Clear();
        TxtResult.Clear();
        TxtError.Text = "";
        RbX2.IsChecked = true;
    }
}
}