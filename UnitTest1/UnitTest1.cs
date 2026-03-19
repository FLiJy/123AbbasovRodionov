using Microsoft.VisualStudio.TestTools.UnitTesting;
using _123AbbasovRodionov.Pages;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        // ТЕСТЫ ДЛЯ PAGE1

        /// <summary>
        /// Проверка корректного вычисления Page1
        /// </summary>
        [TestMethod]
        public void Page1_CorrectData()
        {
            var page = new Page1();

            bool success = page.Calculate(2, 1, 1, out double result);

            Assert.IsTrue(success);
            Assert.AreNotEqual(0, result);
        }

        /// <summary>
        /// Проверка деления на ноль Page1
        /// </summary>
        [TestMethod]
        public void Page1_DivideByZero()
        {
            var page = new Page1();

            bool success = page.Calculate(-1, 0, 1, out double result);

            Assert.IsFalse(success);
        }

        /// <summary>
        /// Проверка граничного значения Page1
        /// </summary>
        [TestMethod]
        public void Page1_Boundary()
        {
            var page = new Page1();

            bool success = page.Calculate(0, 1, 0, out double result);

            Assert.IsTrue(success);
        }

        // ТЕСТЫ ДЛЯ PAGE2

        /// <summary>
        /// Проверка нормального случая Page2
        /// </summary>
        [TestMethod]
        public void Page2_CorrectData()
        {
            var page = new Page2();

            bool success = page.Calculate(2, 3, 2, out double result); // x^2

            Assert.IsTrue(success);
        }

        /// <summary>
        /// Проверка ошибки логарифма
        /// </summary>
        [TestMethod]
        public void Page2_LogError()
        {
            var page = new Page2();

            bool success = page.Calculate(-2, 3, 2, out double result);

            Assert.IsFalse(success);
        }

        /// <summary>
        /// Проверка случая y = 0
        /// </summary>
        [TestMethod]
        public void Page2_YEqualsZero()
        {
            var page = new Page2();

            bool success = page.Calculate(2, 0, 2, out double result);

            Assert.IsTrue(success);
            Assert.AreEqual(0, result);
        }

        
        // ТЕСТЫ ДЛЯ PAGE3
        
        /// <summary>
        /// Проверка вычисления функции Page3
        /// </summary>
        [TestMethod]
        public void Page3_CorrectCalculation()
        {
            var page = new Page3();

            double result = page.CalculateFunctionTest(2, 1);

            Assert.AreNotEqual(0, result);
        }

        /// <summary>
        /// Проверка другого значения Page3
        /// </summary>
        [TestMethod]
        public void Page3_AnotherValue()
        {
            var page = new Page3();

            double result = page.CalculateFunctionTest(5, 2);

            Assert.IsTrue(result != 0);
        }

        /// <summary>
        /// Проверка граничного случая Page3
        /// </summary>
        [TestMethod]
        public void Page3_Boundary()
        {
            var page = new Page3();

            double result = page.CalculateFunctionTest(0, 0);

            Assert.IsTrue(!double.IsNaN(result));
        }
    }
}