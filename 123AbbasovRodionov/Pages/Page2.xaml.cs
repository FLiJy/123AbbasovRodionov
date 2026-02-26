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
    }

    /// <summary>
    /// Обработчик кнопки "Вычислить"
    /// </summary>
    private void Calculate_Click(object sender, RoutedEventArgs e)
    {
        TxtError.Text = "";
        TxtCondition.Text = "";

        // Валидация ввода
        if (!ValidateInputs(out double x, out double y))
            return;

        try
        {
            // Вычисляем f(x) на основе выбранной функции
            double fx = CalculateFx(x);

            // Вычисляем b по формуле с условиями
            double b = CalculateB(fx, x, y, out string condition);

            // Отображаем результат и условие
            TxtResult.Text = b.ToString("F6");
            TxtCondition.Text = $"Условие: {condition}";
        }
        catch (Exception ex)
        {
            TxtError.Text = $"Ошибка: {ex.Message}";
            TxtResult.Text = "";
        }
    }

    /// <summary>
    /// Вычисление f(x) на основе выбранной функции
    /// </summary>
    private double CalculateFx(double x)
    {
        if (RbSh.IsChecked == true)
        {
            // sh(x) = (e^x - e^(-x)) / 2
            return Math.Sinh(x);
        }
        else if (RbX2.IsChecked == true)
        {
            // x²
            return x * x;
        }
        else if (RbExp.IsChecked == true)
        {
            // e^x
            return Math.Exp(x);
        }

        return x * x; // По умолчанию
    }

    /// <summary>
    /// Вычисление b по формуле с условиями
    /// Формула варианта 12 (Страница 2):
    /// b = ln(f(x)) + (f(x)² + y)³,           если x/y > 0
    /// b = ln|f(x)/y| + (f(x) + y)³,          если x/y < 0
    /// b = (f(x)² + y)³,                      если x = 0
    /// b = 0,                                  если y = 0
    /// </summary>
    private double CalculateB(double fx, double x, double y, out string condition)
    {
        // Случай 1: y = 0
        if (y == 0)
        {
            condition = "y = 0";
            return 0;
        }

        // Случай 2: x = 0
        if (x == 0)
        {
            condition = "x = 0";
            double result = Math.Pow(Math.Pow(fx, 2) + y, 3);
            return result;
        }

        // Вычисляем отношение x/y
        double ratio = x / y;

        // Случай 3: x/y > 0
        if (ratio > 0)
        {
            condition = "x/y > 0";

            // Проверка на положительное значение под логарифмом
            if (fx <= 0)
                throw new ArgumentException($"ln(f(x)) невозможен: f(x) = {fx:F6} ≤ 0");

            double ln_fx = Math.Log(fx);
            double power_term = Math.Pow(Math.Pow(fx, 2) + y, 3);
            return ln_fx + power_term;
        }
        // Случай 4: x/y < 0
        else if (ratio < 0)
        {
            condition = "x/y < 0";

            // Проверка на положительное значение под логарифмом
            double fx_over_y = fx / y;
            if (Math.Abs(fx_over_y) <= 0)
                throw new ArgumentException($"ln|f(x)/y| невозможен: |f(x)/y| = {Math.Abs(fx_over_y):F6} ≤ 0");

            double ln_abs = Math.Log(Math.Abs(fx_over_y));
            double power_term = Math.Pow(fx + y, 3);
            return ln_abs + power_term;
        }

        condition = "Неизвестное условие";
        return 0;
    }

    /// <summary>
    /// Валидация входных данных
    /// </summary>
    private bool ValidateInputs(out double x, out double y)
    {
        x = y = 0;

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

        return true;
    }

    /// <summary>
    /// Обработчик кнопки "Очистить"
    /// </summary>
    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        TxtX.Clear();
        TxtY.Clear();
        TxtResult.Clear();
        TxtCondition.Text = "";
        TxtError.Text = "";
        RbX2.IsChecked = true; // По умолчанию
    }
}
}