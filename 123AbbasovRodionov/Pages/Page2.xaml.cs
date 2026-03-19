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
        /// Основной метод вычисления страницы 2
        /// </summary>
        /// <summary>
        /// Основной метод вычисления страницы 2
        /// </summary>
        public bool Calculate(double x, double y, int mode, out double result)
        {
            result = 0;

            try
            {
                double fx;

                // ❗ вместо switch expression
                if (mode == 1)
                    fx = Math.Sinh(x);
                else if (mode == 2)
                    fx = x * x;
                else if (mode == 3)
                    fx = Math.Exp(x);
                else
                    fx = x * x;

                if (y == 0)
                {
                    result = 0;
                    return true;
                }

                if (x == 0)
                {
                    result = Math.Pow(Math.Pow(fx, 2) + y, 3);
                    return true;
                }

                double ratio = x / y;

                if (ratio > 0)
                {
                    if (fx <= 0)
                        return false;

                    result = Math.Log(fx) + Math.Pow(Math.Pow(fx, 2) + y, 3);
                }
                else
                {
                    double val = fx / y;

                    if (Math.Abs(val) <= 0)
                        return false;

                    result = Math.Log(Math.Abs(val)) + Math.Pow(fx + y, 3);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            TxtError.Text = "";
            TxtCondition.Text = "";

            if (!ValidateInputs(out double x, out double y))
                return;

            int mode = RbSh.IsChecked == true ? 1 :
                       RbX2.IsChecked == true ? 2 : 3;

            if (Calculate(x, y, mode, out double result))
            {
                TxtResult.Text = result.ToString("F6");
                TxtCondition.Text = "Рассчитано успешно";
            }
            else
            {
                TxtError.Text = "Ошибка вычисления!";
                TxtResult.Text = "";
            }
        }

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

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TxtX.Clear();
            TxtY.Clear();
            TxtResult.Clear();
            TxtCondition.Text = "";
            TxtError.Text = "";
            RbX2.IsChecked = true;
        }
    }
}