using System;
using System.Collections.Generic;
using System.Text;

namespace PR7_Variant13
{

    /// Реализация шифра Билайна с произвольным количеством строк.
    /// Поддерживает русский и английский алфавит
    public static class BelayneCipher
    {
        /// Зашифровывает текст методом Билайна.
        /// <param name="text">Исходный текст</param>
        /// <param name="numRows">Количество строк (≥ 2)</param>
        /// <returns>Зашифрованный текст</returns>
        public static string Encrypt(string text, int numRows)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            if (numRows < 2)
                throw new ArgumentException("Количество строк должно быть не менее 2.", nameof(numRows));

            if (string.IsNullOrEmpty(text))
                return string.Empty;

            if (numRows >= text.Length)
                return text;

            var rails = new List<StringBuilder>(numRows);
            for (int i = 0; i < numRows; i++)
                rails.Add(new StringBuilder());

            int row = 0;
            bool goingDown = true;

            foreach (char c in text)
            {
                rails[row].Append(c);

                if (goingDown)
                {
                    row = (row == numRows - 1) ? row : row + 1;
                    if (row == numRows - 1) goingDown = false;
                }
                else
                {
                    row = (row == 0) ? row : row - 1;
                    if (row == 0) goingDown = true;
                }
            }

            var result = new StringBuilder();
            foreach (var rail in rails)
                result.Append(rail);

            return result.ToString();
        }

        /// Расшифровывает текст, зашифрованный методом Билайна.
        /// <param name="cipher">Зашифрованный текст</param>
        /// <param name="numRows">Количество строк</param>
        /// <returns>Исходный текст</returns>
        public static string Decrypt(string cipher, int numRows)
        {
            if (cipher == null)
                throw new ArgumentNullException(nameof(cipher));

            if (numRows < 2)
                throw new ArgumentException("Количество строк должно быть не менее 2.", nameof(numRows));

            if (string.IsNullOrEmpty(cipher))
                return string.Empty;

            if (numRows >= cipher.Length)
                return cipher;

            int n = cipher.Length;
            var railLengths = new int[numRows];
            int row = 0;
            bool goingDown = true;

            for (int i = 0; i < n; i++)
            {
                railLengths[row]++;
                if (goingDown)
                {
                    if (row == numRows - 1) goingDown = false;
                    else row++;
                }
                else
                {
                    if (row == 0) goingDown = true;
                    else row--;
                }
            }

            var rails = new char[numRows][];
            int index = 0;
            for (int r = 0; r < numRows; r++)
            {
                rails[r] = new char[railLengths[r]];
                for (int j = 0; j < railLengths[r]; j++)
                    rails[r][j] = cipher[index++];
            }

            var result = new StringBuilder();
            row = 0;
            goingDown = true;
            var pointers = new int[numRows];

            for (int i = 0; i < n; i++)
            {
                result.Append(rails[row][pointers[row]++]);

                if (goingDown)
                {
                    if (row == numRows - 1) goingDown = false;
                    else row++;
                }
                else
                {
                    if (row == 0) goingDown = true;
                    else row--;
                }
            }

            return result.ToString();
        }
    }
}
