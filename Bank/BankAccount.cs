using System;

namespace BankAccountNS
{
    /// <summary>
    /// Класс банковского счета
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Имя клиента
        /// </summary>
        private readonly string m_customerName;

        /// <summary>
        /// Баланс счета
        /// </summary>
        private double m_balance;

        private BankAccount() { }

        /// <summary>
        /// Конструктор счета
        /// </summary>
        /// <param name="customerName">Имя клиента</param>
        /// <param name="balance">Начальный баланс</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Получить имя клиента
        /// </summary>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Получить баланс
        /// </summary>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Снять деньги со счета
        /// </summary>
        /// <param name="amount">Сумма снятия</param>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance -= amount;
        }

        /// <summary>
        /// Пополнение счета
        /// </summary>
        /// <param name="amount">Сумма пополнения</param>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);

            Console.WriteLine("Current balance is {0}", ba.Balance);
            Console.ReadLine();
        }
    }
}