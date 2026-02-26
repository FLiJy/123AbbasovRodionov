using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace _123AbbasovRodionov.Pages
{
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }
        
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            TxtError.Text = "";
            TxtResults.Text = "";
            
            // Валидация ввода
            if (!ValidateInputs(out double x0, out double xk, out double dx, 
                               out double a, out double b))
                return;
            
            if (dx <= 0)
            {
                TxtError.Text = "Шаг dx должен быть положительным!";
                return;
            }
            
            if (x0 >= xk)
            {
                TxtError.Text = "x₀ должен быть меньше xₖ!";
                return;
            }
            
            try
            {
                List<double> xValues = new List<double>();
                List<double> yValues = new List<double>();
                string resultsText = "X\t\tY\n";
                resultsText += "------------------------\n";
                
                for (double x = x0; x <= xk; x += dx)
                {
                    double y = CalculateFunction(x, a, b);
                    xValues.Add(x);
                    yValues.Add(y);
                    resultsText += $"{x:F4}\t{y:F6}\n";
                }
                
                TxtResults.Text = resultsText;
                
                //построение графика
                Chart.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "y(x)",
                        Values = new ChartValues<double>(yValues),
                        PointGeometry = null
                    }
                };
            }
            catch (Exception ex)
            {
                TxtError.Text = $"Ошибка: {ex.Message}";
            }
        }
        
        private double CalculateFunction(double x, double a, double b)
        {
            //Формула варианта 12 (страница 3) - пункт 14
            // y = (x - b) * ln(x² + 12.7)
            return (x - b) * Math.Log(x * x + 12.7);
        }
        
        private bool ValidateInputs(out double x0, out double xk, out double dx, 
                                   out double a, out double b)
        {
            x0 = xk = dx = a = b = 0;
            
            if (!TryParseField(TxtX0, "x₀", out x0)) return false;
            if (!TryParseField(TxtXk, "xₖ", out xk)) return false;
            if (!TryParseField(TxtDx, "dx", out dx)) return false;
            if (!TryParseField(TxtA, "a", out a)) return false;
            if (!TryParseField(TxtB, "b", out b)) return false;
            
            return true;
        }
        
        private bool TryParseField(TextBox field, string fieldName, out double value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(field.Text))
            {
                TxtError.Text = $"Поле '{fieldName}' не заполнено!";
                return false;
            }
            if (!double.TryParse(field.Text, out value))
            {
                TxtError.Text = $"Неверный формат числа в поле '{fieldName}'!";
                return false;
            }
            return true;
        }
        
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TxtX0.Clear();
            TxtXk.Clear();
            TxtDx.Clear();
            TxtA.Clear();
            TxtB.Clear();
            TxtResults.Clear();
            TxtError.Text = "";
            Chart.Series = new SeriesCollection();
        }
    }
}