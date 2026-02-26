using System;
using System.Windows;
using System.Windows.Controls;

namespace _123AbbasovRodionov.Pages
{
    public partial class Page1 : Page
{
    public Page1()
    {
        InitializeComponent();
    }

    private void Calculate_Click(object sender, RoutedEventArgs e)
    {
        TxtError.Text = "";

        // Валидация ввода
        if (!ValidateInputs(out double x, out double y, out double z))
            return;

        try
        {
            // Формула варианта 12 (страница 1) - 9.b
            // f = (|x-y| * (sin²(z) + tg(z))) / (y * (x+1))
            double numerator = Math.Abs(x - y) * (Math.Pow(Math.Sin(z), 2) + Math.Tan(z));
            double denominator = y * (x + 1);

            if (Math.Abs(denominator) < 1e-10)
                throw new DivideByZeroException("Деление на ноль!");

            double result = numerator / denominator;
            TxtResult.Text = result.ToString("F6");
        }
        catch (Exception ex)
        {
            TxtError.Text = $"Ошибка: {ex.Message}";
        }
    }

    private bool ValidateInputs(out double x, out double y, out double z)
    {
        x = y = z = 0;

        if (string.IsNullOrWhiteSpace(TxtX.Text))
        {
            TxtError.Text = "Поле 'x' не заполнено!";
            return false;
        }

        if (string.IsNullOrWhiteSpace(TxtY.Text))
        {
            TxtError.Text = "Поле 'y' не заполнено!";
            return false;
        }

        if (string.IsNullOrWhiteSpace(TxtZ.Text))
        {
            TxtError.Text = "Поле 'z' не заполнено!";
            return false;
        }

        if (!double.TryParse(TxtX.Text, out x))
        {
            TxtError.Text = "Неверный формат числа в поле 'x'!";
            return false;
        }

        if (!double.TryParse(TxtY.Text, out y))
        {
            TxtError.Text = "Неверный формат числа в поле 'y'!";
            return false;
        }

        if (!double.TryParse(TxtZ.Text, out z))
        {
            TxtError.Text = "Неверный формат числа в поле 'z'!";
            return false;
        }

        return true;
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        TxtX.Clear();
        TxtY.Clear();
        TxtZ.Clear();
        TxtResult.Clear();
        TxtError.Text = "";
    }
}
}