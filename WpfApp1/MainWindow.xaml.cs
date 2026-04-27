using System;
using System.Windows;
using PR7_Variant13;

namespace BelayneCipherWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtRows.Text = "3";
            txtStatus.Text = "Готов к работе";
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidateInput();

                string input = txtInput.Text;
                int rows = int.Parse(txtRows.Text.Trim());

                string result = BelayneCipher.Encrypt(input, rows);
                txtOutput.Text = result;

                txtStatus.Text = $"Текст зашифрован ({rows} строк)";
                txtStatus.Foreground = System.Windows.Media.Brushes.DarkGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка шифрования",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                txtStatus.Text = "Ошибка шифрования";
                txtStatus.Foreground = System.Windows.Media.Brushes.Red;
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidateInput();

                string input = txtInput.Text;
                int rows = int.Parse(txtRows.Text.Trim());

                string result = BelayneCipher.Decrypt(input, rows);
                txtOutput.Text = result;

                txtStatus.Text = $"Текст расшифрован ({rows} строк)";
                txtStatus.Foreground = System.Windows.Media.Brushes.DarkGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка дешифрования",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                txtStatus.Text = "Ошибка дешифрования";
                txtStatus.Foreground = System.Windows.Media.Brushes.Red;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            txtOutput.Clear();
            txtRows.Text = "3";
            txtStatus.Text = "Поля очищены";
            txtStatus.Foreground = System.Windows.Media.Brushes.Gray;
        }

        private void ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
                throw new Exception("Введите текст для обработки!");

            if (!int.TryParse(txtRows.Text.Trim(), out int rows) || rows < 2)
                throw new Exception("Количество строк должно быть целым числом не менее 2!");
        }
    }
}